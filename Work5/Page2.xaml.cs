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

namespace Work5
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(null);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            AnswerTextBox.Clear();
            try
            {
                int n = Convert.ToInt32(DataListBox.Items[0]);
                int count = 0;
                string s = "NO";
                for (int i = 1; i <= n; i++)
                {
                    int m = Convert.ToInt32(DataListBox.Items[i]);
                    if(m < 5)
                    {
                        count++;
                    }
                    if (m == 10)
                    {
                        s = "YES";
                    }
                }
                AnswerTextBox.Text += $"{count}\n{s}";
            }
            catch (FormatException)
            {
                AnswerTextBox.Text += "Введены некорректные данные";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearButton2_Click(object sender, RoutedEventArgs e)
        {
            DataListBox.Items.Clear();
        }

        private void AddNumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumberTextBox.Text))
            {
                return;
            }
            try
            {
                int n = int.Parse(NumberTextBox.Text);
                DataListBox.Items.Add(NumberTextBox.Text);
            }
            catch (FormatException)
            {
                AnswerTextBox.Clear();
                AnswerTextBox.Text += "Введены не корректные данные";
            }
            catch (OverflowException)
            {
                MessageBox.Show("Слишком большое число, возможно у вас залипла клавиша");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            NumberTextBox.Clear();
        }
    }
}
