using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using taxrun_API_new.Models;

namespace taxrun_API_new.Databases
{
    public class MandateUserContext : DbContext 
    {
        public MandateUserContext(DbContextOptions<MandateUserContext> options) : base(options)
        {
        }

        public DbSet<MandateUser> MandateUsers { get; set; }
    }
}
