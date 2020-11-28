using EstateApi.Contracts;
using EstateApi.Models;
using EstateApi.ViewModel;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateApi.Repositories
{
    public class EsateRepository : IEsateRepository
    {

        private ILogger _logger;
        private EstateContext _context;

        public EsateRepository(EstateContext context)
        {
            _context = context;
        }



        public async Task<Estate> Add(Estate estate)
        {


            await _context.Estate.AddAsync(estate);
            await _context.SaveChangesAsync();
            var id = estate.EstateId;

            AddLog(estate.CreateUser, "Estate", "Add", id);

            return estate;
        }

        public async Task<int> CountEsate()
        {
            return await _context.Estate.CountAsync();
        }

        public async Task<Estate> Find(int id)
        {
            return await _context.Estate.SingleOrDefaultAsync(c => c.EstateId == id);
        }

        public IEnumerable<EsateViewModel> GetAll()
        {


            var Esates = (from lestate in _context.Estate
                          join lowner in _context.Owner on lestate.OwnerId equals lowner.Id

                          where lestate.IsDeleted == false
                          select new EsateViewModel()
                          {
                              EstateId = lestate.EstateId,
                              EstateNumber = lestate.EstateNumber,
                              Area = lestate.Area,
                              EstateName = lestate.EstateName,
                              Orientedstate = lestate.Orientedstate,
                              Comment = lestate.Comment,
                              OwnerId = lestate.OwnerId,
                              OwnerName = lowner.FirstName + " " + lowner.LastName,
                              OwnerPhone = lowner.PhoneNumber
                          });


            return Esates.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Estate.AnyAsync(c => c.EstateId == id);
        }

        public async Task<EsateViewModel> Remove(EsateViewModel estate)
        {
            var estatemodel = _context.Estate.Find(estate.EstateId);

            estatemodel.IsDeleted = true;

            _context.Update(estatemodel);
            await _context.SaveChangesAsync();

            AddLog(estate.UserId,"Estate", "Delete",estate.EstateId);

            return estate;
        }

        public async Task<EsateViewModel> Update(EsateViewModel estate)
        {
            var esatemodel = _context.Estate.Find(estate.EstateId);

            esatemodel.EstateNumber = estate.EstateNumber;
            esatemodel.EstateName = estate.EstateName;
            esatemodel.Area = estate.Area;
            esatemodel.Address = estate.Address;
            esatemodel.Orientedstate = estate.Orientedstate;
            esatemodel.Comment = estate.Comment;
            esatemodel.OwnerId = estate.OwnerId;
          
            _context.Update(esatemodel);
            await _context.SaveChangesAsync();

            AddLog(estate.UserId, "Estate", "Update", estate.EstateId);

            return estate;
        }


        private void AddLog(int? userid,string TableName,string Extention,int id)
        {
           
                EsateLoging objLog = new EsateLoging();

                objLog.LogDate = DateTime.Now;
                objLog.LogExeption = Extention;
                objLog.LogTable = TableName;
                objLog.LogTableId = id;
                objLog.Userid = userid;

                _logger.Add(objLog);
             
           

        }
    }
}
