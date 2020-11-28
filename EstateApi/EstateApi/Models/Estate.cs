using System;
using System.Collections.Generic;

namespace EstateApi.Models
{
    public partial class Estate
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
        public int? CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
