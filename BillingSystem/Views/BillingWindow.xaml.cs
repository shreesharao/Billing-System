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
namespace BillingSystem
{
    /// <summary>
    /// Interaction logic for BillingWindow.xaml
    /// </summary>
    public partial class BillingWindow : Window
    {
        //public DateTime CurrentDateAndTime { get; set; }
        //public event PropertyChangedEventHandler PropertyChanged;


        //ObservableCollection<billRow> itemRow;

        ObservableCollection<BillingAtributes> dataSource = new ObservableCollection<BillingAtributes>();
        
        double TotalPriceExclTax{get;set;}
        double TotalPriceInclTax{get;set;}
        public BillingWindow()
        {

            InitializeComponent();
            InitilializeItemstoDataTable();
           // SearchItem_TextBoc.Text = "etem_43";
            //(dataSheet_Grid.ItemsSource as DataView).Sort = "NAME_OF_COLUMN";
        }

        private void InitilializeItemstoDataTable()
        {
            // dataSource.CollectionChanged+=dataSource_CollectionChanged;
            //dataSheet_Grid.CellEditEnding+=dataSheet_Grid_CellEditEnding;

            for (int i = 0; i < 10000; i++)
            {
                if (i < 10)
                {
                    if (i<10)
                    dataSource.Add(new BillingAtributes()
                    {
                        dataSheet_SN = i,
                        dataSheet_ID = i,
                        dataSheet_MRP = 100,
                        dataSheet_NAME = "Atem_" + i,
                        dataSheet_Quantity = "0",
                    });
                 
                 
                }
                if (i>10 && i < 20)
                {
                    dataSource.Add(new BillingAtributes()
                    {
                        dataSheet_SN = i,
                        dataSheet_ID = i,
                        dataSheet_MRP = 100,
                        dataSheet_NAME = "Btem_" + i,
                        dataSheet_Quantity = "0",
                    });
                }
                if (i > 20 &&  i < 30)
                {
                    dataSource.Add(new BillingAtributes()
                    {
                        dataSheet_SN = i,
                        dataSheet_ID = i,
                        dataSheet_MRP = 100,
                        dataSheet_NAME = "Ctem_" + i,
                        dataSheet_Quantity = "0",
                    });
                }
                if (i > 30 &&  i < 40)
                {
                    dataSource.Add(new BillingAtributes()
                    {
                        dataSheet_SN = i,
                        dataSheet_ID = i,
                        dataSheet_MRP = 100,
                        dataSheet_NAME = "Dtem_" + i,
                        dataSheet_Quantity = "0",
                    });
                }
                if (i > 40 &&  i < 50)
                {
                    dataSource.Add(new BillingAtributes()
                    {
                        dataSheet_SN = i,
                        dataSheet_ID = i,
                        dataSheet_MRP = 100,
                        dataSheet_NAME = "Etem_" + i,
                        dataSheet_Quantity = "0",
                    });
                }
                if (i > 50 &&  i < 60)
                {
                    dataSource.Add(new BillingAtributes()
                    {
                        dataSheet_SN = i,
                        dataSheet_ID = i,
                        dataSheet_MRP = 100,
                        dataSheet_NAME = "Ftem_" + i,
                        dataSheet_Quantity = "0",
                    });
                }


            }
            dataSource = new ObservableCollection<BillingAtributes>(dataSource.OrderBy(a => a.dataSheet_NAME));
            dataSheet_Grid.ItemsSource = dataSource;


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
            int rowIndexDataSource=0;
            for (int i = 0; i< dataSource.Count; i++)
            {
             if (dataSource[i].dataSheet_ID == (Row.Item as BillingAtributes).dataSheet_ID)
              {
                rowIndexDataSource = i;
                break;
              }
            }
            if (double.TryParse(quant, out editedValue))
            {

                //dataSource[(Row.Item as BillingAtributes).dataSheet_ID].dataSheet_Price = editedValue * (Row.Item as BillingAtributes).dataSheet_MRP;

                //dataSource[(Row.Item as BillingAtributes).dataSheet_ID].dataSheet_Quantity = editedValue.ToString();

                dataSource[rowIndexDataSource].dataSheet_Price = editedValue * (Row.Item as BillingAtributes).dataSheet_MRP;

                dataSource[rowIndexDataSource].dataSheet_Quantity = editedValue.ToString();

               

            }
            else
            {
                MessageBox.Show("Invalid Entry", "Billing Error", MessageBoxButton.OK, MessageBoxImage.Error);
                dataSource[rowIndexDataSource].dataSheet_Quantity = "0";
                dataSource[rowIndexDataSource].dataSheet_Price = 0;
            }
            dataSheet_Grid.ItemsSource = null;
            dataSheet_Grid.ItemsSource = dataSource;

        }

        private void calculate_Total_Price()
        {
            TotalPriceExclTax = dataSource.Where(x => x.dataSheet_Quantity != "0").Select(x => x.dataSheet_Price).Sum();
        
        }

        private void SearchItemName_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                int i = 0;
                if (dataSheet_Grid.Items != null)
                {
                    foreach (object item in dataSheet_Grid.Items)
                    {
                        if ((item as BillingAtributes) != null && (((BillingAtributes)item).dataSheet_NAME.ToUpper().StartsWith(SearchItemName_TextBox.Text.ToUpper())))
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
                        if ((item as BillingAtributes) != null && (((BillingAtributes)item).dataSheet_NAME.ToUpper().Equals(SearchItemName_TextBox.Text.ToUpper())))
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
    public class BillingAtributes
    {
        public int dataSheet_SN { get; set; }
        public int dataSheet_ID { get; set; }
        public string dataSheet_NAME { get; set; }
        public double dataSheet_MRP { get; set; }
        public string dataSheet_Quantity { get; set; }
        public double dataSheet_Price { get; set; }
        public BillingAtributes()
        {
            dataSheet_Price = 0;
        }

    }
}
