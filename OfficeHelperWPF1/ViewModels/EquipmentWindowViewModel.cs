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
        /// Текст кнопки
        /// </summary>
        public string ButtonText
        {
            get;
            set;
        }
        /// <summary>
        /// Конструктор для создания модального окна инвентаря
        /// </summary>
        /// <param name="buttonText">Текст кнопки</param>
        public EquipmentWindowViewModel(string buttonText)
        {
            Name = "";
            Type = "";
            Status = "";
            ButtonText = buttonText;
        }
        /// <summary>
        /// Конструктор для создания модального окна инвентаря
        /// </summary>
        /// <param name="buttonText">Текст кнопки</param>
        /// <param name="officeEquipment">Офисное оборудование, которое будет отображено в окне</param>
        public EquipmentWindowViewModel(string buttonText,OfficeEquipment officeEquipment)
        {
            Name = officeEquipment.Name;
            Type = officeEquipment.Type;
            Status = officeEquipment.Status;
            ButtonText = buttonText;
        }
    }
}
