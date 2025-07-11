using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OfficeHelperWPF1.Models
{
    public class OfficeEquipment : INotifyPropertyChanged
    {
        private string? name;
        private string? type;
        private string? status;

        /// <summary>
        /// ID офисного оборудования
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название офисного оборудования
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                if (value == null || value == "") 
                { 
                    throw new Exception("Вы не указали название офисного оборудования"); 
                }
                name = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Тип офисного оборудования
        /// </summary>
        public string Type
        {
            get => type;
            set
            {
                if (value != "Принтер"
                    && value != "Сканер"
                    && value != "Монитор")
                {
                    throw new Exception($"Вы указали неправильный тип офисного оборудование({value})");
                }
                type = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// Статус офисного оборудования
        /// </summary>
        public string Status
        {
            get => status;
            set
            {
                if (value != "В пользовании"
                    && value != "На складе"
                    && value != "В ремонте")
                {
                    throw new Exception($"Вы указали неправильный статус офисного оборудование({value})");
                }
                status = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
