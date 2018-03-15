using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PD.Util
{
    public class PDService : CommonService
    {
        public PDService() : base("GameProfession", "ID") { }
        public PDService(string t, string f) : base(t, f) { }

    }
}
