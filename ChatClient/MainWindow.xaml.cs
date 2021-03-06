﻿using BLL.Concrete;
using ChatClient;
using ChatClient.ServiceReference1;
using ChatService;
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
using static ChatService.ServiceUser;

namespace WpfApp1
{
    public partial class MainWindow : Window, IServiceChatCallback
    {
        private readonly UserProvider provider = new UserProvider();
        bool isConnect = false;
        private ServiceChatClient client;
       private List<UserChat> listOnlineUsers;
        private UserChat UserInLog = new UserChat();

        public MainWindow()
        {
            InitializeComponent();
            listOnlineUsers = new List<UserChat>();
        }

        public void MsgCallback(UserChat username, string msg, TypeMsg typeMsg)
        {

            StackPanel stk = new StackPanel();
            stk.Orientation = System.Windows.Controls.Orientation.Horizontal;
            stk.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            TextBlock txtBlk = new TextBlock();
            txtBlk.Text = username.Name + " : ";
            txtBlk.FontWeight = System.Windows.FontWeights.Bold;
            txtBlk.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            TextBlock txtBlk2 = new TextBlock();
            txtBlk2.Text = msg;
            txtBlk2.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            switch (typeMsg)
            {
                case TypeMsg.Connect:
                    {
                        txtBlk.Foreground = Brushes.Green;
                        txtBlk2.Foreground = Brushes.Green;

                        listOnlineUsers.Add(username);
                        listUsers.ItemsSource = listOnlineUsers;
                        listUsers.SelectedValuePath = "Name";
                        listUsers.Items.Refresh();
                        break;
                    }
                case TypeMsg.Disconnect:
                    {
                        txtBlk.Foreground = Brushes.Red;
                        txtBlk2.Foreground = Brushes.Red;
                        try
                        {
                            listOnlineUsers.RemoveAt(listOnlineUsers.FindIndex(x => x == UserInLog));
                            listUsers.ItemsSource = listOnlineUsers;
                            listUsers.Items.Refresh();
                        }
                        catch (Exception)
                        {

                        }


                        break;
                    }
                case TypeMsg.Error:
                    {
                        txtBlk.Foreground = Brushes.Red;
                        txtBlk2.Foreground = Brushes.Red;
                        break;
                    }
                case TypeMsg.Info:
                    {
                        txtBlk.Foreground = Brushes.LightBlue;
                        txtBlk2.Foreground = Brushes.LightBlue;
                        break;
                    }
                case TypeMsg.Message:
                    {
                        txtBlk.Foreground = Brushes.Black;
                        txtBlk2.Foreground = Brushes.Black;
                        break;
                    }
                case TypeMsg.Warning:
                    {
                        txtBlk.Foreground = Brushes.Yellow;
                        txtBlk2.Foreground = Brushes.Yellow;
                        break;
                    }

            }

            stk.Children.Add(txtBlk);
            stk.Children.Add(txtBlk2);

            chat.Items.Add(stk);
            chat.ScrollIntoView(chat.Items[chat.Items.Count - 1]);
        }
        
        void  disconnect()
        {
            try
            {
                if (isConnect)
                {
                    client.Disconnect(UserInLog.id);
                    client = null;
                    tbName.IsEnabled = true;
                    btnCon.Content = "Connect";
                    isConnect = false;
                    chat.Items.Clear();
                    //Список онлайн юзерів
                    listUsers.ItemsSource = null;
                    listUsers.Items.Refresh();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        void connect()
        {
            if (!isConnect)
            {

                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
             
                UserInLog = client.Connect(provider.GetAllUsers().FirstOrDefault(x => x.Name == tbName.Text));

                if (History.IsChecked == true)
                {
                    var allMsg = provider.GetAllMsg();

                    foreach (var item in allMsg)
                    {
                        try
                        {
                            var a = provider.GetAllUsers().FirstOrDefault(x => x.id == item.UserID);
                            MsgCallback(a, item.Message, TypeMsg.Message);
                            //chat.ItemsSource = provider.GetAllMsg();
                            //chat.SelectedValuePath = "Message";
                            //chat.SelectedValue = "Message";
                        }
                        catch (Exception)
                        {


                        }

                    }
                }
                // MessageBox.Show(client.GetAllOnlineUsers().Length.ToString());
                ////Cписок онлайн юзерів

                listOnlineUsers.AddRange(client.GetAllOnlineUsers());
     
                listUsers.ItemsSource = listOnlineUsers;
                listUsers.Items.Refresh();
                tbName.IsEnabled = false;
                btnCon.Content = "Disconnect";
                isConnect = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isConnect)
            {
                disconnect();
            }
            else
            {
                connect();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isConnect)
            {
                disconnect();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(msg.Text))
            {
                provider.AddMsg(msg.Text, UserInLog.id);
                client.SendMsg(UserInLog, msg.Text, TypeMsg.Message, UserInLog.id);
                msg.Text = "";
            }
        }

        private void msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(msg.Text))
                {
                    provider.AddMsg(msg.Text, UserInLog.id);
                    client.SendMsg(UserInLog, msg.Text, TypeMsg.Message, UserInLog.id);
                    msg.Text = "";
                }
            }
        }
    }
}
