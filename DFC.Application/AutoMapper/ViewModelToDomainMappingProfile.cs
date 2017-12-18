using AutoMapper;
using DFC.Application.ViewModels;
using DFC.Domain;

namespace DFC.Application.AutoMapper
{
    /// <summary>
    /// Converte Modelo de visão para Domínio
    /// </summary>
    public class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// Mapeamento
        /// </summary>
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BancoViewModel, Banco>();
            CreateMap<ContaViewModel, Conta>();
            CreateMap<MovimentacaoViewModel, Movimentacao>();
            CreateMap<BancoAgenciaViewModel, BancoAgencia>();
        }
    }
}