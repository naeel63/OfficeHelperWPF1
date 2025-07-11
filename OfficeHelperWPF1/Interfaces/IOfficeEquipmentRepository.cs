using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeHelperWPF1.Models;

namespace OfficeHelperWPF1.Interfaces
{
    public interface IOfficeEquipmentRepository
    {
        public ObservableCollection<OfficeEquipment> GetOfficeEquipment();
        public bool Save();
        public bool InsertOfficeEquipment(OfficeEquipment officeEquipment);
        public bool UpdateOfficeEquipment(OfficeEquipment officeEquipment);
        public bool DeleteOfficeEquipment(List<OfficeEquipment> officeEquipmentList);
    }
}
