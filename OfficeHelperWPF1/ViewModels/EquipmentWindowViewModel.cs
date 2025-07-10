using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeHelperWPF1.Models;

namespace OfficeHelperWPF1.ViewModels
{
    public class EquipmentWindowViewModel
    {
        public string Name
        {
            get; 
            set;
        }
        public string Type
        {
            get; 
            set;
        }
        public string Status
        {
            get; 
            set;
        }

        public EquipmentWindowViewModel()
        {
            Name = "";
            Type = "";
            Status = "";
        }
        public EquipmentWindowViewModel(OfficeEquipment officeEquipment)
        {
            Name = officeEquipment.Name;
            Type = officeEquipment.Type;
            Status = officeEquipment.Status;
        }
    }
}
