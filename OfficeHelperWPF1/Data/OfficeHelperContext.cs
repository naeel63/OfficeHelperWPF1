using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeHelperWPF1.Models;

namespace OfficeHelperWPF1.Data
{
    class OfficeHelperContext: DbContext
    {
        public DbSet<OfficeEquipment> OfficeEquipment { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=OfficeHelper.db");
        }
    }
}
