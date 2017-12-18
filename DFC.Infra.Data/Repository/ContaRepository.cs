using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using DFC.Domain;
using DFC.Domain.Interfaces;
using DFC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DFC.Infra.Data.Repository
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(ApplicationContext context) : base(context)
        {
            
        }

        public override void Adicionar(Conta conta)
        {
            Db.Add(conta);
        }
        public override Conta ObterPorId(int id)
        {
            return Db.Contas.Include(p => p.Agencia.Banco).Include(p => p.Movimentacao).AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public override IEnumerable<Conta> ObterTodos()
        {
            return Db.Contas.Include(p => p.Movimentacao).AsNoTracking().ToList();
        }
    }
}