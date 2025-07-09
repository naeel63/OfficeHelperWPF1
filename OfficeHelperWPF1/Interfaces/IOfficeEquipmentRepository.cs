using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeHelperWPF1.Models;

namespace OfficeHelperWPF1.Interfaces
{
    public interface IOfficeEquipmentRepository
    {
        public List<OfficeEquipment> GetOfficeEquipment();
        
    }
}
