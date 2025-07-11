using System;
using System.Collections;
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
        /// <summary>
        /// Репозиторй для работы с БД
        /// </summary>
        private readonly OfficeEquipmentRepository _officeEquipmentRepository;
        /// <summary>
        /// Коллекция офисного оборудования, которую будет отображать ДатаГрид
        /// </summary>
        private ObservableCollection<OfficeEquipment> officeEquipmentList;


        /// <summary>
        /// Коллекция офисного оборудования
        /// </summary>
        public ObservableCollection<OfficeEquipment> OfficeEquipmentList
        {
            get
            {
                return officeEquipmentList;
            }
        }
        #region Команды
        #region OfficeEquipmentInsertCommand
        /// <summary>
        /// Команда добавления офисного оборудования в БД
        /// </summary>
        public ICommand OfficeEquipmentInsertCommand
        {
            get;
        }

        private bool CanOfficeEquipmentInsertCommandExecute(object p) => true;
        private void OnOfficeEquipmentInsertCommandExecuted(object p)
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
        /// <summary>
        /// Команда редактирования выбранного офисного оборудования
        /// </summary>
        public ICommand OfficeEquipmentUpdateCommand
        {
            get;
        }
        private bool CanOfficeEquipmentUpdateCommandExecute(object p) => true;
        private void OnOfficeEquipmentUpdateCommandExecuted(object selectedItem)
        {
            //приводим передаваемый SelectedItem к типу OfficeEquipment
            if (selectedItem is OfficeEquipment typedOfficeEquipment) 
            {
                EquipmentWindow equipmentWindow = new EquipmentWindow(typedOfficeEquipment);

                if (equipmentWindow.ShowDialog() == true)
                {
                    typedOfficeEquipment.Name = equipmentWindow.ViewModel.Name;
                    typedOfficeEquipment.Type = equipmentWindow.ViewModel.Type;
                    typedOfficeEquipment.Status = equipmentWindow.ViewModel.Status;

                    _officeEquipmentRepository.UpdateOfficeEquipment(typedOfficeEquipment);
                }
            }
        }
        #endregion
        #region OfficeEquipmentDeleteCommand
        /// <summary>
        /// Команда удаления выбранных офисных оборудований
        /// </summary>
        public ICommand OfficeEquipmentDeleteCommand
        {
            get;
        }

        public bool CanOfficeEquipmentDeleteCommandExecute(object p) => true;
        public void OnOfficeEquipmentDeleteCommandExecuted(object selectedItems)
        {
            // Приводим SelectedItems к ICollection
            ICollection typedCollectionOfSelectedItems = (ICollection)selectedItems; 

            if ( typedCollectionOfSelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите удаляемые элементы", "Ошибка", MessageBoxButton.OK);
                return;
            }

            // Приводим все элементы typedCollectionOfSelectedItems к OfficeEquipment и приводим саму коллекцию к List
            List<OfficeEquipment> typedOfficeEquipmentsToDelete = typedCollectionOfSelectedItems.Cast<OfficeEquipment>().ToList();            
            
            if (MessageBox.Show(
                $"Вы точно хотите удалить следующие элементы? (Количество удаляемых элементов: {typedOfficeEquipmentsToDelete.Count()} шт.)"
                , "Внимание"
                , MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _officeEquipmentRepository.DeleteOfficeEquipment(typedOfficeEquipmentsToDelete);
            }
        }

        #endregion
        #endregion

        public MainWindowViewModel()
        {
            _officeEquipmentRepository = new OfficeEquipmentRepository();
            officeEquipmentList = _officeEquipmentRepository.GetOfficeEquipment();

            #region Команды
            OfficeEquipmentInsertCommand = new LambdaCommand(OnOfficeEquipmentInsertCommandExecuted, CanOfficeEquipmentInsertCommandExecute);
            OfficeEquipmentUpdateCommand = new LambdaCommand(OnOfficeEquipmentUpdateCommandExecuted, CanOfficeEquipmentUpdateCommandExecute);
            OfficeEquipmentDeleteCommand = new LambdaCommand(OnOfficeEquipmentDeleteCommandExecuted, CanOfficeEquipmentDeleteCommandExecute);
            #endregion
        }
    }
}
