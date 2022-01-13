using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameOfLife
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        

        public Window1()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += TimerTick;
        }


        const int fieldHeight = 40;
        const int fieldWidth = 40;

        Rectangle[,] rectangles = new Rectangle[fieldHeight, fieldWidth];

        DispatcherTimer timer = new DispatcherTimer();

        public bool filled = false;

        private void TimerTick(object sender, EventArgs e)
        {
            moveForward();
        }

        public void startGame()
        {
            if (!filled)
            {
                filled = true;
                for (int i = 0; i < fieldHeight; i++)
                {
                    for (int j = 0; j < fieldWidth; j++)
                    {
                        Rectangle rect = new Rectangle();
                        //Größe von jedem Rechteck festlegen:
                        rect.Height = gameArea.ActualHeight / fieldHeight - 1.0;
                        rect.Width = gameArea.ActualWidth / fieldWidth - 1.0;

                        //Rechtecken eine Farbe geben:
                        rect.Fill = Brushes.Blue;

                        //Feld befüllen
                        gameArea.Children.Add(rect);

                        //Abstand zwischen jedem Kästchen setzten
                        Canvas.SetTop(rect, i * gameArea.ActualHeight / fieldHeight);
                        Canvas.SetLeft(rect, j * gameArea.ActualWidth / fieldWidth);

                        rect.MouseDown += Rect_MouseDown;

                        rectangles[i, j] = rect;

                    }
                }
            }
            else
            {
                timer.Start();
                Console.WriteLine("Field is already filled");
            }
        }

        public void moveForward()
        {
            int[,] neighborcounter = new int[fieldHeight, fieldWidth];
            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    int neighbors = 0;

                    int iUP = i - 1;
                    if (iUP < 0) iUP = fieldHeight - 1;

                    int iDOWN = i + 1;

                    if (iDOWN >= fieldHeight) iDOWN = 0;

                    int jLEFT = j - 1;
                    if (jLEFT < 0) jLEFT = fieldWidth - 1;

                    int jRIGHT = j + 1;
                    if (jRIGHT >= fieldWidth) jRIGHT = 0;

                    if (rectangles[iUP, jLEFT].Fill == Brushes.Crimson) neighbors++;   //Left UP
                    if (rectangles[iUP, j].Fill == Brushes.Crimson) neighbors++;       //UP
                    if (rectangles[iUP, jRIGHT].Fill == Brushes.Crimson) neighbors++;   //Right UP
                    if (rectangles[i, jLEFT].Fill == Brushes.Crimson) neighbors++;       //LEFT
                    if (rectangles[i, jRIGHT].Fill == Brushes.Crimson) neighbors++;       //RIGHT
                    if (rectangles[iDOWN, jLEFT].Fill == Brushes.Crimson) neighbors++;   //Left DOWN
                    if (rectangles[iDOWN, j].Fill == Brushes.Crimson) neighbors++;       //DOWN
                    if (rectangles[iDOWN, jRIGHT].Fill == Brushes.Crimson) neighbors++;   //Right DOWN

                    neighborcounter[i, j] = neighbors;
                }
            }

            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    if (neighborcounter[i, j] < 2 || neighborcounter[i, j] > 3)
                    {
                        rectangles[i, j].Fill = Brushes.Blue;
                    }
                    else if (neighborcounter[i, j] == 3)
                    {
                        rectangles[i, j].Fill = Brushes.Crimson;
                    }
                }

            }
        }



        public void clearField()
        {
            if (filled)
            {
                gameArea.Children.Clear();
                filled = false;
            }
            else
            {
                Console.WriteLine("The field isn't filled yet !");
            }
        }
        public bool isFilled()
        //NOT USED USELESS (for now)
        {
            if (filled)
            {
                return true;  //NOT USED USELESS (for now)

            }
            else
            {
                return false;  //NOT USED USELESS (for now)

            }
        }
        //NOT USED USELESS (for now)


        public void saveTxt()
        {

            //Soll später implementiert werden um das vorhandene Spielfeld in einer Textdatei oder CSV-Datei zu speichern
            //Leere Felder mit 0 und befüllte Felder mit 1 speichern

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save";
            saveDialog.Filter = "Textfiles (*.csv;*.txt)|*.csv;*.txt";
            if (saveDialog.ShowDialog() == true)
            {
                string file = saveDialog.FileName;

                using (StreamWriter sw = File.CreateText(file))
                {
                    for (int i = 0; i < fieldHeight; i++)
                    {
                        for (int j = 0; j < fieldWidth; j++)
                        {
                            if (rectangles[i, j].Fill == Brushes.Blue)
                            {
                                sw.WriteLine("0");
                            }
                            else if (rectangles[i, j].Fill == Brushes.Crimson)
                            {
                                sw.WriteLine("1");
                            }
                        }


                    }
                }

            }




            pause();
        }

        public void saveImage()
        {

            //Soll später implementiert werden um das vorhandene Spielfeld als ein PNG zu speichern
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save";
            saveDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";
            if (saveDialog.ShowDialog() == true)
            {
                string file = saveDialog.FileName;
                SaveToPng(gameArea, file);
            }
            pause();
        }

        public void SaveToPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            EncodeVisual(visual, fileName, encoder);
        }

        private static void EncodeVisual(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight + 100, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = File.Create(fileName)) encoder.Save(stream);
        }

        private void randomize()
        {
            Random rnd = new Random();
            int num1 = rnd.Next(1,41);
            int num2 = rnd.Next(1,41);       
            if (num1 < fieldHeight && num2 < fieldWidth)
            {
               rectangles[num1, num2].Fill = Brushes.Crimson;
            }
        }
        
        public void loadTxt()
        {
            //Soll eine vorhandene Textdatei einlesen können und es auf dem Spielfeld wiederspiegeln
            OpenFileDialog openFileDlg = new OpenFileDialog();



            openFileDlg.Filter = "Textfiles (*.csv;*.txt)|*.csv;*.txt";
            if (openFileDlg.ShowDialog() == true)
            {
                string file = openFileDlg.FileName;
                using (StreamReader sr = File.OpenText(file))
                {


                    for (int i = 0; i < fieldHeight; i++)
                    {
                        for (int j = 0; j < fieldWidth; j++)
                        {
                            string s = sr.ReadLine();
                            if (s == "0")
                            {
                                rectangles[i, j].Fill = Brushes.Blue;
                            }
                            else if (s == "1")
                            {
                                rectangles[i, j].Fill = Brushes.Crimson;
                            }
                        }


                    }
                }


            }
            pause();
        }

        public void pause()
        {
            //Ist dafür da um das Spielfeld zu pausieren erst wenn das Spiel pausiert ist kann das Feld gespeichert wereden
            timer.Stop();
        }

        

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            startGame();
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            clearField();
        }
        private void Rect_MouseDown(object rect, MouseButtonEventArgs e)
        {
           
            ((Rectangle)rect).Fill = (((Rectangle)rect).Fill == Brushes.Blue) ? Brushes.Crimson : Brushes.Blue;
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            pause();
        }

        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            moveForward();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            loadTxt();
        }

        
        private void randomButton_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfRandom.Text == "") {
                randomize();

            }
            else {

                for (int i = 0; i < int.Parse(numberOfRandom.Text); i++)
                {
                    randomize();
                }
            }
        }

        

        private void saveImageButton_Click(object sender, RoutedEventArgs e)
        {
            saveImage();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            saveTxt();
        }
    }
}
// Ich will Äpfel