﻿using System;
using System.Windows;

namespace TravmNet
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        DB db = new DB();
        MainWindow mn;

        public Reg(MainWindow mn)
        {
            InitializeComponent();
            this.mn = mn;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i;
            if (TBLogin.Text != string.Empty && PBPas.Password == PBPasRep.Password)
                if ((i = db.Registration(TBLogin.Text, PBPas.Password)) == 0)
                {
                    MessageBox.Show("Аккаунт уже существует!");
                }
                else
            if (i == 1)
                {
                    MessageBox.Show("Аккаунт успешно создан!");
                    Close();
                }
                else MessageBox.Show("Ошибка!");

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mn.Show();
        }
    }
}
