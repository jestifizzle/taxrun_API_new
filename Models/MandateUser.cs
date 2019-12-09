using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace taxrun_API_new.Models
{
    public class MandateUser
    {
        public int MandateUserID { get; set; }
        [Required]
        public int UserGroupID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string UPN { get; set; }
    }
}
