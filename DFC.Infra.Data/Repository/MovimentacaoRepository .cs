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
    public class MovimentacaoRepository : Repository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(ApplicationContext context) : base(context)
        {
            
        }

        public override void Adicionar(Movimentacao movimentacao)
        {
            Db.Add(movimentacao);
        }
        public override Movimentacao ObterPorId(int id)
        {
            return Db.Movimentacoes.Include(p => p.Conta).AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public override IEnumerable<Movimentacao> ObterTodos()
        {
            return Db.Movimentacoes.Include(p => p.Conta).AsNoTracking().ToList();
        }

        public IEnumerable<Movimentacao> ObterPorIdConta(int idConta)
        {
            return Db.Movimentacoes.Include(p => p.Conta).AsNoTracking().Where(p => p.IdConta == idConta).ToList();
        }
    }
}