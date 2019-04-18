using Konwerter_Fiksowy.Fiksy;
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

namespace Konwerter_Fiksowy
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string expression = TB.Text.ToString();
            Console.Out.Write(expression);
            switch (CB.Text.ToString())
            {
                case "In - Post":
                    Postfiks postfiks = new Postfiks();
                    Lab.Content=postfiks.Infiks2Prefiks(expression);
                    break;
                case "In - Pre":
                    Prefiks prefiks = new Prefiks();
                    Lab.Content = prefiks.Infiks2Prefiks(expression);
                    break;
                case "Pre - In":
     
                    break;
                case "Pre - Post":

                    break;
                case "Post - In":

                    break;
                case "Post - Pre":
   
                    break;



            }
        }
    }
}
