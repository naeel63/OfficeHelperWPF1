using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeHelperWPF1.Models;
using OfficeHelperWPF1.ViewModels.Base;

namespace OfficeHelperWPF1.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        public List<OfficeEquipment> OfficeEquipment
        {
            get;
            set;
        } = new List<OfficeEquipment> { new() { Id = 1, Name = "some", Status = "s", Type = "t" }, new() { Id = 2, Name = "222", Status = "s2", Type = "t2" } };
    }
}
