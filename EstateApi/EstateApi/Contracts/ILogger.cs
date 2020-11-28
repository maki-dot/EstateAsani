using EstateApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateApi.Contracts
{
    public  interface ILogger
    {
        Task<EsateLoging> Add(EsateLoging estatelogging);
    }
}
