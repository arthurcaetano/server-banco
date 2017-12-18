using System.Collections.Generic;
using System.Linq;
using DFC.Application.Interfaces;
using DFC.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoAppService _movimentacaoAppService;

        public MovimentacaoController(IMovimentacaoAppService movimentacaoAppService)
        {
            _movimentacaoAppService = movimentacaoAppService;
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
            var notifications = _movimentacaoAppService.ObterNotificacoes();
            return BadRequest(new
            {
                success = false,
                errors = notifications.Select(n => n.Value)
            });
        }

        protected bool OperacaoValida()
        {
            var notifications = _movimentacaoAppService.ObterNotificacoes();
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
        [Route("movimentacao")]
        [AllowAnonymous]
        public IEnumerable<MovimentacaoViewModel> Get()
        {
            return _movimentacaoAppService.ObterTodos();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("movimentacao/{id:int}")]
        public MovimentacaoViewModel Get(int id)
        {
            return _movimentacaoAppService.ObterPorId(id);
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("movimentacao/conta/{idConta:int}")]
        public IEnumerable<MovimentacaoViewModel> ObterPorConta(int idConta)
        {
            return _movimentacaoAppService.ObterTodasPorConta(idConta);
        }

        [HttpPost]
        [Route("movimentacao")]
        public IActionResult Post([FromBody]MovimentacaoViewModel movimentacaoViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            movimentacaoViewModel = _movimentacaoAppService.Adicionar(movimentacaoViewModel);
            return Response(movimentacaoViewModel);
        }

        [HttpPut]
        [Route("movimentacao")]
        public IActionResult Put([FromBody]MovimentacaoViewModel movimentacaoViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            _movimentacaoAppService.Atualizar(movimentacaoViewModel);
            return Response(movimentacaoViewModel);
        }

        [HttpDelete]
        [Route("movimentacao/{id:int}")]
        public IActionResult Delete(int id)
        {
            var movimentacaoViewModel = new MovimentacaoViewModel { Id = id };
            _movimentacaoAppService.Excluir(movimentacaoViewModel.Id);
            return Response(movimentacaoViewModel);
        }

        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;
            return false;
        }
    }
}