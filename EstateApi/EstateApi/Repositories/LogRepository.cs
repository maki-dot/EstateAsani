using EstateApi.Contracts;
using EstateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateApi.Repositories
{
    public class LogRepository : ILogger
    {


        private EstateContext _context;

        public LogRepository(EstateContext context)
        {
            _context = context;
        }


        public async Task<EsateLoging> Add(EsateLoging estatelogging)
        {
            await _context.EsateLoging.AddAsync(estatelogging);
            await _context.SaveChangesAsync();
            return estatelogging;
        }
    }
}
