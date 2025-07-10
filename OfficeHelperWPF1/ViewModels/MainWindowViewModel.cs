using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using OfficeHelperWPF1.Data;
using OfficeHelperWPF1.Infrastructure.Commands;
using OfficeHelperWPF1.Models;
using OfficeHelperWPF1.ViewModels.Base;
using OfficeHelperWPF1.Views;

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
        }
        #region Команды
        #region OfficeEquipmentInsert
        public ICommand OfficeEquipmentInsert
        {
            get;
        }

        private bool CanOfficeEquipmentInsertCommandExecute(object p) => true;
        private void OnOfficeEquipmentInsertCommandExecuted(object officeEquipment)
        {
            EquipmentWindow equipmentWindow = new EquipmentWindow();

            if (equipmentWindow.ShowDialog() == true)
            {

            }
        }
        #endregion
        #endregion
        public MainWindowViewModel()
        {
            _context = new OfficeHelperContext();
            #region Команды
            OfficeEquipmentInsert = new LambdaCommand(OnOfficeEquipmentInsertCommandExecuted, CanOfficeEquipmentInsertCommandExecute);
            #endregion
        }
    }
}
