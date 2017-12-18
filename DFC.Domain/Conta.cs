using DFC.Domain.Core;
using DFC.Domain.Core.Enums;

namespace DFC.Domain
{
    public class Conta : BaseEntity<Conta>
    {
        public string Titular { get; private set; }
        public string CpfCnpj { get; private set; }
        public EnumTipoConta TipoConta { get; private set; }
        public EnumTipoPessoa TipoPessoa { get; private set; }

        public Conta(string titular, string cpfCnpj, EnumTipoPessoa tipoPessoa, EnumTipoConta tipoConta)
        {
            Titular = titular;
            CpfCnpj = cpfCnpj;
            TipoPessoa = tipoPessoa;
            TipoConta = tipoConta;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}