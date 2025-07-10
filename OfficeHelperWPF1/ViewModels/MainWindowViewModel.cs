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

        private readonly OfficeEquipmentRepository _officeEquipmentRepository;
        public ObservableCollection<OfficeEquipment> OfficeEquipmentList
        {
            get
            {
                return _officeEquipmentRepository.GetOfficeEquipment();
            }
        }
        #region Команды
        #region OfficeEquipmentInsertCommand
        public ICommand OfficeEquipmentInsertCommand
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
        #region OfficeEquipmentUpdateCommand
        public ICommand OfficeEquipmentUpdateCommand
        {
            get;
        }
        private void OnOfficeEquipmentUpdateCommandExecuted(object officeEquipment)
        {
            OfficeEquipment typedOfficeEquipment = (OfficeEquipment)officeEquipment;
            EquipmentWindow equipmentWindow = new EquipmentWindow(typedOfficeEquipment);
            if (equipmentWindow.ShowDialog() == true)
            {
                typedOfficeEquipment.Name = equipmentWindow.ViewModel.Name;
                typedOfficeEquipment.Type = equipmentWindow.ViewModel.Type;
                typedOfficeEquipment.Status = equipmentWindow.ViewModel.Status;
                _officeEquipmentRepository.UpdateOfficeEquipment(typedOfficeEquipment);
            }
        }
        private bool CanOfficeEquipmentUpdateCommandExecute(object p) => true;
        #endregion
        #endregion
        public MainWindowViewModel()
        {
            _officeEquipmentRepository = new OfficeEquipmentRepository();
            #region Команды
            OfficeEquipmentInsertCommand = new LambdaCommand(OnOfficeEquipmentInsertCommandExecuted, CanOfficeEquipmentInsertCommandExecute);
            OfficeEquipmentUpdateCommand = new LambdaCommand(OnOfficeEquipmentUpdateCommandExecuted, CanOfficeEquipmentUpdateCommandExecute);
            #endregion
        }
    }
}
