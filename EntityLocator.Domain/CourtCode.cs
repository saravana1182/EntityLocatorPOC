using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class CourtCode : ISetupEntityCode
    {
        public string CategoryType
        {
            get
            {
                return "CC";
            }
           
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
