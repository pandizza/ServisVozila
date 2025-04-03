using ServisVozila.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServisVozila.Views
{
    /// <summary>
    /// Interaction logic for UplataIsplataView.xaml
    /// </summary>
    public partial class VozilaView : UserControl
    {
        private ObservableCollection<VrstaGoriva> _vrsteGoriva;
        private ObservableCollection<VrstaServisa> _vrsteServisa;
        private ObservableCollection<Servisi> _servisi;
        private ObservableCollection<Materijal> _materijal;

        public VozilaView(VozilaViewModel viewModel)
        {
            InitializeComponent();

            if (DataContext == null)
            {
                DataContext = viewModel;
            }

        }

        public void InitData(
                    ObservableCollection<Vozila> vozila,
                    ObservableCollection<KilometrazaVozila> kilometraza,
                    ObservableCollection<VrstaGoriva> vrsteGoriva,
                    ObservableCollection<Servisi> servisi,
                    ObservableCollection<AlarmiVozila> alarmi,
                    ObservableCollection<RegistracijaVozila> registracije,
                    ObservableCollection<Materijal> materijal,
                    ObservableCollection<VrstaServisa> vrsteServisa)
        {
            _vrsteGoriva = vrsteGoriva;
            _vrsteServisa = vrsteServisa;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtSearch.Focus();
            txtSearch.SelectAll();

        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Ctrl + F is pressed
            if (e.Key == Key.F && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                // Set focus to the txtSearch TextBox
                txtSearch.Focus();
                txtSearch.SelectAll();
            }
        }



        private void SetRowFocus(DataGrid dataGrid, int index)
        {
            var selectedRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(index);
            if (selectedRow == null) return;

            // Get the selected row as a data item
            var selectedRow_ = dataGrid.SelectedItem;

            // Get the first column's cell value
            var cellValue = (dataGrid.Columns[0].GetCellContent(selectedRow) as TextBlock)?.Text;

            // Get the selected row index
            int rowIndex = dataGrid.Items.IndexOf(dataGrid.SelectedItem);

            // Get the cell container for the first column (index 0)
            DataGridCell cell = GetCell(dataGrid, rowIndex, 0);


            FocusManager.SetIsFocusScope(cell, true);
            FocusManager.SetFocusedElement(cell, cell);
        }

        // Helper method to get a DataGridCell
        private DataGridCell GetCell(DataGrid dataGrid, int rowIndex, int columnIndex)
        {
            // Get the row container
            DataGridRow row = GetRow(dataGrid, rowIndex);
            if (row == null) return null;

            // Find the cell in the row
            DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
            if (presenter == null) return null;

            // Get the cell at the specified column index
            DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex) as DataGridCell;
            return cell;
        }

        // Helper method to get a DataGridRow
        private DataGridRow GetRow(DataGrid dataGrid, int rowIndex)
        {
            if(rowIndex == -1) rowIndex = 0;
            return dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
        }

        // Helper method to find a visual child of a specific type
        private T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child is T tChild)
                {
                    return tChild;
                }
                T childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
            return null;
        }

        //private void dgKonta_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    var dataGrid = sender as DataGrid;
        //    if (dataGrid?.SelectedItem != null)
        //    {
        //        var viewModel = DataContext as VozilaViewModel;
        //        viewModel.SelectedKontoRecord = dataGrid.SelectedItem as KontoDT;
        //    }
        //}

        //private void dgKonta_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        var dataGrid = sender as DataGrid;
        //        if (dataGrid?.SelectedItem != null)
        //        {
        //            var viewModel = DataContext as VozilaViewModel;
        //            viewModel.SelectedKontoRecord = dataGrid.SelectedItem as KontoDT;
        //        }
        //        e.Handled = true;
        //    }
        //}

        private void cbVrstePrometaBlagajna_Loaded(object sender, RoutedEventArgs e)
        {
            //cbVrstePrometaBlagajna.Text = "Ostale uplate";
        }

        private void cbVrstePrometaBlagajna_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDodajVozilo_Click(object sender, RoutedEventArgs e)
        {
            DodajVoziloWindow dvw = new DodajVoziloWindow(_vrsteGoriva);
            dvw.ShowDialog();

            if (dvw.VoziloAdded)
            {
                if (DataContext is VozilaViewModel vm)
                {
                    vm.ReloadVozila(); // Call method from ViewModel
                }
            }
        }

        private void btnServis_Click(object sender, RoutedEventArgs e)
        {
            DodajServisWindow dvw = new DodajServisWindow(_vrsteServisa);
            dvw.ShowDialog();

            //if (dvw.VoziloAdded)
            //{
            //    if (DataContext is VozilaViewModel vm)
            //    {
            //        vm.ReloadVozila(); // Call method from ViewModel
            //    }
            //}
        }
    }
}
