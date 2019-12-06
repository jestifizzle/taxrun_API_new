using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taxrun_API_new.Models
{
    public class MandateUser
    {
        public int MandateUserID { get; set; }
        public int UserGroupID { get; set; }
        public string Name { get; set; }
        public string UPN { get; set; }
    }
}
