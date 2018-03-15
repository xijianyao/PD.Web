using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PD.Util
{
    public class JsonMapTable
    {
        public string MapTable { get; set; }

        public string MapExist { get; set; }

        public string MapRelated { get; set; }

        public JsonMapTable(string MapTable, string MapExist, string MapRelated)
        {
            this.MapTable = MapTable; 
            this.MapExist = MapExist; 
            this.MapRelated = MapRelated;
        }
    }
}
