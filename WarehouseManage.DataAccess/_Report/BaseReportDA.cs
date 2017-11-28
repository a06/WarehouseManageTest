using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using WarehouseManage.Common.Entities;

namespace WarehouseManage.DataAccess
{
    public abstract class BaseReportDA<T> where T : class
    {
        //--Perporty
        protected string SELECT_SQL;

        //--Abstract
        protected abstract T getEntity(IDataReader reader);

        //C
        //R
        public virtual T GetByID(int id)
        {
            var cmd = new SqlCommand(SELECT_SQL);
            cmd.Parameters.AddWithValue("", id);

            return getSingle(cmd);
        }

        public virtual IEnumerable<T> GetList(string filters = "")
        {
            var sb = new StringBuilder();
            sb.Append(SELECT_SQL);

            if (filters != string.Empty)
            {
                sb.Append("\r\n").Append("WHERE ").Append(filters);
            }

            var cmd = new SqlCommand(sb.ToString());

            return getMany(cmd);
        }

        //U
        //D

        //--Protected
        protected T getSingle(SqlCommand cmd)
        {
            var reader = SqlHelper.ExecuteReader(cmd);
            T entity = null;
            try
            {
                if (reader.Read())
                {
                    entity = getEntity(reader);
                }
            }
            finally
            {
                reader.Close();
            }
            return entity;
        }

        protected IList<T> getMany(SqlCommand cmd)
        {
            var reader = SqlHelper.ExecuteReader(cmd);
            var list = new List<T>();
            try
            {
                while (reader.Read())
                {
                    list.Add(getEntity(reader));
                }
            }
            finally
            {
                reader.Close();
            }
            return list;
        }

    }
}
