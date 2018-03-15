using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PD.Util
{
    public static class JsonTransform
    {
        public static string SerializeObject(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static string SerializeObject<T>(List<T> list, string idField, string textField)
        {
            string json = string.Empty; int count = 0;

            foreach (T model in list)
            {
                Type t = model.GetType();

                if (count != 0) { json += ","; }
                count++;
                string id = string.Empty;
                string text = string.Empty;

                foreach (PropertyInfo pi in t.GetProperties())
                {
                    object value = pi.GetValue(model, null);

                    if (idField == pi.Name) { id = value.ToString(); }
                    else if (textField == pi.Name) { text = value.ToString(); }
                }

                json += "{\"value\":\"" + id + "\",\"text\":\"" + text + "\"}";
            }

            return "[" + json + "]";
        }

        public static string SerializeObject<T>(List<T> list, string idField, string textField, string parentFiled)
        {
            string json = string.Empty; int count = 0;

            foreach (T model in list)
            {
                Type t = model.GetType();

                if (count != 0) { json += ","; }
                count++;
                string id = string.Empty;
                string text = string.Empty;
                string parent = string.Empty;

                foreach (PropertyInfo pi in t.GetProperties())
                {
                    object value = pi.GetValue(model, null);

                    if (idField == pi.Name) { id = value.ToString(); }
                    else if (textField == pi.Name) { text = value.ToString(); }
                    else if (parentFiled == pi.Name) { parent = value.ToString(); }
                }

                json += "{\"id\":\"" + id + "\",\"text\":\"" + text + "\",\"parent\":\"" + parent + "\"}";
            }

            return "[" + json + "]";
        }

        public static string SerializeObject<T>(List<T> list, string table, string[] fields, List<JsonMapTable> maplist)
        {
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";

            List<T> ilist = new List<T>();

            foreach (T model in list)
            {
                T imodel = Access.Access.CreateModel<T>(table);
                Type t = imodel.GetType();

                foreach (PropertyInfo pi in t.GetProperties())
                {
                    object value = pi.GetValue(model, null);

                    if (fields.Contains(pi.Name))
                    {
                        bool setvalue = true;
                        foreach (JsonMapTable jmt in maplist)
                        {
                            if (jmt.MapExist == pi.Name)
                            {
                                CommonController icoml = Access.Access.CreateAccess<CommonController>(jmt.MapTable + "Controller");
                                object cmodel = icoml.access.GetObject<object>("and [" + icoml.access.primaryKey + "] = '" + value + "'");
                                if (cmodel != null)
                                {
                                    pi.SetValue(imodel, cmodel.GetType().GetProperty(jmt.MapRelated).GetValue(cmodel, null), null);
                                }
                                else { pi.SetValue(imodel, value, null); } setvalue = false; break;
                            }
                        }
                        if (setvalue) { pi.SetValue(imodel, value, null); }
                    }
                }

                ilist.Add(imodel);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(ilist, timeConverter);
        }

        public static string SerializeObject<T>(List<T> list, string table, string[] fields, List<JsonMapTable> maplist, int recordcount)
        {
            Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";

            List<T> ilist = new List<T>();

            foreach (T model in list)
            {
                T imodel = Access.Access.CreateModel<T>(table);
                Type t = imodel.GetType();

                foreach (PropertyInfo pi in t.GetProperties())
                {
                    object value = pi.GetValue(model, null);

                    if (fields.Contains(pi.Name))
                    {
                        bool setvalue = true;
                        foreach (JsonMapTable jmt in maplist)
                        {
                            if (jmt.MapExist == pi.Name)
                            {
                                CommonController icoml = Access.Access.CreateAccess<CommonController>(jmt.MapTable + "Controller");
                                object cmodel = icoml.access.GetObject<object>("and [" + icoml.access.primaryKey + "] = '" + value + "'");
                                if (cmodel != null)
                                {
                                    pi.SetValue(imodel, cmodel.GetType().GetProperty(jmt.MapRelated).GetValue(cmodel, null), null);
                                }
                                else { pi.SetValue(imodel, value, null); } setvalue = false; break;
                            }
                        }
                        if (setvalue) { pi.SetValue(imodel, value, null); }
                    }
                }

                ilist.Add(imodel);
            }

            return "{\"total\":\"" + recordcount + "\",\"rows\":" + Newtonsoft.Json.JsonConvert.SerializeObject(ilist, timeConverter) + "}";
        }
    }
}
