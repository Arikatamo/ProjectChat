﻿using ChatClient.Service;
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
        bool isConnect = false;
        ServiceChatClient client;
        int id;
        public MainWindow()
        {
            InitializeComponent();
        }
    
        public void MsgCallback(string username, string msg, ServiceUserTypeMsg typeMsg)
        {
            StackPanel stk = new StackPanel();
            stk.Orientation = System.Windows.Controls.Orientation.Horizontal;
            stk.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

            TextBlock txtBlk = new TextBlock();
            txtBlk.Text = username;
            txtBlk.FontWeight = System.Windows.FontWeights.Bold;
            txtBlk.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            TextBlock txtBlk2 = new TextBlock();
            txtBlk2.Text = msg;
            txtBlk2.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            switch (typeMsg)
            {
                case ServiceUserTypeMsg.Connect:
                    {
                        txtBlk.Foreground = Brushes.Green;
                        txtBlk2.Foreground = Brushes.Green;

                        break;
                    }
                case ServiceUserTypeMsg.Disconnect:
                    {
                        txtBlk.Foreground = Brushes.Red;
                        txtBlk2.Foreground = Brushes.Red;
                        break;
                    }
                case ServiceUserTypeMsg.Error:
                    {
                        txtBlk.Foreground = Brushes.Red;
                        txtBlk2.Foreground = Brushes.Red;
                        break;
                    }
                case ServiceUserTypeMsg.Info:
                    {
                        txtBlk.Foreground = Brushes.LightBlue;
                        txtBlk2.Foreground = Brushes.LightBlue;
                        break;
                    }
                case ServiceUserTypeMsg.Message:
                    {
                        txtBlk.Foreground = Brushes.Black;
                        txtBlk2.Foreground = Brushes.Black;
                        break;
                    }
                case ServiceUserTypeMsg.Warning:
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

        void disconnect()
        {
            if (isConnect)
            {
                //client.Disconnect(id);
                client = null;
                tbName.IsEnabled = true;
                btnCon.Content = "Connect";
                isConnect = false;
            }
        }

        void connect()
        {
            if (!isConnect)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                //id = client.Connect(tbName.Text);
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
                client.SendMsg(tbName.Text, msg.Text, ServiceUserTypeMsg.Message, id);
                msg.Text = "";
            }
        }

        private void msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(msg.Text))
                {
                    client.SendMsg(tbName.Text, msg.Text, ServiceUserTypeMsg.Message, id);
                    msg.Text = "";
                }
            }
        }

    
    }
}