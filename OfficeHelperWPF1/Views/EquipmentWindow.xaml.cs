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
        public EquipmentWindowViewModel ViewModel { get; set; }
        public EquipmentWindow()
        {
            InitializeComponent();
            ViewModel = new EquipmentWindowViewModel();
            DataContext = ViewModel;
        }

        public EquipmentWindow(OfficeEquipment officeEquipment)
        {
            InitializeComponent();
            ViewModel = new EquipmentWindowViewModel(officeEquipment);
            DataContext = ViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
