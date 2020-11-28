using System;
using System.Collections.Generic;

namespace EstateApi.Models
{
    public partial class EsateLoging
    {
        public int Id { get; set; }
        public DateTime? LogDate { get; set; }
        public int? Userid { get; set; }
        public string LogTable { get; set; }
        public string LogExeption { get; set; }
        public int? LogTableId { get; set; }
    }
}
