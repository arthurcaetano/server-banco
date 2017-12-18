using System.Collections.Generic;
using AutoMapper;
using DFC.Application.Core;
using DFC.Application.Interfaces;
using DFC.Application.ViewModels;
using DFC.Domain;
using DFC.Domain.Core.Events;
using DFC.Domain.Interfaces;
using DFC.Infra.Data.Interface;

namespace DFC.Application.Services
{
    public class MovimentacaoAppService : BaseApplicationService, IMovimentacaoAppService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IMapper _mapper;

        public MovimentacaoAppService(IMapper mapper, IMovimentacaoRepository movimentacaoRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mapper = mapper;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public List<DomainNotification> ObterNotificacoes()
        {
            return ObterNotificacoesDominio();
        }

        public IEnumerable<MovimentacaoViewModel> ObterTodasPorConta(int idConta)
        {
            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(_movimentacaoRepository.ObterPorIdConta(idConta));
        }

        public MovimentacaoViewModel Adicionar(MovimentacaoViewModel model)
        {
            var domain = _mapper.Map<Movimentacao>(model);
            if (!Notifications.HasNotifications())
            {
                _movimentacaoRepository.Adicionar(domain);
                if (!Commit())
                {
                    //todo: falha ao salvar
                }
            }
            return _mapper.Map<MovimentacaoViewModel>(domain);
        }

        public void Atualizar(MovimentacaoViewModel model)
        {
            var domain = _mapper.Map<Movimentacao>(model);
            if (!Notifications.HasNotifications())
            {
                _movimentacaoRepository.Atualizar(domain);
                if (!Commit())
                {
                    //todo: falha ao salvar
                }
            }
        }

        public void Excluir(int id)
        {
            var movimentacao = _movimentacaoRepository.ObterPorId(id);
            if(movimentacao != null)
                _movimentacaoRepository.Remover(id);
            if (!Commit())
            {
                //todo: falha ao salvar
            }
        }

        public MovimentacaoViewModel ObterPorId(int id)
        {
            return _mapper.Map<MovimentacaoViewModel>(_movimentacaoRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            _movimentacaoRepository.Dispose();
        }

        public IEnumerable<MovimentacaoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(_movimentacaoRepository.ObterTodos());
        }
    }
}