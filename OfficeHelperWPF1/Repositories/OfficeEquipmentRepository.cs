using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            _context.Database.EnsureCreated();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public ObservableCollection<OfficeEquipment> GetOfficeEquipment()
        {
            _context.OfficeEquipment.Load();
            return _context.OfficeEquipment.Local.ToObservableCollection();
        }

        public bool InsertOfficeEquipment(OfficeEquipment officeEquipment)
        {
            _context.OfficeEquipment.Add(officeEquipment);
            GetOfficeEquipment();
            return Save();
        }

        public bool UpdateOfficeEquipment(OfficeEquipment officeEquipment)
        {
            _context.Update(officeEquipment);
            return Save();
        }
    }
}
