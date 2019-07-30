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
using System.Threading;

namespace HourseRaicing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool flag = false;
        static int numOfHorses = 0;
        int endOfRace = 500;
        Horse[] horses = new Horse[5];
        int h1p, h2p, h3p, h4p, h5p, h6p;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void hourseNumSld_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
            switch ((int)hourseNumSld.Value)
            {
                
                case 1:
                    if (flag == true)
                    {
                        h2.Visibility = Visibility.Hidden;
                        h3.Visibility = Visibility.Hidden;
                        h4.Visibility = Visibility.Hidden;
                        h5.Visibility = Visibility.Hidden;
                        h6.Visibility = Visibility.Hidden;             
                    }
                    break;
                case 2:
                    flag = true;
                    h3.Visibility = Visibility.Hidden;
                    h4.Visibility = Visibility.Hidden;
                    h5.Visibility = Visibility.Hidden;
                    h6.Visibility = Visibility.Hidden;
                    h1.Visibility = Visibility.Visible;
                    h2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    flag = true;
                    h4.Visibility = Visibility.Hidden;
                    h5.Visibility = Visibility.Hidden;
                    h6.Visibility = Visibility.Hidden;
                    h1.Visibility = Visibility.Visible;
                    h2.Visibility = Visibility.Visible;
                    h3.Visibility = Visibility.Visible;
                    break;
                case 4:
                    flag = true;
                    h5.Visibility = Visibility.Hidden;
                    h6.Visibility = Visibility.Hidden;
                    h1.Visibility = Visibility.Visible;
                    h2.Visibility = Visibility.Visible;
                    h3.Visibility = Visibility.Visible;
                    h4.Visibility = Visibility.Visible;
                    break;
                case 5:
                    flag = true;
                    h6.Visibility = Visibility.Hidden;
                    h1.Visibility = Visibility.Visible;
                    h2.Visibility = Visibility.Visible;
                    h3.Visibility = Visibility.Visible;
                    h4.Visibility = Visibility.Visible;
                    h5.Visibility = Visibility.Visible;
                    break;
                case 6:
                    flag = true;
                    h1.Visibility = Visibility.Visible;
                    h2.Visibility = Visibility.Visible;
                    h3.Visibility = Visibility.Visible;
                    h4.Visibility = Visibility.Visible;
                    h5.Visibility = Visibility.Visible;
                    h6.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void stBtn_Click(object sender, RoutedEventArgs e)
        {        
            numOfHorses = (int)hourseNumSld.Value;
            if (numOfHorses == 0)
            {
                horses[0] = new Horse();
                Thread thread1 = new Thread(() => ThreadStartingPoint(horses[0]));
                thread1.Start();
            }
            foreach (int num in Enumerable.Range(0,numOfHorses-1))
            {
                int loopnum = num;
                horses[num] = new Horse();
                Thread thread = new Thread(() => ThreadStartingPoint(horses[num]));
                thread.Start();
            }
            horses[numOfHorses - 1] = new Horse();
            Thread thread2 = new Thread(() => ThreadStartingPoint(horses[numOfHorses - 1]));
            thread2.Start();
            Thread guiThread = new Thread(() => guiThreadStart());
            guiThread.Start();

        }

      private void  ThreadStartingPoint(Horse h)
        {
            Random rnd = new Random();
            while (h.progress() != endOfRace)
            {          
                int t = rnd.Next(50, 150);
                Thread.Sleep(t);
                h.progress();

            }
        }

        private void guiThreadStart()
        {
            int i = 0;

            do
            {
                
                switch (numOfHorses)
                {
                    case 1:
                        h1p = horses[0].getProgess(horses[0]);
                        break;
                    case 2:
                        h1p = horses[0].getProgess(horses[0]);
                        h2p = horses[1].getProgess(horses[1]);
                        break;
                    case 3:
                        h1p = horses[1].getProgess(horses[1]);
                        h2p = horses[2].getProgess(horses[2]);
                        h3p = horses[0].getProgess(horses[0]);
                        break;
                    case 4:
                        h1p = horses[0].getProgess(horses[0]);
                        h2p = horses[1].getProgess(horses[1]);
                        h3p = horses[2].getProgess(horses[2]);
                        h4p = horses[3].getProgess(horses[3]);
                        break;
                    case 5:
                        h1p = horses[1].getProgess(horses[1]);
                        h2p = horses[2].getProgess(horses[2]);
                        h3p = horses[3].getProgess(horses[3]);
                        h4p = horses[4].getProgess(horses[4]);
                        h5p = horses[0].getProgess(horses[0]);
                        break;
                    case 6:
                        h1p = horses[1].getProgess(horses[1]);
                        h2p = horses[2].getProgess(horses[2]);
                        h3p = horses[3].getProgess(horses[3]);
                        h4p = horses[4].getProgess(horses[4]);
                        h5p = horses[5].getProgess(horses[5]);
                        h6p = horses[0].getProgess(horses[0]);
                        break;
                }
                Thread.Sleep(50);
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    h1.Margin = new Thickness(h1p, 109, 0, 31);
                    h2.Margin = new Thickness(h2p, 154, 0, 0);
                    h3.Margin = new Thickness(h3p, 25, 0, 0);
                    h4.Margin = new Thickness(h4p, 5, 0, 0);
                    h5.Margin = new Thickness(h5p, 0, 0, 44);
                    h6.Margin = new Thickness(h6p, 68, 0, 0);

                }));

                if (i == numOfHorses)
                    i = 0;
            } while (horses[i].getProgess(horses[i]) != endOfRace);

    
            }
        }
    }


