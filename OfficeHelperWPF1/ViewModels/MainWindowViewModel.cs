using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeHelperWPF1.Data;
using OfficeHelperWPF1.Models;
using OfficeHelperWPF1.ViewModels.Base;

namespace OfficeHelperWPF1.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly OfficeHelperContext _context;
        public ObservableCollection<OfficeEquipment> OfficeEquipmentList
        {
            get
            {
                _context.Database.EnsureCreated();
                _context.OfficeEquipment.Load();
                return _context.OfficeEquipment.Local.ToObservableCollection();
            }
            //set;
        } //= new List<OfficeEquipment> { new() { Id = 1, Name = "some", Status = "s", Type = "t" }, new() { Id = 2, Name = "222", Status = "s2", Type = "t2" } };

        public MainWindowViewModel()
        {
            _context = new OfficeHelperContext();
        }
    }
}
