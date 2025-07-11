using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OfficeHelperWPF1.Models;
using OfficeHelperWPF1.ViewModels;

namespace OfficeHelperWPF1.Views
{
    /// <summary>
    /// Логика взаимодействия для EquipmentWindow.xaml
    /// </summary>
    public partial class EquipmentWindow : Window
    {
        /// <summary>
        /// DataContext у окна, связанного с изменением инвентаря
        /// </summary>
        public EquipmentWindowViewModel ViewModel { get; set; }
        /// <summary>
        /// Конструктор для создания окна добавления инвентаря
        /// </summary>
        public EquipmentWindow(string textButton)
        {
            InitializeComponent();
            ViewModel = new EquipmentWindowViewModel(textButton);
            DataContext = ViewModel;
        }
        /// <summary>
        /// Конструктор для создания окна изменения инвентаря
        /// </summary>
        /// <param name="officeEquipment">Изменяемый инвентарь</param>
        public EquipmentWindow(string textButton, OfficeEquipment officeEquipment)
        {
            InitializeComponent();
            ViewModel = new EquipmentWindowViewModel(textButton, officeEquipment);
            DataContext = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
