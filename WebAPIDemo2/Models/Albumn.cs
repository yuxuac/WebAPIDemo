using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo2.Models
{
    public class Albumn
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Band Band { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class Band
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}