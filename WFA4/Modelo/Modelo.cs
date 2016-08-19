using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Sql;


namespace WFA4
{
    public class Modelo
    {
        ////string conexion = "Data Source=(local);Initial Catalog=bdcolegio;Integrated Security=True;";
        ////SqlConnection sqlconn;
        string mysqlconexion = "server= mysql3.gear.host ;Port=3306;Database=bdcolegio;Uid=bdcolegio;Pwd=Ct9X0r?NSp3_;";
        MySqlConnection mysqlconn;
        
        public void conectarBD()
        {
            //sqlconn = new SqlConnection(conexion);
            mysqlconn = new MySqlConnection(mysqlconexion);
            try
            {
                //sqlconn.Open(); 
                mysqlconn.Open();
            }
            catch(Exception e)
            {
                var message = MessageBox.Show("Conexion fallida! Error: " + e.Message.ToString());
            }
            

        }

        public void desconectarBD()
        {
            //sqlconn.Close();
            mysqlconn.Close();
        }

        public void ejecutarSQL(string sql)
        {
            //SqlCommand sqlcomm = new SqlCommand();
            MySqlDataAdapter mysqlda = new MySqlDataAdapter(sql, mysqlconn);
            MySqlCommand mysqlcomm = new MySqlCommand();
            conectarBD();
            //sqlcomm.Connection = sqlconn;
            //sqlcomm.CommandText = sql;
            //sqlcomm.CommandType = CommandType.Text;
            //sqlcomm.ExecuteNonQuery();
            mysqlcomm.Connection = mysqlconn;
            mysqlcomm.CommandText = sql;
            mysqlcomm.CommandType = CommandType.Text;
            mysqlcomm.ExecuteNonQuery();
            desconectarBD();
        }

        public DataTable llenarDT(string sql)
        {
            conectarBD();
            //SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlconn);
            MySqlDataAdapter mysqlda = new MySqlDataAdapter(sql, mysqlconn);
            DataTable dt = new DataTable();
            //sqlda.Fill(dt);
            mysqlda.Fill(dt);
            desconectarBD();
            return dt;
        }
    }
}
