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
