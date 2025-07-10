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
        public bool InsertOfficeEquipment(OfficeEquipment officeEquipment);
    }
}
