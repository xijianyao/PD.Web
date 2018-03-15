using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PD.Model
{
    public class Category
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public string Desc { get; set; }
        public string ParentId { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
