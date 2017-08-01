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
    /// Interaction logic for MainOptionsWindow.xaml
    /// </summary>
    public partial class MainOptionsWindow : Window
    {
        public MainOptionsWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }



        void timer_Tick(object sender, EventArgs e)
        {
          
            datetime_textblock.Text = DateTime.Now.ToLongTimeString() + "\n" +DateTime.Now.ToLongDateString();
        }

        private void Administraton_button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow objAdminWindow = new AdminWindow();
            objAdminWindow.ShowDialog();
        }

        private void Billing_Button_Click(object sender, RoutedEventArgs e)
        {
             
                BillingWindow objBillingWindow = new BillingWindow();
                objBillingWindow.ShowDialog();
             
        }

        private void Report_Button_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow objReportWindow = new ReportWindow();
            objReportWindow.ShowDialog();
        }
    }
}
