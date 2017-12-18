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
    public class BancoAppService : BaseApplicationService, IBancoAppService
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IMapper _mapper;

        public BancoAppService(IMapper mapper, IBancoRepository bancoRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _mapper = mapper;
            _bancoRepository = bancoRepository;
        }

        public List<DomainNotification> ObterNotificacoes()
        {
            return ObterNotificacoesDominio();
        }

        public BancoViewModel Adicionar(BancoViewModel model)
        {
            var domain = _mapper.Map<Banco>(model);
            if (!Notifications.HasNotifications())
            {
                _bancoRepository.Adicionar(domain);
                if (!Commit())
                {
                    //todo: falha ao salvar
                }
            }
            return _mapper.Map<BancoViewModel>(domain);
        }

        public void Atualizar(BancoViewModel model)
        {
            var domain = _mapper.Map<Banco>(model);
            if (!Notifications.HasNotifications())
            {
                _bancoRepository.Atualizar(domain);
                if (!Commit())
                {
                    //todo: falha ao salvar
                }
            }
        }

        public void Excluir(int id)
        {
            var banco = _bancoRepository.ObterPorId(id);
            if(banco != null)
                _bancoRepository.Remover(id);
            if (!Commit())
            {
                //todo: falha ao salvar
            }
        }

        public BancoViewModel ObterPorId(int id)
        {
            return _mapper.Map<BancoViewModel>(_bancoRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            _bancoRepository.Dispose();
        }

        public IEnumerable<BancoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<BancoViewModel>>(_bancoRepository.ObterTodos());
        }
    }
}