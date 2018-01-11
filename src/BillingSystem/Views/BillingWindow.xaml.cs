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
using System.Windows.Threading;
using System.ComponentModel;
using System.Collections.ObjectModel;
using BillingSystem.ViewModel;


namespace BillingSystem
{
    /// <summary>
    /// Interaction logic for BillingWindow.xaml
    /// </summary>
    public partial class BillingWindow : Window
    {
       private List<BillingViewModel> _dataSource = new List<BillingViewModel>();
       private BillingViewModel _objBillingViewModel = null;
       private double TotalPriceExclTax { get; set; }
       private double TotalPriceInclTax { get; set; }

        public BillingWindow()
        {

            InitializeComponent();
            InitilializeItemstoDataTable();
        }

        private void InitilializeItemstoDataTable()
        {
            _objBillingViewModel = new BillingViewModel();
            _dataSource= _objBillingViewModel.GetAllItems();

            dataSheet_Grid.ItemsSource = _dataSource.OrderBy(a => a.dataSheet_NAME);


        }



        private void dataSheet_Grid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var column = e.Column as DataGridBoundColumn;
                if (column != null)
                {
                    var bindingPath = (column.Binding as Binding).Path.Path;

                    if (bindingPath == "dataSheet_Quantity")
                    {
                        Update_Quantity_datasheet((e.EditingElement as TextBox).Text, e.Row);
                        calculate_Total_Price();
                        TotalExclTax_Text.Text = "Total Excl Tax \n" + TotalPriceExclTax.ToString();
                    }
                }
            }
        }

        private void Update_Quantity_datasheet(string quant, DataGridRow Row)
        {

            double editedValue = 0;
            int rowIndex_dataSource=0;
            for (int i = 0; i< _dataSource.Count; i++)
            {
             if (_dataSource[i].dataSheet_ID == (Row.Item as BillingViewModel).dataSheet_ID)
              {
                rowIndex_dataSource = i;
                break;
              }
            }
            if (double.TryParse(quant, out editedValue))
            {

                //_dataSource[(Row.Item as BillingViewModel).dataSheet_ID].dataSheet_Price = editedValue * (Row.Item as BillingViewModel).dataSheet_MRP;

                //_dataSource[(Row.Item as BillingViewModel).dataSheet_ID].dataSheet_Quantity = editedValue.ToString();

                _dataSource[rowIndex_dataSource].dataSheet_Price = editedValue * (Row.Item as BillingViewModel).dataSheet_MRP;

                _dataSource[rowIndex_dataSource].dataSheet_Quantity = editedValue.ToString();

               

            }
            else
            {
                MessageBox.Show("Invalid Entry", "Billing Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _dataSource[rowIndex_dataSource].dataSheet_Quantity = "0";
                _dataSource[rowIndex_dataSource].dataSheet_Price = 0;
            }
            dataSheet_Grid.ItemsSource = null;
            dataSheet_Grid.ItemsSource = _dataSource;

        }

        private void calculate_Total_Price()
        {
            TotalPriceExclTax = _dataSource.Where(x => x.dataSheet_Quantity != "0").Select(x => x.dataSheet_Price).Sum();
        
        }

        private void SearchItemName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                int i = 0;
                if (dataSheet_Grid.Items != null)
                {
                    foreach (object item in dataSheet_Grid.Items)
                    {
                        if ((item as BillingViewModel) != null && (((BillingViewModel)item).dataSheet_NAME.ToUpper().StartsWith(SearchItemName_TextBox.Text.ToUpper())))
                        {
                            dataSheet_Grid.ScrollIntoView(dataSheet_Grid.Items[dataSheet_Grid.Items.Count - 1]);
                            dataSheet_Grid.UpdateLayout();
                            dataSheet_Grid.ScrollIntoView(dataSheet_Grid.Items[i]);
                            dataSheet_Grid.CurrentItem = dataSheet_Grid.Items[i];
                           dataSheet_Grid.CurrentCell = new DataGridCellInfo(dataSheet_Grid.Items[i], dataSheet_Grid.Columns[4]);
                           dataSheet_Grid.BeginEdit();
                           Keyboard.Focus(SearchItemName_TextBox);
                         
                            break;


                        }
                        if ((item as BillingViewModel) != null && (((BillingViewModel)item).dataSheet_NAME.ToUpper().Equals(SearchItemName_TextBox.Text.ToUpper())))
                        {
                            dataSheet_Grid.ScrollIntoView(dataSheet_Grid.Items[dataSheet_Grid.Items.Count - 1]);
                            dataSheet_Grid.UpdateLayout();
                            dataSheet_Grid.ScrollIntoView(dataSheet_Grid.Items[i]);
                            dataSheet_Grid.CurrentCell = new DataGridCellInfo(dataSheet_Grid.Items[i], dataSheet_Grid.Columns[4]);
                            dataSheet_Grid.BeginEdit();
                            Keyboard.Focus(SearchItemName_TextBox);
                            //dataSheet_Grid.BeginEdit();
                            break;
                        }

                        i++;
                    }
                }

            }

           // Keyboard.Focus(SearchItemName_TextBox);
        }

       

       

      


    }
   
}
