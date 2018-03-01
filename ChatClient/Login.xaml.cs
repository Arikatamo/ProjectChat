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

namespace ChatClient
{
    public partial class Login : Window
    {
        bool changes;
        public Login()
        {
            InitializeComponent();
            changes = true;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (changes)
            {
                TextBox lb = sender as TextBox;
                lb.Text = "";
                lb.Foreground = new SolidColorBrush(Colors.Black);
                changes = false;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox lb = sender as TextBox;
            if (string.IsNullOrEmpty(lb.Text))
            {
                lb.Text = "Login";
                lb.Foreground = new SolidColorBrush(Colors.Gray);
                changes = true;
            }
        }

        private void TextBox_LostFocus2(object sender, RoutedEventArgs e)
        {
            TextBox lb = sender as TextBox;
            if (string.IsNullOrEmpty(lb.Text))
            {
                lb.Text = "Password";
                changes = true;
                lb.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Border brd = sender as Border;
            brd.Background = new SolidColorBrush(Colors.Gray);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Border brd = sender as Border;
            var bc = new BrushConverter();
            brd.Background = (Brush)bc.ConvertFrom("#D2DCDCDC");
        }
    }
}
