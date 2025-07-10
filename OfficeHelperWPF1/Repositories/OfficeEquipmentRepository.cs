using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeHelperWPF1.Data;
using OfficeHelperWPF1.Interfaces;
using OfficeHelperWPF1.Models;

namespace OfficeHelperWPF1.Repositories
{
    class OfficeEquipmentRepository : IOfficeEquipmentRepository
    {
        private readonly OfficeHelperContext _context; 

        public OfficeEquipmentRepository()
        {
            _context = new OfficeHelperContext();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public List<OfficeEquipment> GetOfficeEquipment()
        {
            return _context
                    .OfficeEquipment
                    .ToList();
        }

        public bool InsertOfficeEquipment(OfficeEquipment officeEquipment)
        {
            _context.OfficeEquipment.Add(officeEquipment);
            return Save();
        }
    }
}
