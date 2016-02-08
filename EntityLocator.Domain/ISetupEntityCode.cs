using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public interface ISetupEntityCode
    {

       // static string CategoryType { get; set; }
       
        int Id { get; set; }
        string Code { get; set; }
        string Description { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
