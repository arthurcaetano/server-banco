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
    public class ContaAppService : BaseApplicationService, IContaAppService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMapper _mapper;

        public ContaAppService(IMapper mapper, IContaRepository contaRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mapper = mapper;
            _contaRepository = contaRepository;
        }

        public List<DomainNotification> ObterNotificacoes()
        {
            return ObterNotificacoesDominio();
        }

        public ContaViewModel Adicionar(ContaViewModel model)
        {
            var domain = _mapper.Map<Conta>(model);
            if (!Notifications.HasNotifications())
            {
                _contaRepository.Adicionar(domain);
                if (!Commit())
                {
                    //todo: falha ao salvar
                }
            }
            return _mapper.Map<ContaViewModel>(domain);
        }

        public void Atualizar(ContaViewModel model)
        {
            var domain = _mapper.Map<Conta>(model);
            if (!Notifications.HasNotifications())
            {
                _contaRepository.Atualizar(domain);
                if (!Commit())
                {
                    //todo: falha ao salvar
                }
            }
        }

        public void Excluir(int id)
        {
            var conta = _contaRepository.ObterPorId(id);
            if(conta != null)
                _contaRepository.Remover(id);
        }

        public ContaViewModel ObterPorId(int id)
        {
            return _mapper.Map<ContaViewModel>(_contaRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            _contaRepository.Dispose();
        }

        public IEnumerable<ContaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ContaViewModel>>(_contaRepository.ObterTodos());
        }
    }
}