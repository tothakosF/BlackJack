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
        int sajato, hazo, tet, lap = 0;
        int penzo = 2000;
        Random r = new Random();
        int[] hazlap = {0, 0, 0, 0, 0};
        int[] sajatlap = { 0, 0, 0, 0, 0};
        int i = 2;
        int x = 1;
        int y = 2;
        public void ujlap()
        {
            lap = r.Next(1, 14);
            if (lap == 1)
            {
                //ász
                lap = 1;
            }
            else if (lap > 10)
            {
                lap = 10;
            }
        }
        public void huszonegy(bool win)
        {
            string text = win ? "Nyertél :)" : "Vesztettél :(";
            MessageBox.Show(text);
            //Új if
            if (win == true)
            {
                penzoL.Content = penzo += tet*2;
            }
           
            
            /*MainWindow subWindow = new MainWindow();
            subWindow.Show();
            MasodikW.Close();*/
            Double.Visibility = Visibility.Collapsed;
            Hit.Visibility = Visibility.Collapsed;
            Stand.Visibility = Visibility.Collapsed;
            Split.Visibility = Visibility.Collapsed;
            submit.Visibility = Visibility.Visible;
            bet.Visibility = Visibility.Visible;
            tet1.Visibility = Visibility.Visible;
            bet.Text = "";
            sajat.Content = "";
            haz.Content = "";
            sajato = 0;
            penz.Content = "";
            hazo = 0;
            i = 2;
            x = 1;
            y = 2;
        }
        public void submit_Click(object sender, RoutedEventArgs e)
        {
            Split.IsEnabled = false;
            for (int i = 0; i < 5; i++)
            {
                lap = r.Next(1, 14);
                if (lap > 10)
                {
                    lap = 10;
                }
                sajatlap[i] = lap;
            }
            sajato = sajatlap[0] + sajatlap[1];
            sajat.Content = sajatlap[0] + "+" + sajatlap[1];

            //ház
            for (int i = 0; i < 5; i++)
            {
                lap = r.Next(1, 14);
                if (lap > 10)
                {
                    lap = 10;
                }
                hazlap[i] = lap;
            }

            hazo = hazlap[0] + hazlap[1];
            haz.Content = hazlap[0];

            tet1.Visibility = Visibility.Collapsed;
            submit.Visibility = Visibility.Collapsed;
            bet.Visibility = Visibility.Collapsed;
            Double.Visibility = Visibility.Visible;
            Hit.Visibility = Visibility.Visible;
            Stand.Visibility = Visibility.Visible;
            Split.Visibility = Visibility.Visible;
            try
            {
                tet = Convert.ToInt32(bet.Text);
                penz.Content = tet;
                penzoL.Content = penzo -=  tet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Double.Visibility = Visibility.Collapsed;
                Hit.Visibility = Visibility.Collapsed;
                Stand.Visibility = Visibility.Collapsed;
                Split.Visibility = Visibility.Collapsed;
                submit.Visibility = Visibility.Visible;
                bet.Visibility = Visibility.Visible;
                tet1.Visibility = Visibility.Visible;
            }
        }

        private void bet_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (bet.Text != "")
            {
                try
                {
                    tet = Convert.ToInt32(bet.Text);
                    if (penzo - tet < 1)
                    {
                        submit.IsEnabled = false;
                    }
                    else
                    {
                        submit.IsEnabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public Masodik()
        {
            InitializeComponent();
            penzoL.Content = penzo;
        }

        private void Stand_Click(object sender, RoutedEventArgs e)
        {
            if (x == 1)
            {
                haz.Content += "+" + hazlap[x];
                x++;
            }
            if (hazo < 17)
            {
                do
                {
                    hazo += hazlap[y];
                    haz.Content += "+" + hazlap[y];
                    y++;
                    if (hazo > 21)
                    {
                        huszonegy(true);
                    }
                } while (y < 4);
            }
            if (hazo > 21)
            {
                huszonegy(false);
            }
            if (hazo > 16)
            {
                if (hazo > sajato)
                {
                    huszonegy(false);
                }
                if (sajato > hazo)
                {
                    huszonegy(true);
                }
                if (hazo == sajato)
                {
                    penzo += tet;
                    
                }
            }
        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                sajato += sajatlap[i];
                sajat.Content += "+" + sajatlap[i];
                i++;
                if (sajato > 21)
                {
                    huszonegy(false);
                }
            } while (i > 4);
        }
    }
}
