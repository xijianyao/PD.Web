using System;
using System.Text;
using System.Reflection;
using System.Data;
using System.Collections.Generic;

namespace PD.Access
{
    public class Server
    {
        public string modelName = string.Empty;
        public string primaryKey = string.Empty;

        public Server(string modelname, string primarykey)
        {
            this.modelName = modelname;
            this.primaryKey = primarykey;
        }

        public int ObjectInsert(object model)
        {
            Type modeltype = model.GetType();
            StringBuilder sb = new StringBuilder();

            sb.Append("insert into [" + modeltype.Name + "] (");

            string fields = string.Empty;
            string values = string.Empty;

            foreach (PropertyInfo pi in modeltype.GetProperties())
            {
                object value = pi.GetValue(model, null);
                if (pi.Name.Equals("status") || pi.Name.Equals("errmsg"))
                {
                    break;
                }

                try
                {
                    Type valuetype = value.GetType();

                    fields += "[" + pi.Name + "],";

                    if (valuetype == typeof(int))
                    {
                        values += value.ToString() + ",";
                    }
                    else if (valuetype == typeof(string))
                    {
                        values += "'" + value.ToString() + "',";
                    }
                    else if (valuetype == typeof(decimal))
                    {
                        values += value.ToString() + ",";
                    }
                    else if (valuetype == typeof(bool))
                    {
                        values += "'" + (Convert.ToBoolean(value) ? "1" : "0") + "',";
                    }
                    else if (valuetype == typeof(DateTime))
                    {
                        values += "'" + Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss") + "',";
                    }
                    else if (valuetype == typeof(Guid))
                    {
                        values += "cast('" + value.ToString() + "' as uniqueidentifier ),";
                    }
                }
                catch { continue; }
            }

            sb.Append(fields.TrimEnd(','));
            sb.Append(") values (");
            sb.Append(values.TrimEnd(','));
            sb.Append(")");

            return Access.ExecuteNonQuery(sb.ToString());
        }

        public int ObjectUpdate(object model)
        {
            Type modeltype = model.GetType();
            StringBuilder sb = new StringBuilder();
            sb.Append("update [" + modeltype.Name + "] set ");

            string values = string.Empty;
            string where = string.Empty;

            foreach (PropertyInfo pi in modeltype.GetProperties())
            {
                object value = pi.GetValue(model, null);

                if (pi.Name.Equals("status") || pi.Name.Equals("errmsg"))
                {
                    break;
                }

                try
                {
                    Type valuetype = value.GetType();

                    if (pi.Name.ToLower() == primaryKey.ToLower())
                    {
                        where = "[" + pi.Name + "] = '" + value.ToString() + "'";
                    }
                    else
                    {
                        if (valuetype == typeof(int) && value != null)
                        {
                            values += "[" + pi.Name + "] = " + value.ToString() + ",";
                        }
                        else if (valuetype == typeof(string) && value != null)
                        {
                            values += "[" + pi.Name + "] = '" + value.ToString() + "',";
                        }
                        else if (valuetype == typeof(bool) && value != null)
                        {
                            values += "[" + pi.Name + "] = '" + (Convert.ToBoolean(value) ? "1" : "0") + "',";
                        }
                        else if (valuetype == typeof(decimal) && value != null)
                        {
                            values += "[" + pi.Name + "] = " + Convert.ToDecimal(value) + ",";
                        }
                        else if (valuetype == typeof(DateTime) && value != null)
                        {
                            values += "[" + pi.Name + "] = '" + Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss") + "',";
                        }
                    }
                }
                catch { continue; }
            }

            sb.Append(values.TrimEnd(','));
            sb.Append(" where 1 = 1 and " + where);

            return Access.ExecuteNonQuery(sb.ToString());
        }

        public int ObjectUpdate(string fields, string where)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("update [" + modelName + "] set " + fields + " where 1 = 1 " + where);

            return Access.ExecuteNonQuery(sb.ToString());
        }

        public int ObjectDelete(string where)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("delete from [" + modelName + "] where 1 = 1 " + where);

            return Access.ExecuteNonQuery(sb.ToString());
        }

        public int ObjectCount(string where)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("select count(*) from [" + modelName + "] where 1 = 1 " + where);

                return (Int32)Access.ExecuteScalar(sb.ToString());
            }
            catch { return 0; }
        }

        public int ObjectSum(string where, string field)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("select sum([" + field + "]) from [" + modelName + "] where 1 = 1 " + where);

                return (Int32)Access.ExecuteScalar(sb.ToString());
            }
            catch { return 0; }
        }

        public int GetOrderField(string orderfield, string where)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("select max(" + orderfield + ") from [" + modelName + "] where 1 = 1 " + where);

                return (Int32)Access.ExecuteScalar(sb.ToString());
            }
            catch { return 0; }
        }

        public T GetObject<T>(string where)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select top 1 * from [" + modelName + "] where 1 = 1 " + where);

            DataTable dt = Access.ReturnTableQuery(sb.ToString());

            if (dt.Rows.Count == 1)
            {
                return GetObject<T>(dt.Rows[0], Access.CreateModel<T>(modelName));
            }
            else { return default(T); }
        }

        protected T GetObject<T>(DataRow row, T model)
        {
            Type t = model.GetType();

            foreach (PropertyInfo pi in t.GetProperties())
            {
                string name = pi.Name;

                try
                {
                    Type valueType = row[name].GetType();

                    if (valueType == typeof(string))
                    {
                        pi.SetValue(model, row[name], null);
                    }
                    else if (valueType == typeof(decimal))
                    {
                        pi.SetValue(model, row[name], null);
                    }
                    else if (valueType != typeof(DBNull))
                    {
                        pi.SetValue(model, row[name], null);
                    }
            
                }
                catch { continue; }
            }

            return model;
        }

        public List<T> GetObjects<T>(string where)
        {
            List<T> list = new List<T>();

            StringBuilder sb = new StringBuilder();

            sb.Append("select * from [" + modelName + "] where 1 = 1 " + where);

            DataTable dt = Access.ReturnTableQuery(sb.ToString());

            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetObject<T>(row, Access.CreateModel<T>(modelName)));
            }

            return list;
        }

        public List<T> GetObjects<T>(string fields, int rows, int page, string where, string orderfield, int ordertype)
        {
            int Count = 0; return GetObjects<T>(fields, rows, page, where, orderfield, ordertype, ref Count);
        }
        /*11-21 龚伟*/
        public List<T> GetObjects<T>(string fields, int rows, int page, string where, string orderfield, int ordertype, string table = "")
        {
            int Count = 0; return GetObjects<T>(fields, rows, page, where, orderfield, ordertype, ref Count, table);
        }
        public List<T> GetObjects<T>(string fields, int rows, int page, string where, string orderfield, int ordertype, ref int recordcount, string table = "")
        {
            List<T> list = new List<T>();

            string Sql = GetPageSql(fields, rows, page, where, orderfield, ordertype, ref recordcount, table);

            DataTable dt = Access.ReturnTableQuery(Sql);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetObject<T>(row, Access.CreateModel<T>(modelName)));
            }

            return list;
        }
        protected string GetPageSql(string fields, int rows, int page, string where, string orderfield, int ordertype, ref int recordcount, string table = "")
        {
            int TotalPage; int CurrentPageSize; int TotalRecordForPageIndex; string OrderBy = ""; string CutOrderBy = "";
            if (!string.IsNullOrEmpty(orderfield))
            {
                if (ordertype == 1)
                {
                    OrderBy = " ORDER BY [" + orderfield.Replace(",", "] DESC, [") + "] DESC";
                    CutOrderBy = " ORDER BY [" + orderfield.Replace(",", "] ASC, [") + "] ASC";
                }
                else
                {
                    OrderBy = " ORDER BY [" + orderfield.Replace(",", "] ASC, [") + "] ASC";
                    CutOrderBy = " ORDER BY [" + orderfield.Replace(",", "] DESC, [") + "] DESC";
                }
            }
            recordcount = ObjectCount(where, table);

            if (rows == 0 || page == 0)
            {
                CurrentPageSize = recordcount;
                TotalRecordForPageIndex = recordcount;
            }
            else
            {
                TotalPage = (recordcount - 1) / rows + 1;
                CurrentPageSize = rows;
                if (TotalPage == page)
                {
                    CurrentPageSize = recordcount % rows;
                    if (CurrentPageSize == 0)
                    {
                        CurrentPageSize = rows;
                    }
                }
                TotalRecordForPageIndex = page * rows;
            }

            return "SELECT * FROM (SELECT TOP " + CurrentPageSize + " * FROM (SELECT TOP " + TotalRecordForPageIndex + " " + fields + " FROM [" + (table == "" ? modelName : table) + "] WHERE 1 = 1 " + where + " " + OrderBy + ") TB2 " + CutOrderBy + ") TB3 " + OrderBy;
        }
        public int ObjectCount(string where, string table = "")
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (table == "")
                {
                    sb.Append("select count(*) from [" + modelName + "] where 1 = 1 " + where);
                }
                else
                {
                    sb.Append("select count(*) from [" + table + "] where 1 = 1 " + where);

                }
                return (Int32)Access.ExecuteScalar(sb.ToString());
            }
            catch { return 0; }
        }
        public int ObjectDelete(string where, string table)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("delete from [" + table + "] where 1 = 1 " + where);

            return Access.ExecuteNonQuery(sb.ToString());
        }
        public int ObjectInsert(object model, string table)
        {
            Type modeltype = model.GetType();
            StringBuilder sb = new StringBuilder();

            sb.Append("insert into [" + table + "] (");

            string fields = string.Empty;
            string values = string.Empty;

            foreach (PropertyInfo pi in modeltype.GetProperties())
            {
                object value = pi.GetValue(model, null);

                try
                {
                    Type valuetype = value.GetType();

                    fields += "[" + pi.Name + "],";

                    if (valuetype == typeof(int))
                    {
                        values += value.ToString() + ",";
                    }
                    else if (valuetype == typeof(string))
                    {
                        values += "'" + value.ToString() + "',";
                    }
                    else if (valuetype == typeof(decimal))
                    {
                        values += value.ToString() + ",";
                    }
                    else if (valuetype == typeof(bool))
                    {
                        values += "'" + (Convert.ToBoolean(value) ? "1" : "0") + "',";
                    }
                    else if (valuetype == typeof(DateTime))
                    {
                        values += "'" + Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss") + "',";
                    }
                }
                catch { continue; }
            }

            sb.Append(fields.TrimEnd(','));
            sb.Append(") values (");
            sb.Append(values.TrimEnd(','));
            sb.Append(")");

            return Access.ExecuteNonQuery(sb.ToString());
        }
        public List<T> GetObjects<T>(string where, string model)
        {
            List<T> list = new List<T>();

            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(model))
            {
                sb.Append("select * from [" + modelName + "] where 1 = 1 " + where);
            }
            else
            {
                sb.Append("select * from [" + model + "] where 1 = 1 " + where);
            }
            DataTable dt = Access.ReturnTableQuery(sb.ToString());
            if (!string.IsNullOrEmpty(model))
            {
                modelName = model;
            }
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetObject<T>(row, Access.CreateModel<T>(modelName)));
            }

            return list;
        }
        public List<T> GetModels<T>(string where)
        {
            List<T> list = new List<T>();

            StringBuilder sb = new StringBuilder();

            sb.Append("select * from [" + modelName + "] where 1 = 1 " + where);

            DataTable dt = Access.ReturnTableQuery(sb.ToString());

            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetObject<T>(row, Access.CreateModel<T>()));
            }

            return list;
        }

        public int ObjectAccount(string where, string field, string table = "")
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (table == "")
                {
                    sb.Append("select sum(cast(" + field + " as int)) from [" + modelName + "] where 1 = 1 " + where);
                }
                else
                {
                    sb.Append("select sum(cast(" + field + " as int)) from [" + table + "] where 1 = 1 " + where);

                }
                return (Int32)Access.ExecuteScalar(sb.ToString());
            }
            catch { return 0; }
        }
        /*end*/
        public List<T> GetObjects<T>(string fields, int rows, int page, string where, string orderfield, int ordertype, ref int recordcount)
        {
            List<T> list = new List<T>();

            string Sql = GetPageSql(fields, rows, page, where, orderfield, ordertype, ref recordcount);

            DataTable dt = Access.ReturnTableQuery(Sql);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetObject<T>(row, Access.CreateModel<T>(modelName)));
            }

            return list;
        }

        /// <summary>
        /// 基于SQL的分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Sql"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        /// <param name="orderfield"></param>
        /// <param name="ordertype"></param>
        /// <param name="recordcount"></param>
        /// <returns></returns>
        public List<T> GetObjectsBaseSql<T>(string Sql, int rows, int page, string where, string orderfield, int ordertype, ref int recordcount)
        {
            List<T> list = new List<T>();

            string pageSql = GetPageSqlBaseSql(Sql, rows, page, where, orderfield, ordertype, ref recordcount);

            DataTable dt = Access.ReturnTableQuery(pageSql);

            if (dt == null)
            {
                return list;
            }

            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetObject<T>(row, Access.CreateModel<T>(modelName)));
            }

            return list;
        }

        protected string GetPageSql(string fields, int rows, int page, string where, string orderfield, int ordertype, ref int recordcount)
        {
            int TotalPage; int CurrentPageSize; int TotalRecordForPageIndex; string OrderBy; string CutOrderBy;

            if (ordertype == 1)
            {
                OrderBy = " ORDER BY [" + orderfield.Replace(",", "] DESC, [") + "] DESC";
                CutOrderBy = " ORDER BY [" + orderfield.Replace(",", "] ASC, [") + "] ASC";
            }
            else
            {
                OrderBy = " ORDER BY [" + orderfield.Replace(",", "] ASC, [") + "] ASC";
                CutOrderBy = " ORDER BY [" + orderfield.Replace(",", "] DESC, [") + "] DESC";
            }

            recordcount = ObjectCount(where);

            if (rows == 0 || page == 0)
            {
                CurrentPageSize = recordcount;
                TotalRecordForPageIndex = recordcount;
            }
            else
            {
                TotalPage = (recordcount - 1) / rows + 1;
                CurrentPageSize = rows;
                if (TotalPage == page)
                {
                    CurrentPageSize = recordcount % rows;
                    if (CurrentPageSize == 0)
                    {
                        CurrentPageSize = rows;
                    }
                }
                TotalRecordForPageIndex = page * rows;
            }

            return "SELECT * FROM (SELECT TOP " + CurrentPageSize + " * FROM (SELECT TOP " + TotalRecordForPageIndex + " " + fields + " FROM [" + modelName + "] WHERE 1 = 1 " + where + " " + OrderBy + ") TB2 " + CutOrderBy + ") TB3 " + OrderBy;
        }

        /// <summary>
        /// 根据SQL语句，得到分页SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        /// <param name="orderfield"></param>
        /// <param name="ordertype"></param>
        /// <param name="recordcount"></param>
        /// <returns></returns>
        protected string GetPageSqlBaseSql(string sql, int rows, int page, string where, string orderfield, int ordertype, ref int recordcount)
        {
            int TotalPage; int CurrentPageSize; int TotalRecordForPageIndex; string OrderBy; string CutOrderBy;

            if (ordertype == 1)
            {
                OrderBy = " ORDER BY [" + orderfield.Replace(",", "] DESC, [") + "] DESC";
                CutOrderBy = " ORDER BY [" + orderfield.Replace(",", "] ASC, [") + "] ASC";
            }
            else
            {
                OrderBy = " ORDER BY [" + orderfield.Replace(",", "] ASC, [") + "] ASC";
                CutOrderBy = " ORDER BY [" + orderfield.Replace(",", "] DESC, [") + "] DESC";
            }

            recordcount = ObjectCount(where);

            if (rows == 0 || page == 0)
            {
                CurrentPageSize = recordcount;
                TotalRecordForPageIndex = recordcount;
            }
            else
            {
                TotalPage = (recordcount - 1) / rows + 1;
                CurrentPageSize = rows;
                if (TotalPage == page)
                {
                    CurrentPageSize = recordcount % rows;
                    if (CurrentPageSize == 0)
                    {
                        CurrentPageSize = rows;
                    }
                }
                TotalRecordForPageIndex = page * rows;
            }

            return "SELECT * FROM (SELECT TOP " + CurrentPageSize + " * FROM (SELECT TOP " + TotalRecordForPageIndex + " * FROM (" + sql + ") TB1 WHERE 1 = 1 " + where + " " + OrderBy + ") TB2 " + CutOrderBy + ") TB3 " + OrderBy;
        }

    }
}
