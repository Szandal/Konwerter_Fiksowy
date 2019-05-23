using Konwerter_Fiksowy.Fiksy;
using System.Windows;
using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Windows.Input;
using System.Text.RegularExpressions;
using MahApps.Metro.Controls.Dialogs;

namespace Konwerter_Fiksowy
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        List<Step> Steps = new List<Step>();

        public MainWindow()
        {

            InitializeComponent();

            StepsListView.ItemsSource = Steps;
        }




        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    Steps.Clear();
                    Infiks infiks = new Infiks(Steps);
                    Prefiks prefiks = new Prefiks(Steps);
                    Postfiks postfiks = new Postfiks(Steps);

                    if (Check(Expression.Text.ToString()))
                    {
                        if (BaseInfix.IsChecked == true)
                        {
                            if (GoalInfix.IsChecked == true)
                            {

                                Steps.Add(new Step(Expression.Text.ToString(), ""));
                                this.ShowMessageAsync("Info", "Base and Goal are the same");
                            }
                            else if (GoalPostfix.IsChecked == true)
                            {
                                postfiks.Infiks2Postfiks(Expression.Text.ToString());

                            }
                            else if (GoalPrefix.IsChecked == true)
                            {
                                prefiks.Infiks2Prefiks(Expression.Text.ToString());
                            }
                            else
                            {
                                this.ShowMessageAsync("Error", "Base and Goal error");

                            }

                        }

                        if (BasePostfix.IsChecked == true)
                        {
                            if (!prefiks.CheckPostfix(Expression.Text.ToString()))
                            {

                                this.ShowMessageAsync("Error", "Incorrect postfix structure");

                            }
                            else
                            {
                                if (GoalInfix.IsChecked == true)
                                {
                                    infiks.Postfiks2Infiks(Expression.Text.ToString());

                                }
                                else if (GoalPostfix.IsChecked == true)
                                {
                                    Steps.Add(new Step(Expression.Text.ToString(), ""));
                                    this.ShowMessageAsync("Info", "Base and Goal are the same");

                                }
                                else if (GoalPrefix.IsChecked == true)
                                {
                                    prefiks.Postfix2Prefix(Expression.Text.ToString());
                                }
                                else
                                {
                                    this.ShowMessageAsync("Error", "Base and Goal error");
                                }
                            }


                        }

                        if (BasePrefix.IsChecked == true)
                        {
                            if (!prefiks.Checkprefix(Expression.Text.ToString()))
                            {

                                this.ShowMessageAsync("Error", "Incorrect prefix structure");

                            }
                            else
                            {

                                if (GoalInfix.IsChecked == true)
                                {

                                    infiks.Prefiks2Infiks(Expression.Text.ToString());

                                }
                                else if (GoalPostfix.IsChecked == true)
                                {
                                    postfiks.Prefisk2Postfix(Expression.Text.ToString());

                                }
                                else if (GoalPrefix.IsChecked == true)
                                {
                                    Steps.Add(new Step(Expression.Text.ToString(), ""));
                                    this.ShowMessageAsync("Info", "Base and Goal are the same");
                                }
                                else
                                {
                                    this.ShowMessageAsync("Error", "Base and Goal error");
                                }
                            }


                        }

                    }
                    else
                    {
                        this.ShowMessageAsync("Info", "Incorrect arithmetic expression");
                    }
                    StepsListView.Items.Refresh();

                }
            }
            catch
            {
                this.ShowMessageAsync("Hmmm", "Something broke down, but we took care of it :)");
            }
  


        }

        private bool Check(string Text)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9///*-/+/(/)/^]{1,20}\Z");
            int numberOf = regex.Matches(Text).Count;
            Match match = regex.Match(Text);


            if (!match.Success)
            {
                return false;
            }
            if (numberOf != 1)
            {
                return false;
            }
            return true;
        }
    }
}
