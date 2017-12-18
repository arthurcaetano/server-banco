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
    public class BancoRepository : Repository<Banco>, IBancoRepository
    {
        public BancoRepository(ApplicationContext context) : base(context)
        {
            
        }

        public override Banco ObterPorId(int id)
        {
            return Db.Bancos.Include(p => p.Agencias).AsNoTracking().FirstOrDefault(p => p.Id == id);
        }
    }
}