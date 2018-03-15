using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PD.Model
{
    public class Roles
    {
        public string RoleId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string ParentId { get; set; }

        public bool Enable { get; set; }

        public int OrderField { get; set; }

        public string Functions { get; set; }

        public string Desc { get; set; }
    }
}
