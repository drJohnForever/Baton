using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Table.xaml
    /// </summary>
    public partial class Table : Window
    {
        DB db = new DB();
        MainWindow mn;
        public Table(MainWindow mn)
        {
            InitializeComponent();
            DG.ItemsSource = db.getDT().DefaultView;
            this.mn = mn;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.AddLec(TBName.Text, int.Parse(TBKol.Text), 1, int.Parse(TBSpos.Text));
                DG.ItemsSource = db.getDT().DefaultView;
            }
            catch { MessageBox.Show("Ошибка!"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)DG.SelectedItem;
                if (db.delLec((int)row["Номер"]) == -1) MessageBox.Show("Неверные параметры!");
                DG.ItemsSource = db.getDT().DefaultView;
            } catch { MessageBox.Show("Ошибка!"); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)DG.SelectedItem;
                if (db.UpdLec(TBName.Text, int.Parse(TBKol.Text), 1, int.Parse(TBSpos.Text), (int)row["Номер"]) == -1)
                    MessageBox.Show("Неверные параметры!");
                DG.ItemsSource = db.getDT().DefaultView;
            }
            catch { MessageBox.Show("Ошибка!"); }
        }
    }
}
