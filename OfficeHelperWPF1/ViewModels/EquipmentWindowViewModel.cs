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
        /// <summary>
        /// Название инвентаря
        /// </summary>
        public string Name
        {
            get; 
            set;
        }
        /// <summary>
        /// Тип инвентаря
        /// </summary>
        public string Type
        {
            get; 
            set;
        }
        /// <summary>
        /// Статус инвентаря
        /// </summary>
        public string Status
        {
            get; 
            set;
        }
        /// <summary>
        /// Конструктор для добавления инвентаря
        /// </summary>
        public EquipmentWindowViewModel()
        {
            Name = "";
            Type = "";
            Status = "";
        }
        /// <summary>
        /// Конструк для изменения инвентаря
        /// </summary>
        /// <param name="officeEquipment"></param>
        public EquipmentWindowViewModel(OfficeEquipment officeEquipment)
        {
            Name = officeEquipment.Name;
            Type = officeEquipment.Type;
            Status = officeEquipment.Status;
        }
    }
}
