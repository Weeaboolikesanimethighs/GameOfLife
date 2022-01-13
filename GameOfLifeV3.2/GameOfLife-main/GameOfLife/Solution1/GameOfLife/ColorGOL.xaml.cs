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
    public partial class Window2 : Window
    {


        public Window2()
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
                        rect.Fill = Brushes.White;

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
            int[,] neighborcounterBlue = new int[fieldHeight, fieldWidth];
            int[,] neighborcounterGreen = new int[fieldHeight, fieldWidth];
            int[,] neighborcounterBrown = new int[fieldHeight, fieldWidth];
            int[,] neighborcounterBlack = new int[fieldHeight, fieldWidth];


            for (int i = 0; i < fieldHeight; i++)
            {
                for (int j = 0; j < fieldWidth; j++)
                {
                    int neighbors = 0;
                    int neighborsBlue = 0;
                    int neighborsGreen = 0;
                    int neighborsBrown = 0;
                    int neighborsBlack = 0;


                    int iUP = i - 1;
                    if (iUP < 0) iUP = fieldHeight - 1;

                    int iDOWN = i + 1;

                    if (iDOWN >= fieldHeight) iDOWN = 0;

                    int jLEFT = j - 1;
                    if (jLEFT < 0) jLEFT = fieldWidth - 1;

                    int jRIGHT = j + 1;
                    if (jRIGHT >= fieldWidth) jRIGHT = 0;

                    if (rectangles[i, j].Fill == Brushes.White)
                    {
                        neighborsBlue = 0;
                        neighborsBrown = 0;
                        neighborsGreen = 0;
                        neighborsBlack = 0;
                        //Check for Blue
                        if (rectangles[iUP, jLEFT].Fill == Brushes.Blue) neighborsBlue++;   //Left UP
                        if (rectangles[iUP, j].Fill == Brushes.Blue) neighborsBlue++;       //UP
                        if (rectangles[iUP, jRIGHT].Fill == Brushes.Blue) neighborsBlue++;   //Right UP
                        if (rectangles[i, jLEFT].Fill == Brushes.Blue) neighborsBlue++;       //LEFT
                        if (rectangles[i, jRIGHT].Fill == Brushes.Blue) neighborsBlue++;       //RIGHT
                        if (rectangles[iDOWN, jLEFT].Fill == Brushes.Blue) neighborsBlue++;   //Left DOWN
                        if (rectangles[iDOWN, j].Fill == Brushes.Blue) neighborsBlue++;       //DOWN
                        if (rectangles[iDOWN, jRIGHT].Fill == Brushes.Blue) neighborsBlue++;   //Right DOWN


                        //Check for Green
                        if (rectangles[iUP, jLEFT].Fill == Brushes.Green) neighborsGreen++;   //Left UP
                        if (rectangles[iUP, j].Fill == Brushes.Green) neighborsGreen++;       //UP
                        if (rectangles[iUP, jRIGHT].Fill == Brushes.Green) neighborsGreen++;   //Right UP
                        if (rectangles[i, jLEFT].Fill == Brushes.Green) neighborsGreen++;       //LEFT
                        if (rectangles[i, jRIGHT].Fill == Brushes.Green) neighborsGreen++;       //RIGHT
                        if (rectangles[iDOWN, jLEFT].Fill == Brushes.Green) neighborsGreen++;   //Left DOWN
                        if (rectangles[iDOWN, j].Fill == Brushes.Green) neighborsGreen++;       //DOWN
                        if (rectangles[iDOWN, jRIGHT].Fill == Brushes.Green) neighborsGreen++;   //Right DOWN

                        //Check for Brown
                        if (rectangles[iUP, jLEFT].Fill == Brushes.Brown) neighborsBrown++;   //Left UP
                        if (rectangles[iUP, j].Fill == Brushes.Brown) neighborsBrown++;       //UP
                        if (rectangles[iUP, jRIGHT].Fill == Brushes.Brown) neighborsBrown++;   //Right UP
                        if (rectangles[i, jLEFT].Fill == Brushes.Brown) neighborsBrown++;       //LEFT
                        if (rectangles[i, jRIGHT].Fill == Brushes.Brown) neighborsBrown++;       //RIGHT
                        if (rectangles[iDOWN, jLEFT].Fill == Brushes.Brown) neighborsBrown++;   //Left DOWN
                        if (rectangles[iDOWN, j].Fill == Brushes.Brown) neighborsBrown++;       //DOWN
                        if (rectangles[iDOWN, jRIGHT].Fill == Brushes.Brown) neighborsBrown++;   //Right DOWN

                        neighborcounterBlue[i, j] = neighborsBlue;
                        neighborcounterGreen[i, j] = neighborsGreen;
                        neighborcounterBrown[i, j] = neighborsBrown;

                        for (int iw = 0; iw < fieldHeight; iw++)
                        {
                            for (int jw = 0; jw < fieldWidth; jw++)
                            {
                                if (neighborcounterBlue[iw, jw] >= 4)
                                {
                                    rectangles[i, j].Fill = Brushes.Blue;
                                }

                                else if (neighborcounterGreen[iw, jw] == 3)
                                {
                                    rectangles[i, j].Fill = Brushes.Brown;
                                }


                                else if (neighborcounterBrown[iw, jw] == 4)
                                {
                                    rectangles[i, j].Fill = Brushes.Black;
                                }
                            }

                        }
                    }
                    else if (rectangles[i, j].Fill == Brushes.Blue)
                    {
                        neighborsBlue = 0;
                        neighborsBrown = 0;
                        neighborsGreen = 0;
                        neighborsBlack = 0;
                        if (rectangles[iUP, jLEFT].Fill == Brushes.Blue) neighborsBlue++;   //Left UP
                        if (rectangles[iUP, j].Fill == Brushes.Blue) neighborsBlue++;       //UP
                        if (rectangles[iUP, jRIGHT].Fill == Brushes.Blue) neighborsBlue++;   //Right UP
                        if (rectangles[i, jLEFT].Fill == Brushes.Blue) neighborsBlue++;       //LEFT
                        if (rectangles[i, jRIGHT].Fill == Brushes.Blue) neighborsBlue++;       //RIGHT
                        if (rectangles[iDOWN, jLEFT].Fill == Brushes.Blue) neighborsBlue++;   //Left DOWN
                        if (rectangles[iDOWN, j].Fill == Brushes.Blue) neighborsBlue++;       //DOWN
                        if (rectangles[iDOWN, jRIGHT].Fill == Brushes.Blue) neighborsBlue++;   //Right DOWN

                        //Check for Brown
                        if (rectangles[iUP, jLEFT].Fill == Brushes.Brown) neighborsBrown++;   //Left UP
                        if (rectangles[iUP, j].Fill == Brushes.Brown) neighborsBrown++;       //UP
                        if (rectangles[iUP, jRIGHT].Fill == Brushes.Brown) neighborsBrown++;   //Right UP
                        if (rectangles[i, jLEFT].Fill == Brushes.Brown) neighborsBrown++;       //LEFT
                        if (rectangles[i, jRIGHT].Fill == Brushes.Brown) neighborsBrown++;       //RIGHT
                        if (rectangles[iDOWN, jLEFT].Fill == Brushes.Brown) neighborsBrown++;   //Left DOWN
                        if (rectangles[iDOWN, j].Fill == Brushes.Brown) neighborsBrown++;       //DOWN
                        if (rectangles[iDOWN, jRIGHT].Fill == Brushes.Brown) neighborsBrown++;   //Right DOWN

                        neighborcounterBlue[i, j] = neighborsBlue;
                        neighborcounterBrown[i, j] = neighborsBrown;

                        for (int ib = 0; ib < fieldHeight; ib++)
                        {
                            for (int jb = 0; jb < fieldWidth; jb++)
                            {
                                if (neighborcounterBrown[ib, jb] >= 4)
                                {
                                    rectangles[i, j].Fill = Brushes.Brown;
                                }

                                else if (neighborcounterBlue[ib, jb] < 1)
                                {
                                    rectangles[i, j].Fill = Brushes.White;
                                }
                            }

                        }

                    }
                    else if (rectangles[i, j].Fill == Brushes.Green)
                    {
                        neighborsBlue = 0;
                        neighborsBrown = 0;
                        neighborsGreen = 0;
                        neighborsBlack = 0;
                        if (rectangles[iUP, jLEFT].Fill == Brushes.Blue) neighborsBlue++;   //Left UP
                        if (rectangles[iUP, j].Fill == Brushes.Blue) neighborsBlue++;       //UP
                        if (rectangles[iUP, jRIGHT].Fill == Brushes.Blue) neighborsBlue++;   //Right UP
                        if (rectangles[i, jLEFT].Fill == Brushes.Blue) neighborsBlue++;       //LEFT
                        if (rectangles[i, jRIGHT].Fill == Brushes.Blue) neighborsBlue++;       //RIGHT
                        if (rectangles[iDOWN, jLEFT].Fill == Brushes.Blue) neighborsBlue++;   //Left DOWN
                        if (rectangles[iDOWN, j].Fill == Brushes.Blue) neighborsBlue++;       //DOWN
                        if (rectangles[iDOWN, jRIGHT].Fill == Brushes.Blue) neighborsBlue++;   //Right DOWN

                        neighborcounterBlue[i, j] = neighborsBlue;

                        if (neighborcounterBlue[i, j] < 3)
                            rectangles[i, j].Fill = Brushes.Brown;
                    }
                
            
        
                    else if (rectangles[i, j].Fill == Brushes.Brown)
                    {
                        neighborsBlue = 0;
                        neighborsBrown = 0;
                        neighborsGreen = 0;
                        neighborsBlack = 0;

                        if (rectangles[iUP, jLEFT].Fill == Brushes.Blue) neighborsBlue++;   //Left UP
                        if (rectangles[iUP, j].Fill == Brushes.Blue) neighborsBlue++;       //UP
                        if (rectangles[iUP, jRIGHT].Fill == Brushes.Blue) neighborsBlue++;   //Right UP
                        if (rectangles[i, jLEFT].Fill == Brushes.Blue) neighborsBlue++;       //LEFT
                        if (rectangles[i, jRIGHT].Fill == Brushes.Blue) neighborsBlue++;       //RIGHT
                        if (rectangles[iDOWN, jLEFT].Fill == Brushes.Blue) neighborsBlue++;   //Left DOWN
                        if (rectangles[iDOWN, j].Fill == Brushes.Blue) neighborsBlue++;       //DOWN
                        if (rectangles[iDOWN, jRIGHT].Fill == Brushes.Blue) neighborsBlue++;   //Right DOWN
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
            pause();
        }

        public void saveImage()
        {
            //Soll später implementiert werden um das vorhandene Spielfeld als ein PNG zu speichern
            pause();
        }

        public void loadTxt()
        {
            //Soll eine vorhandene Textdatei einlesen können und es auf dem Spielfeld wiederspiegeln
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
            if (c_blue.IsChecked == true) ((Rectangle)rect).Fill = (((Rectangle)rect).Fill == Brushes.White) ? Brushes.Blue : Brushes.White;
            if (c_green.IsChecked == true) ((Rectangle)rect).Fill = (((Rectangle)rect).Fill == Brushes.White) ? Brushes.Green : Brushes.White;
            if (c_brown.IsChecked == true) ((Rectangle)rect).Fill = (((Rectangle)rect).Fill == Brushes.White) ? Brushes.Brown : Brushes.White;
            if (c_black.IsChecked == true) ((Rectangle)rect).Fill = (((Rectangle)rect).Fill == Brushes.White) ? Brushes.Black : Brushes.White;
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

        private void saveImageButton_Click(object sender, RoutedEventArgs e)
        {
            saveImage();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            saveTxt();
        }

        
    }
}
// Ich will Äpfel