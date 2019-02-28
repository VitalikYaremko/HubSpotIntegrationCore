using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubSpotIntegrationCore.Domain.Models
{
    public class ContactModel
    {
        public int Vid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Lifecyclestage { get; set; }

        public string Associated_company { get; set; }
        public int? Company_id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
    }
}
