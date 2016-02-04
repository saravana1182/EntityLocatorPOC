using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace EnitityLocator.Models
{
    public class SetupViewModel
    {
        public string Category {get;set;}
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}