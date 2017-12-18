using AutoMapper;
using DFC.Application.ViewModels;
using DFC.Domain;

namespace DFC.Application.AutoMapper
{
    /// <summary>
    /// Converte Domínio para Modelo de visão
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// Mapeamento
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Banco, BancoViewModel>();
        }
    }
}