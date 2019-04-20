using Konwerter_Fiksowy.Fiksy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Infiks infiks = new Infiks();
            Prefiks prefiks = new Prefiks();
            Postfiks postfiks = new Postfiks();
            string expression = TB.Text.ToString();
            switch (CB.Text.ToString())
            {
                case "In - Post":
                    Lab.Content=postfiks.Infiks2Postfiks(expression);
                    break;
                case "In - Pre":
                    Lab.Content = prefiks.Infiks2Prefiks(expression);
                    break;
                case "Pre - In":
                    Lab.Content = infiks.Prefiks2Infiks(expression);
                    break;
                case "Pre - Post":

                    break;
                case "Post - In":                    
                    Lab.Content = infiks.Postfiks2Infiks(expression);
                    break;
                case "Post - Pre":
   
                    break;



            }
        }
    }
}
