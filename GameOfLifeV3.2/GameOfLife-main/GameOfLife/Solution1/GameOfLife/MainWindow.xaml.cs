using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void normalButton_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            if(counter <= 9)
            {
                Window1 normalGOL = new Window1();
                normalGOL.Show();
            }
        }

        private void colorButton_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            if (counter <= 9)
            {
                Window2 colorGOL = new Window2();
                colorGOL.Show();
            }
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}

// Ich will Äpfel