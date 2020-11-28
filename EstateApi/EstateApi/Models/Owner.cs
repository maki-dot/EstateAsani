using System;
using System.Collections.Generic;

namespace EstateApi.Models
{
    public partial class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
