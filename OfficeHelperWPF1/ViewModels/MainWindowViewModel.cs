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
using OfficeHelperWPF1.Repositories;
using OfficeHelperWPF1.ViewModels.Base;
using OfficeHelperWPF1.Views;

namespace OfficeHelperWPF1.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly OfficeHelperContext _context;
        private readonly OfficeEquipmentRepository _officeEquipmentRepository;
        public ObservableCollection<OfficeEquipment> OfficeEquipmentList
        {
            get
            {
                return _officeEquipmentRepository.GetOfficeEquipment();
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
                _officeEquipmentRepository.InsertOfficeEquipment(new OfficeEquipment() 
                { 
                    Name = equipmentWindow.ViewModel.Name,
                    Status = equipmentWindow.ViewModel.Status, 
                    Type = equipmentWindow.ViewModel.Type
                });
            }
        }
        #endregion
        #endregion
        public MainWindowViewModel()
        {
            _context = new OfficeHelperContext();
            _officeEquipmentRepository = new OfficeEquipmentRepository();
            #region Команды
            OfficeEquipmentInsert = new LambdaCommand(OnOfficeEquipmentInsertCommandExecuted, CanOfficeEquipmentInsertCommandExecute);
            #endregion
        }
    }
}
