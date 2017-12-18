using System.Collections.Generic;

namespace DFC.Application.ViewModels
{
    public class BancoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<BancoAgenciaViewModel> Agencias { get; set; }
    }
}