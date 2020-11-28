using EstateApi.Models;
using EstateApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateApi.Contracts
{
    public  interface IEsateRepository
    {
        IEnumerable<EsateViewModel> GetAll();
        Task<Estate> Add(Estate estate);
        Task<Estate> Find(int id);
        Task<EsateViewModel> Update(EsateViewModel estate);
        Task<EsateViewModel> Remove(EsateViewModel estate);
        Task<bool> IsExists(int id);
        Task<int> CountEsate();
    }
}
