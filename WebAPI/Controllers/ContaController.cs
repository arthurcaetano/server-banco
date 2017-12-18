using System.Collections.Generic;
using System.Linq;
using DFC.Application.Interfaces;
using DFC.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ContaController : Controller
    {
        private readonly IContaAppService _contaAppService;

        public ContaController(IContaAppService contaAppService)
        {
            _contaAppService = contaAppService;
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
            var notifications = _contaAppService.ObterNotificacoes();
            return BadRequest(new
            {
                success = false,
                errors = notifications.Select(n => n.Value)
            });
        }

        protected bool OperacaoValida()
        {
            var notifications = _contaAppService.ObterNotificacoes();
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
        [Route("contas")]
        [AllowAnonymous]
        public IEnumerable<ContaViewModel> Get()
        {
            return _contaAppService.ObterTodos();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("contas/{id:int}")]
        public ContaViewModel Get(int id)
        {
            return _contaAppService.ObterPorId(id);
        }

        [HttpPost]
        [Route("contas")]
        public IActionResult Post([FromBody]ContaViewModel contaViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            contaViewModel = _contaAppService.Adicionar(contaViewModel);
            return Response(contaViewModel);
        }

        [HttpPut]
        [Route("contas")]
        public IActionResult Put([FromBody]ContaViewModel contaViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            _contaAppService.Atualizar(contaViewModel);
            return Response(contaViewModel);
        }

        [HttpDelete]
        [Route("contas/{id:long}")]
        public IActionResult Delete(int id)
        {
            var contaViewModel = new ContaViewModel { Id = id };
            _contaAppService.Excluir(contaViewModel.Id);
            return Response(contaViewModel);
        }

        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;
            return false;
        }
    }
}