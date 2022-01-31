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

namespace black
{
    /// <summary>
    /// Interaction logic for Masodik.xaml
    /// </summary>
    public partial class Masodik : Window
    {
        int elsosajat, masodiksajat, elsohaz, masodikhaz, sajato, hazo, tet = 0;
        int penzo = 2000;

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int tet;
                tet = Convert.ToInt32(bet.Text);
                penz.Content = tet;
                penzoL.Content = penzo -=  tet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            submit.Visibility = Visibility.Collapsed;
            bet.Visibility = Visibility.Collapsed;
            
        }

        public Masodik()
        {
            InitializeComponent();
            penzoL.Content = penzo;
        }

        private void teszt_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            elsosajat = r.Next(1,14);
            if (elsosajat == 1)
            {
                //ász
                elsosajat = 1;
            }
            else if (elsosajat > 10)
            {
                elsosajat = 10;
            }
            masodiksajat = r.Next(1, 14);
            if (masodiksajat == 1)
            {
                //ász
                masodiksajat = 1;
            }
            else if (masodiksajat > 10)
            {
                masodiksajat = 10;
            }
            sajato = elsosajat + masodiksajat;
            sajat.Content = sajato;

            //ház

            elsohaz = r.Next(1, 14);
            if (elsohaz == 1)
            {
                //ász
                elsohaz = 1;
            }
            else if (elsohaz > 10)
            {
                elsohaz = 10;
            }
            haz.Content = elsohaz;
        }
    }
}
