using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibMas;
using Lib11;

namespace pract2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private MyArray _myArray = new MyArray(5);

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int indexCoulumn = e.Column.DisplayIndex;
            _myArray[indexCoulumn] = int.Parse(((TextBox)e.EditingElement).Text);
        }

        public void Calculation_Click(object sender, RoutedEventArgs e)
        {
            diff.Clear();
            diff.Text = _myArray.DiffirenceOfMas();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Соколов К. ИСП-34", "Разработчик", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void FillplusArray_Click(object sender, RoutedEventArgs e)
        {
            diff.Clear();
            _myArray.FillplusArray_Click();
            dataGrid.ItemsSource = _myArray.ToDataTable().DefaultView;
        }
        private void FillminusArray_Click(object sender, RoutedEventArgs e)
        {
            diff.Clear();
            _myArray.FillminusArray_Click();
            dataGrid.ItemsSource = _myArray.ToDataTable().DefaultView;
        }

        private void ClearArray_Click(object sender, RoutedEventArgs e)
        {
            _myArray.Clear();
            diff.Clear();
            dataGrid.ItemsSource = _myArray.ToDataTable().DefaultView;

        }
        private void OpenArray_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Импорт массива";

            if (openFileDialog.ShowDialog() == true)
            {
                _myArray.Import(openFileDialog.FileName);
            }
            diff.Clear();
            dataGrid.ItemsSource = _myArray.ToDataTable().DefaultView;
        }

        private void SaveArray_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Экспорт массива";

            if (saveFileDialog.ShowDialog() == true)
            {
                _myArray.Export(saveFileDialog.FileName);
            }
            diff.Clear();
            dataGrid.ItemsSource = null;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
