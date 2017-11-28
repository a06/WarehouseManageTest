using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace WarehouseManage.DataAccess
{
    public static class SqlHelper
    {
        private const string connectionString = "Data Source=192.168.56.103;Initial Catalog=WarehouseManage;User ID=sa;Password=sa";
        //private const string connectionString = "Data Source=127.0.0.1;Initial Catalog=WarehouseManage;User ID=sa;Password=sa";

        public static int ExecuteNonQuery(SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.Connection = conn;
                _prepareCommand(cmd);
                int affectedRows = 0;
                try
                {
                    //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                    affectedRows = cmd.ExecuteNonQuery();
                    return affectedRows;
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                    throw;
                }
            }
        }

        public static SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            var conn = new SqlConnection(connectionString);
            cmd.Connection = conn;
            _prepareCommand(cmd);
            try
            {
                //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                throw;
            }
        }

        public static object ExecuteScalar(SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.Connection = conn;
                _prepareCommand(cmd);
                try
                {
                    //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                    object obj = cmd.ExecuteScalar();
                    return obj;
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                    throw;
                }
            }
        }

        public static bool Exists(SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                cmd.Connection = conn;
                _prepareCommand(cmd);
                int affectedRows = 0;
                try
                {
                    //System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                    affectedRows = Convert.ToInt32(cmd.ExecuteScalar());
                    return (affectedRows != 0);
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show(cmd.CommandText);
                    throw;
                }
            }
        }

        #region Helper

        private static void _prepareCommand(SqlCommand cmd)
        {
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
        }

        #endregion
    }
}
