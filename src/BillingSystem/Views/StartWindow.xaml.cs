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

namespace BillingSystem
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            this.Cursor = Cursors.Arrow;
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                MainOptionsWindow objMainOptionsWindow = new MainOptionsWindow();
                objMainOptionsWindow.ShowDialog();
                //objLoginWindow = null;
                //MainWindow objMainWindow = new MainWindow();
                //objMainWindow.ShowDialog();
                //objMainWindow = null;
                this.Close();
                this.Dispatcher.InvokeShutdown();
            }
            catch(Exception)
            {

            }
        }

    }
}
