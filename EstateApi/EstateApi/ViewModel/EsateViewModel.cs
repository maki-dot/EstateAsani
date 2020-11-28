using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateApi.ViewModel
{
    public class EsateViewModel
    {
        public int EstateId { get; set; }
        public string EstateNumber { get; set; }
        public string EstateName { get; set; }
        public double? Area { get; set; }
        public string Address { get; set; }
        public byte? Orientedstate { get; set; }
        public string Comment { get; set; }
        public int? OwnerId { get; set; }
        public bool? IsDeleted { get; set; }

        public string OwnerName { get; set; }

        public string OwnerPhone { get; set; }

        public string OwnerAddress { get; set; }

        public int UserId { get; set; }
    }
}
