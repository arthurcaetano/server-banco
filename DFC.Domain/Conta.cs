using System.Collections;
using System.Collections.Generic;
using DFC.Domain.Core;
using DFC.Domain.Core.Enums;

namespace DFC.Domain
{
    public class Conta : BaseEntity<Conta>
    {
        public string Titular { get; private set; }
        public string CpfCnpj { get; private set; }
        public string Numero { get; private set; }
        public EnumTipoConta TipoConta { get; private set; }
        public EnumTipoPessoa TipoPessoa { get; private set; }
        public Banco Banco { get; private set; }
        public int IdBanco { get; private set; }
        public ICollection<Movimentacao> Movimentacao { get; private set; }

        protected Conta()
        {

        }

        public Conta(string titular, string cpfCnpj, string numero, EnumTipoConta tipoConta, EnumTipoPessoa tipoPessoa, Banco banco, int idBanco, ICollection<Movimentacao> movimentacao)
        {
            Titular = titular;
            CpfCnpj = cpfCnpj;
            Numero = numero;
            TipoConta = tipoConta;
            TipoPessoa = tipoPessoa;
            Banco = banco;
            IdBanco = idBanco;
            Movimentacao = movimentacao;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}