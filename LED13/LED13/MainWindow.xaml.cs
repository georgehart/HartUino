using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
 
 /* kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk */
/* kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk */

/* zo maar wat brol en nog eens 
 * */
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Boolean toggle1 = true;
        public Boolean toggle2 = true;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.btn_Open.IsEnabled = false;
           
            this.btn_led_on.IsEnabled = false;
           
            this.cmb_Ports.Text = "Comm.Port";


            try
            {
                foreach (string comms in SerialPort.GetPortNames())
                {
                    cmb_Ports.Items.Add(comms);
                }
                if (cmb_Ports.Items.Count > 0)
                {
                    //cmb_Ports.SelectedIndex = 0;
                }
                else
                {
                    btn_Open.IsEnabled = false;
                }

            }
            catch(InvalidOperationException ex)
            {
                MessageBox.Show("Error: "+ ex);
            }
        }

        private void cmb_Ports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.btn_Open.IsEnabled = true;                     
        }

        private void btn_Open_Click(object sender, RoutedEventArgs e)
        {
            if (toggle1 == false)
            {
                btn_Open.Content = "Open Port";
                this.btn_led_on.IsEnabled = false;
                toggle1 = true;
            }
            else
            {
                // Poort is open

                btn_Open.Content = "Close Port";
                this.btn_led_on.IsEnabled = true;
                toggle1 = false;
            }
        }

        private void btn_led_on_Click(object sender, RoutedEventArgs e)
        {
            if (toggle2 == true)
            {
                btn_led_on.Content = "ON";
                toggle2 = false;
                btn_led_on.Background = Brushes.Green;
            }
            else
            {
                btn_led_on.Content = "OFF";
                toggle2 = true;
                btn_led_on.Background = Brushes.Red;
            }
        }   
                    
    }
}
