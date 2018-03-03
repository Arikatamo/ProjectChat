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
        public Login()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            bool ver = true;
            TextBox lb = sender as TextBox;
            switch (lb.Text)
            {
                case "Login":
                    {
                        break;
                    }
                case "Password":
                    {
                        break;
                    }
                case "Email":
                    {
                        break;
                    }
                case "New password":
                    {
                        break;
                    }
                case "Secrete code":
                    {
                        break;
                    }
                default:
                    ver = false;
                    break;
            }
            if (ver)
            {
                lb.Text = "";
                lb.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox lb = sender as TextBox;
            if (string.IsNullOrEmpty(lb.Text))
            {
                switch (lb.Name)
                {
                    case "Logins":
                        {
                            lb.Text = "Login";
                            break;
                        }
                    case "Password":
                        {
                            lb.Text = "Password";
                            break;
                        }
                    case "Email":
                        {
                            lb.Text = "Email";
                            break;
                        }
                    case "NewPassword":
                        {
                            lb.Text = "New password";
                            break;
                        }
                    case "SecreteCode":
                        {
                            lb.Text = "Secrete code";
                            break;
                        }

                }

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

        //ForgotPasswordButton
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginForm.Visibility = Visibility.Hidden;
            ForgotForm.Visibility = Visibility.Visible;
            Logins.Text = "Login";
            Logins.Foreground = new SolidColorBrush(Colors.Gray);
            Password.Text = "Password";
            Password.Foreground = new SolidColorBrush(Colors.Gray);
        }

        //Back && SaveChng
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginForm.Visibility = Visibility.Visible;
            ForgotForm.Visibility = Visibility.Hidden;
            SecreteCodeB.Visibility = Visibility.Hidden;
            ButtonVerify.Visibility = Visibility.Hidden;
            NewPasswordB.Visibility = Visibility.Hidden;
            SaveChng.Visibility = Visibility.Hidden;

            Email.Text = "Email";
            Email.Foreground = new SolidColorBrush(Colors.Gray);
            SecreteCode.Text = "Secret code";
            SecreteCode.Foreground = new SolidColorBrush(Colors.Gray);
            NewPassword.Text = "New password";
            NewPassword.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SecreteCodeB.Visibility = Visibility.Visible;
            ButtonVerify.Visibility = Visibility.Visible;
        }

        //Verify
        private void ButtonVerify_Click(object sender, RoutedEventArgs e)
        {
            NewPasswordB.Visibility = Visibility.Visible;
            SaveChng.Visibility = Visibility.Visible;
        }
    }
}
