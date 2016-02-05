﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class CourtCode : ISetupEntityCode
    {
        public static string CategoryType
        {
            get
            {
                return "CC";
            }
           
        }

        [Key]
        public int Id { get; set; }
        
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class LocationCode :ISetupEntityCode
    {

        public static string CategoryType
        {
            get
            {
                return "LC";
            }

        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


}


