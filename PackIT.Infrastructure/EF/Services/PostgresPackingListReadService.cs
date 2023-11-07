using Microsoft.EntityFrameworkCore;
using PackIT.Application.Services;
using PackIT.Infrastructure.EF.Context;
using PackIT.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Infrastructure.EF.Services
{
    internal sealed class PostgresPackingListReadService : IPackingListReadService
    {
        private readonly DbSet<PackingListReadModel> _packingLists;
        public PostgresPackingListReadService(ReadDbContext context)
            => _packingLists = context.PackingLists;
        public Task<bool> ExistsByNameAsync(string name)
            => _packingLists.AnyAsync(x => x.Name == name);
    }
}
