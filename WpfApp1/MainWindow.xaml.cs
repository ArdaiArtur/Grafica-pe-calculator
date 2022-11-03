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

namespace WpfApp1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<ElipsDate> lis = new List<ElipsDate>();
       public static double canH;
        public static double canW;
        public static double eliR;
        public static double eliX;
        public static double eliY;
        public static double newcanH;
        public static double newcanW;
        public MainWindow()
        {   InitializeComponent();
          
            
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MYCanvas.Children.Clear();
            canH = double.Parse(CanvasHeight.Text);
           canW = double.Parse(CanvasWidth.Text);
            eliR = double.Parse(ElipseR.Text);
            eliX = double.Parse(ElipsePositonX.Text);
            eliY = double.Parse(ElipsePositonY.Text);
            Canvas can = new Canvas();
            can.Height = canH;
            can.Width =canW ;
            
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromArgb(200, 100, 140, 0);
            can.Background=scb;
           
                    Ellipse mye = new Ellipse();
                    mye.Fill = scb;
                    mye.StrokeThickness = 2;
                    mye.Stroke = Brushes.Black;
                    mye.Width = eliR*2;
                    mye.Height = eliR*2;
                    mye.Margin = new Thickness(eliX-eliR, eliY- eliR, 0, 0);
                    can.Children.Add(mye);
                
            
            
            MYCanvas.Children.Add(can);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MYCanvas.Children.Clear();

            newcanH= double.Parse(NSizeY.Text);
            newcanW = double.Parse(NSizeX.Text);
            double Sx = newcanW / canW;
            double Sy = newcanH / canH;
            Canvas can = new Canvas();
            can.Height = newcanH;
            can.Width = newcanW;

            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Color.FromArgb(200, 100, 140, 0);
            can.Background = scb;

            Ellipse mye = new Ellipse();
            mye.Fill = scb;
            mye.StrokeThickness = 2;
            mye.Stroke = Brushes.Black;

            mye.Width = eliR *Sx* 2;
            mye.Height = eliR * Sy * 2;
            mye.Margin = new Thickness(Sx*(eliX-eliR) ,Sy* (eliY-eliR) , 0, 0);
            can.Children.Add(mye);



            MYCanvas.Children.Add(can);
        }

        private void ListAdd_Click(object sender, RoutedEventArgs e)
        {
            ElipsDate addme = new ElipsDate();
            addme.Raza = double.Parse(ElipseR.Text);
           addme.PozX= double.Parse(ElipsePositonX.Text);
            addme.PozY= double.Parse(ElipsePositonY.Text);
            lis.Add(addme);
        }

        private void ListDraw_Click(object sender, RoutedEventArgs e)
        {
            MYCanvas.Children.Clear();
            Canvas can = new Canvas();
            canH = double.Parse(CanvasHeight.Text);
            canW = double.Parse(CanvasWidth.Text);
            can.Height = canH;
            can.Width = canW;
            SolidColorBrush scbs = new SolidColorBrush();
            scbs.Color = Color.FromArgb(200, 200, 90, 0);
            can.Background = scbs;
            foreach (var item in lis)
            {
                

                SolidColorBrush scb = new SolidColorBrush();
                scb.Color = Color.FromArgb(200, 100, 140, 0);
                can.Background = scb;

                Ellipse mye = new Ellipse();
                mye.Fill = scb;
                mye.StrokeThickness = 2;
                mye.Stroke = Brushes.Black;
                mye.Width = item.Raza * 2;
                mye.Height = item.Raza * 2;
                mye.Margin = new Thickness(item.PozX - item.Raza, item.PozY - item.Raza, 0, 0);
                can.Children.Add(mye);



            }
            can.Background = scbs;
            MYCanvas.Children.Add(can);
        }

        private void ListResize_Click(object sender, RoutedEventArgs e)
        {
            MYCanvas.Children.Clear();
            Canvas can = new Canvas();
            canH = double.Parse(CanvasHeight.Text);
            canW = double.Parse(CanvasWidth.Text);
            newcanH = double.Parse(NSizeY.Text);
            newcanW = double.Parse(NSizeX.Text);
            double Sx = newcanW / canW;
            double Sy = newcanH / canH;
            can.Height = Sy*canH;
            can.Width =Sx* canW;
            SolidColorBrush scbs = new SolidColorBrush();
            scbs.Color = Color.FromArgb(200, 200, 90, 0);
            can.Background = scbs;
            foreach (var item in lis)
            {


                SolidColorBrush scb = new SolidColorBrush();
                scb.Color = Color.FromArgb(200, 100, 140, 0);
                can.Background = scb;

                Ellipse mye = new Ellipse();
                mye.Fill = scb;
                mye.StrokeThickness = 2;
                mye.Stroke = Brushes.Black;
                mye.Width =Sx* item.Raza * 2;
                mye.Height =Sy* item.Raza * 2;
                mye.Margin = new Thickness((item.PozX - item.Raza)*Sx, (item.PozY - item.Raza)*Sy, 0, 0);
                can.Children.Add(mye);



            }
            can.Background = scbs;
            MYCanvas.Children.Add(can);
        }
    }
}
