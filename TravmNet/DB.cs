using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TravmNet
{
    class DB
    {
        public SqlConnection sql = new SqlConnection("Data Source = " + str[2] + "; Initial Catalog =" + str[3] + ";" +
" Persist Security Info = true; User ID = " + str[0] + "; Password = \"" + str[1] + "\"");
        private static string Auth = "select [idRole] from [Avtorization] where [Login] = '{0}' and [Pass] = '{1}'";
        private static string Reg = "begin if ((select count([Login]) from dbo.Avtorization where[Login] = '{0}') > 0) select 0 else begin insert into Avtorization([Login], Pass, [IdRole], IdInfoRabSotr) values('{0}', '{1}', 3, 1) select 1 end end";
        private static string Lec = "select IdPrep as 'Номер', [Name] as 'Наименование', Kolvo as 'Кол-во', IdPostRash as 'Поступление', IdSposobPrim as 'Способ примения' from Lekarstva";
        private static string AddLecar = "insert into Lekarstva([Name], Kolvo, IdPostRash, IdSposobPrim) values ('{0}', {1}, {2}, {3});";
        private static string DelLecar = "delete Lekarstva where idPrep = {0}";
        private static string UpdLecar = "update Lekarstva  set[Name] = '{0}', Kolvo = {1}, IdPostRash = {2}, IdSposobPrim = {3} where IdPrep = {4}";

        public DB()
        {
            sql.Open();
        }

        ~DB()
        {
            try
            {
                sql.Close();
            }
            catch { }
        }

        public int Avtorization(string Login, string Password)
        {
            try
            {
                return (int)new SqlCommand(String.Format(Auth, Login, Password), sql).ExecuteScalar();
            }catch { return 0; }
        }

        public int Registration(string Login, string Password)
        {
            try
            {
                return (int)new SqlCommand(String.Format(Reg, Login, Password), sql).ExecuteScalar();
            }
            catch { return -1; }
        }

        public DataTable getDT()
        {
            DataTable dt = new DataTable();
            dt.Load((SqlDataReader)new SqlCommand(Lec, sql).ExecuteReader());
            return dt;
        }

        public int AddLec(string name, int Kol, int idpos, int idspos)
        {
            try
            {
                new SqlCommand(string.Format(AddLecar, name, Kol, idpos, idspos), sql).ExecuteNonQuery();
                return 1;
            }catch { return -1; }
        }

        public int delLec(int id)
        {
            try
            {
                new SqlCommand(string.Format(DelLecar, id), sql).ExecuteNonQuery();
                return 1;
            }
            catch { return -1; }
        }

        public int UpdLec(string name, int Kol, int idpos, int idspos, int id)
        {
            try
            {
                new SqlCommand(string.Format(UpdLecar, name, Kol, 1, idspos, id), sql).ExecuteNonQuery();
                return 1;
            }
            catch { return -1; }
        }
    }
}
