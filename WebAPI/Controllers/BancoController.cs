using System.Collections.Generic;
using System.Linq;
using DFC.Application.Interfaces;
using DFC.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BancoController : Controller
    {
        private readonly IBancoAppService _bancoAppService;

        public BancoController(IBancoAppService bancoAppService)
        {
            _bancoAppService = bancoAppService;
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            var notifications = _bancoAppService.ObterNotificacoes();
            return BadRequest(new
            {
                success = false,
                errors = notifications.Select(n => n.Value)
            });
        }

        protected bool OperacaoValida()
        {
            var notifications = _bancoAppService.ObterNotificacoes();
            return (notifications == null);
        }

        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {

        }

        [HttpGet]
        [Route("bancos")]
        [AllowAnonymous]
        public IEnumerable<BancoViewModel> Get()
        {
            return _bancoAppService.ObterTodos();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("bancos/{id:int}")]
        public BancoViewModel Get(int id)
        {
            return _bancoAppService.ObterPorId(id);
        }

        [HttpPost]
        [Route("bancos")]
        public IActionResult Post([FromBody]BancoViewModel bancoViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            bancoViewModel = _bancoAppService.Adicionar(bancoViewModel);
            return Response(bancoViewModel);
        }

        [HttpPut]
        [Route("bancos")]
        public IActionResult Put([FromBody]BancoViewModel bancoViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            _bancoAppService.Atualizar(bancoViewModel);
            return Response(bancoViewModel);
        }

        [HttpDelete]
        [Route("bancos/{id:int}")]
        public IActionResult Delete(int id)
        {
            var bancoViewModel = new BancoViewModel { Id = id };
            _bancoAppService.Excluir(bancoViewModel.Id);
            return Response(bancoViewModel);
        }

        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;
            return false;
        }
    }

}