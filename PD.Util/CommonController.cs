using System;
using System.Collections.Generic;
using System.Reflection;

namespace PD.Util
{
    public abstract class CommonController
    {
        public Access.Server access = null;

        public CommonController(string modelname, string primarykey)
        {
            access = new Access.Server(modelname, primarykey);
        }

        public int GetOrderType(string ordertype)
        {
            if (ordertype != null && ordertype.ToLower() == "desc") { return 1; } else { return 0; }
        }

        public int ObjectInsert(object model)
        {
            return access.ObjectInsert(model);
        }
        public int ObjectDelete(string value)
        {
            return access.ObjectDelete("and [" + access.primaryKey + "] = '" + value + "'");
        }
        public int ObjectUpdate(object model)
        {
            return access.ObjectUpdate(model);
        }

        public string GetOneField<T>(string field, string where)
        {
            List<T> list = GetObjects<T>("[" + field + "]", 0, 0, where, access.primaryKey, 0);

            string temp = string.Empty; int i = 0;

            foreach (T model in list)
            {
                Type t = model.GetType();
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    if (field == pi.Name)
                    {
                        object value = pi.GetValue(model, null);
                        if (i != 0) { temp += ","; } i++;
                        temp += "," + value.ToString();
                    }
                }
            }

            return temp;
        }
        public string GetTreeId<T>(string ids, string idField, string parentField)
        {
            List<T> list = GetObjects<T>("[" + idField + "]", 0, 0, "and [" + parentField + "] = '" + ids + "'", idField, 0);

            foreach (T model in list)
            {
                Type t = model.GetType();
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    if (idField == pi.Name)
                    {
                        object value = pi.GetValue(model, null);
                        List<T> clist = GetObjects<T>("[" + idField + "]", 0, 0, "and [" + parentField + "] = '" + value.ToString() + "'", idField, 0);
                        if (clist.Count > 0)
                        {
                            ids += "," + GetTreeId<T>(value.ToString(), idField, parentField);
                        }
                        else
                        {
                            ids += "," + value.ToString();
                        }
                    }
                }
            }

            return ids;
        }

        public T GetObject<T>(string value)
        {
            return access.GetObject<T>("and [" + access.primaryKey + "] = '" + value + "'");
        }
        public T GetObjectGuid<T>(string value)
        {
            return access.GetObject<T>("and [" + access.primaryKey + "] = cast('" + value + "' as uniqueidentifier )");
        }
        public T GetObject<T>(string field, string value)
        {
            return access.GetObject<T>("and [" + field + "] = '" + value + "'");
        }

        public int ObjectCount(string where)
        {
            return access.ObjectCount(where);
        }

        public int GetOrderField(string orderfield, string where)
        {
            return access.GetOrderField(orderfield, where);
        }

        public List<T> GetObjects<T>()
        {
            return GetObjects<T>(string.Empty);
        }
        public List<T> GetObjects<T>(string where)
        {
            return access.GetObjects<T>(where);
        }

        public List<T> GetObjects<T>(string orderfield, int ordertype)
        {
            return GetObjects<T>("*", 0, 0, string.Empty, orderfield, ordertype);
        }
        public List<T> GetObjects<T>(int rows, string orderfield, int ordertype)
        {
            return GetObjects<T>("*", rows, 1, string.Empty, orderfield, ordertype);
        }
        public List<T> GetObjects<T>(string where, string orderfield, int ordertype)
        {
            return GetObjects<T>("*", 0, 0, where, orderfield, ordertype);
        }
        public List<T> GetObjects<T>(int rows, string where, string orderfield, int ordertype)
        {
            return GetObjects<T>("*", rows, 1, where, orderfield, ordertype);
        }
        public List<T> GetObjects<T>(int rows, int page, string where, string orderfield, int ordertype)
        {
            return GetObjects<T>("*", rows, page, where, orderfield, ordertype);
        }

        public List<T> GetObjects<T>(int rows, int page, ref int recordcount)
        {
            return GetObjects<T>("*", rows, page, string.Empty, access.primaryKey, 0, ref recordcount);
        }
        public List<T> GetObjects<T>(int rows, int page, string where, ref int recordcount)
        {
            return GetObjects<T>("*", rows, page, where, access.primaryKey, 0, ref recordcount);
        }
        public List<T> GetObjects<T>(int rows, int page, string orderfield, int ordertype, ref int recordcount)
        {
            return GetObjects<T>("*", rows, page, string.Empty, orderfield, ordertype, ref recordcount);
        }
        public List<T> GetObjects<T>(int rows, int page, string where, string orderfield, int ordertype, ref int recordcount)
        {
            return GetObjects<T>("*", rows, page, where, orderfield, ordertype, ref recordcount);
        }

        public List<T> GetObjects<T>(string fields, int rows, int page, string where, string orderfield, int ordertype)
        {
            return access.GetObjects<T>(fields, rows, page, where, orderfield, ordertype);
        }
        public List<T> GetObjects<T>(string fields, int rows, int page, string where, string orderfield, int ordertype, ref int recordcount)
        {
            return access.GetObjects<T>(fields, rows, page, where, orderfield, ordertype, ref recordcount);
        }

        /// <summary>
        /// 基于SQL的分页数据取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="where"></param>
        /// <param name="orderfield"></param>
        /// <param name="ordertype"></param>
        /// <param name="recordcount"></param>
        /// <returns></returns>
        public List<T> GetObjectsBaseSql<T>(string sql, int rows, int page, string where, string orderfield, int ordertype, ref int recordcount)
        {
            return access.GetObjectsBaseSql<T>(sql, rows, page, where, orderfield, ordertype, ref recordcount);
        }
    }
}
