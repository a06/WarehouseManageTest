using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using WarehouseManage.Common.Entities;

namespace WarehouseManage.DataAccess
{
    public abstract class BaseBillDA<T, I> where T: class where I : class
    {
        #region //--Perporty

        protected string SELECT_TABLE_NAME
        {
            get { if (string.IsNullOrEmpty(_select_table_name)) throw new NotImplementedException(); else return _select_table_name; }
            set { _select_table_name = value; }
        }
        private string _select_table_name;

        protected IList<string> SELECT_FIELDS
        {
            get { if (_select_fields == null) throw new NotImplementedException(); else return _select_fields; }
            set { _select_fields = value; }
        }
        private IList<string> _select_fields;

        protected string UPDATE_TABLE_NAME
        {
            get { if (string.IsNullOrEmpty(_update_table_name)) throw new NotImplementedException(); else return _update_table_name; }
            set { _update_table_name = value; }
        }
        private string _update_table_name;

        protected IList<string> UPDATE_FIELDS
        {
            get { if (_update_fields == null) throw new NotImplementedException(); else return _update_fields; }
            set { _update_fields = value; }
        }
        private IList<string> _update_fields;

        protected string PRIMARY_KEY
        {
            get { if (string.IsNullOrEmpty(_primary_key)) throw new NotImplementedException(); else return _primary_key; }
            set { _primary_key = value; }
        }
        private string _primary_key;

        //protected string UNIQUE_INDEX;

        protected string ITEM_SELECT_TABLE_NAME
        {
            get { if (string.IsNullOrEmpty(_item_select_table_name)) throw new NotImplementedException(); else return _item_select_table_name; }
            set { _item_select_table_name = value; }
        }
        private string _item_select_table_name;

        protected IList<string> ITEM_SELECT_FIELDS
        {
            get { if (_item_select_fields == null) throw new NotImplementedException(); else return _item_select_fields; }
            set { _item_select_fields = value; }
        }
        private IList<string> _item_select_fields;

        protected string ITEM_UPDATE_TABLE_NAME
        {
            get { if (string.IsNullOrEmpty(_item_update_table_name)) throw new NotImplementedException(); else return _item_update_table_name; }
            set { _item_update_table_name = value; }
        }
        private string _item_update_table_name;

        protected IList<string> ITEM_UPDATE_FIELDS
        {
            get { if (_item_update_fields == null) throw new NotImplementedException(); else return _item_update_fields; }
            set { _item_update_fields = value; }
        }
        private IList<string> _item_update_fields;

        protected string ITEM_PRIMARY_KEY
        {
            get { if (string.IsNullOrEmpty(_item_primary_key)) throw new NotImplementedException(); else return _item_primary_key; }
            set { _item_primary_key = value; }
        }
        private string _item_primary_key;

        //protected string ITEM_UNIQUE_INDEX;

        #endregion

        //--Abstract
        protected abstract int getID(T bill);
        protected abstract int getItemID(I item);
        protected abstract IEnumerable<I> getItems(T bill);

        protected abstract IList<string> getUpdateFields(T original, T toUpdate);
        protected abstract IList<string> getItemUpdateFields(I original, I toUpdate);
        protected abstract void fillParameters(SqlParameterCollection parameters, IList<string> fields, T bill);
        protected abstract string getItemInsertValues(IList<string> fields, I item);
        protected abstract string getItemUpdateValues(IList<string> fields, I item);

        protected abstract T getFromReader(IDataReader reader, bool isWithItems = true);
        protected abstract I getItemFromReader(IDataReader reader);

        //C
        public abstract T Create();

        //R
        protected virtual string getSelectSql(string where = "", string orderby = "")
        {
            var sb = new StringBuilder();

            sb.Append("SELECT ").Append(PRIMARY_KEY).Append(", ").Append(toFields(SELECT_FIELDS))
                .Append("\r\n")
                .Append("FROM ").Append(SELECT_TABLE_NAME);

            if (where != string.Empty)
                sb.Append("\r\n")
                    .Append("WHERE ").Append(where);

            if (orderby != string.Empty)
                sb.Append("\r\n")
                    .Append("ORDER BY ").Append(orderby);

            return sb.ToString();
        }

        protected virtual string getItemSelectSql(string where = "", string orderby = "")
        {
            var sb = new StringBuilder();

            sb.Append("SELECT ").Append(ITEM_PRIMARY_KEY).Append(", ").Append(toFields(ITEM_SELECT_FIELDS))
                .Append("\r\n")
                .Append("FROM ").Append(ITEM_SELECT_TABLE_NAME);

            if (where != string.Empty)
                sb.Append("\r\n")
                    .Append("WHERE ").Append(where);

            if (orderby != string.Empty)
                sb.Append("\r\n")
                    .Append("ORDER BY ").Append(orderby);

            return sb.ToString();
        }

        public virtual T GetByID(int id)
        {
            var sql = getSelectSql(PRIMARY_KEY + "=" + id);
            var cmd = new SqlCommand(sql);

            return getFromCmd(cmd);
        }

        public virtual IEnumerable<T> GetList(string where = "", string orderby = "")
        {
            var sb = new StringBuilder();

            sb.Append(getSelectSql(where, orderby));
            var cmd = new SqlCommand(sb.ToString());

            return getListFromCmd(cmd);
        }

        public virtual IEnumerable<I> GetItemList(int id)
        {
            var sql = getItemSelectSql(PRIMARY_KEY + "=" + id);
            var cmd = new SqlCommand(sql);

            return getItemListFromCmd(cmd);
        }

        //U
        protected virtual string getItemInsertSql(I item)
        {
            var sb = new StringBuilder();

            sb.Append("INSERT INTO ").Append(ITEM_UPDATE_TABLE_NAME)
                .Append(" (").Append(toFields(ITEM_UPDATE_FIELDS)).Append(")")
                .Append("\r\n")
                .Append("VALUES (").Append(getItemInsertValues(ITEM_UPDATE_FIELDS, item)).Append(")");

            return sb.ToString();
        }
        protected virtual string getItemUpdateSql(I originalItem, I toUpdateItem)
        {
            var sb = new StringBuilder();
            var updateFields = getItemUpdateFields(originalItem, toUpdateItem);

            sb.Append("UPDATE ").Append(ITEM_UPDATE_TABLE_NAME)
                .Append(" SET ").Append(getItemUpdateValues(updateFields, toUpdateItem))
                .Append("\r\n")
                .Append("WHERE ").Append(ITEM_PRIMARY_KEY).Append("=").Append(getItemID(toUpdateItem));

            return sb.ToString();
        }

        public virtual int Insert(T toInsert, out int newID)
        {
            var sb = new StringBuilder();

            sb.Append("INSERT INTO ").Append(UPDATE_TABLE_NAME)
                .Append(" (").Append(toFields(UPDATE_FIELDS)).Append(")")
                .Append("\r\n")
                .Append("VALUES (").Append(toParams(UPDATE_FIELDS)).Append(")")
                .Append("\r\n")
                .Append("SET @").Append(PRIMARY_KEY).Append("=SCOPE_IDENTITY()");

            foreach (var item in getItems(toInsert))
            {
                sb.Append("\r\n")
                    .Append(getItemInsertSql(item));
            }

            sb.Append("\r\n")
                .Append("SELECT @").Append(PRIMARY_KEY);

            var cmd = new SqlCommand(sb.ToString());
            fillParameters(cmd.Parameters, UPDATE_FIELDS, toInsert);
            cmd.Parameters[toParam(PRIMARY_KEY)].Direction = ParameterDirection.Output;

            int affectedRows = SqlHelper.ExecuteNonQuery(cmd);
            newID = (int)cmd.Parameters[toParam(PRIMARY_KEY)].Value;

            return affectedRows;
        }

        protected virtual string getItemsUpdateSql(IEnumerable<I> originalItems, IEnumerable<I> toUpdateItems)
        {
            var sb = new StringBuilder();

            //Insert or Update
            foreach (var toUpdateItem in toUpdateItems)
            {
                if (getItemID(toUpdateItem) == 0)  //Insert
                {
                    sb.Append("\r\n")
                        .Append(getItemInsertSql(toUpdateItem));
                }
                else //Update
                {
                    foreach (var originalItem in originalItems)
                    {
                        if (getItemID(originalItem) == getItemID(toUpdateItem))
                        {
                            sb.Append("\r\n")
                                .Append(getItemUpdateSql(originalItem, toUpdateItem));
                            break;
                        }
                    }
                }
            }

            //Delete
            foreach (var originalItem in originalItems)
            {
                var isDeleted = true;

                foreach (var toUpdateItem in toUpdateItems)
                {
                    if (getItemID(originalItem) == getItemID(toUpdateItem))
                    {
                        isDeleted = false;
                    }
                }

                if (isDeleted)
                {
                    sb.Append("\r\n")
                        .Append(getItemDeleteSql(ITEM_PRIMARY_KEY + "=" + getItemID(originalItem)));
                }
            }

            return sb.ToString();
        }
        public virtual int Update(T original, T toUpdate)
        {
            var sb = new StringBuilder();

            var updateFields = getUpdateFields(original, toUpdate);

            if (updateFields.Count > 0)
            {
                sb.Append("UPDATE ").Append(UPDATE_TABLE_NAME)
                    .Append(" SET ").Append(toFieldsEqualParams(updateFields))
                    .Append("\r\n")
                    .Append("WHERE ").Append(PRIMARY_KEY).Append("=@").Append(PRIMARY_KEY);
            }

            sb.Append(getItemsUpdateSql(getItems(original), getItems(toUpdate)));

            var cmd = new SqlCommand(sb.ToString());
            fillParameters(cmd.Parameters, updateFields, toUpdate);

            return SqlHelper.ExecuteNonQuery(cmd);
        }

        //D
        protected string getItemDeleteSql(string where = "")
        {
            var sb = new StringBuilder();

            sb.Append("DELETE FROM ").Append(ITEM_UPDATE_TABLE_NAME);

            if (where != string.Empty)
                sb.Append("\r\n")
                    .Append("WHERE ").Append(where);

            return sb.ToString();
        }

        public virtual int Delete(int id)
        {
            var sb = new StringBuilder();

            sb.Append("DELETE FROM ").Append(UPDATE_TABLE_NAME)
                .Append("\r\n")
                .Append("WHERE ").Append(PRIMARY_KEY + "=" + id);

            sb.Append("\r\n")
                .Append(getItemDeleteSql(PRIMARY_KEY + "=" + id));

            var cmd = new SqlCommand(sb.ToString());

            return SqlHelper.ExecuteNonQuery(cmd);
        }

        public virtual int Delete(T toDelete)
        {
            return this.Delete(getID(toDelete));
        }

        #region Helpers

        //--Protected
        protected T getFromCmd(SqlCommand cmd)
        {
            var reader = SqlHelper.ExecuteReader(cmd);
            T single = null;
            try
            {
                if (reader.Read())
                {
                    single = getFromReader(reader);
                }
            }
            finally
            {
                reader.Close();
            }
            return single;
        }
        //protected I getItemFromCmd(SqlCommand cmd)
        //{
        //    var reader = SqlHelper.ExecuteReader(cmd);
        //    I single = null;
        //    try
        //    {
        //        if (reader.Read())
        //        {
        //            single = getItemFromReader(reader);
        //        }
        //    }
        //    finally
        //    {
        //        reader.Close();
        //    }
        //    return single;
        //}

        protected IList<T> getListFromCmd(SqlCommand cmd)
        {
            var reader = SqlHelper.ExecuteReader(cmd);
            var list = new List<T>();
            try
            {
                while (reader.Read())
                {
                    list.Add(getFromReader(reader, false));
                }
            }
            finally
            {
                reader.Close();
            }
            return list;
        }
        protected IList<I> getItemListFromCmd(SqlCommand cmd)
        {
            var reader = SqlHelper.ExecuteReader(cmd);
            var list = new List<I>();
            try
            {
                while (reader.Read())
                {
                    list.Add(getItemFromReader(reader));
                }
            }
            finally
            {
                reader.Close();
            }
            return list;
        }

        protected enum SqlType
        {
            Field,
            Parameter,
            FieldEqualParam,
        }

        protected string toFields(IList<string> fields)
        {
            return _getSql(fields, SqlType.Field);
        }
        protected string toParams(IList<string> fields)
        {
            return _getSql(fields, SqlType.Parameter);
        }
        protected string toFieldsEqualParams(IList<string> fields)
        {
            return _getSql(fields, SqlType.FieldEqualParam);
        }

        protected string toParam(string str)
        {
            return "@" + str;
        }
        //protected string toFieldEqualParam(string str)
        //{
        //    return str + "=@" + str;
        //}

        protected StringBuilder addComma(StringBuilder sb)
        {
            if (sb.Length != 0)
                sb.Append(", ");

            return sb;
        }

        //--Private
        private string _getSql(IList<string> fields, SqlType sqlType)
        {
            var sb = new StringBuilder();

            foreach (var item in fields)
            {
                addComma(sb);
                switch (sqlType)
                {
                    case SqlType.Field:
                        sb.Append(item);
                        break;
                    case SqlType.Parameter:
                        sb.Append("@").Append(item);
                        break;
                    case SqlType.FieldEqualParam:
                        sb.Append(item).Append(" = @").Append(item);
                        break;
                }
            }

            return sb.ToString();
        }

        #endregion

    }
}
