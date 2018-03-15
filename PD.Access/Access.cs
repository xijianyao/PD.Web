using System;
using System.Data;
using System.Configuration;
using System.Reflection;
using System.Data.SqlClient;

namespace PD.Access
{
    public static class Access
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; }
        }

        public static T CreateModel<T>(string model)
        {
            return (T)Assembly.Load("PD.Model").CreateInstance("PD.Model" + "." + model);
        }
        public static T CreateModel<T>()
        {
            Type t = typeof(T);
            return (T)Assembly.Load("PD.Model").CreateInstance(t.FullName);
        }
        public static T CreateAccess<T>(string model)
        {
            return (T)Assembly.Load("PD.Controller").CreateInstance("PD.Controller" + "." + model);
        }

        public static int ExecuteNonQuery(string strSql)
        {
            try
            {
                return SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, strSql);
            }
            catch { return 0; }
        }

        public static object ExecuteScalar(string strSql)
        {
            try
            {
                return SqlHelper.ExecuteScalar(ConnectionString, CommandType.Text, strSql);
            }
            catch { return null; }
        }

        public static object ExecuteReader(string strSql)
        {
            try
            {
                return SqlHelper.ExecuteReader(ConnectionString, CommandType.Text, strSql);
            }
            catch { return null; }
        }

        public static DataTable ReturnTableQuery(string strSql)
        {
            try
            {
                return SqlHelper.ExecuteDataset(ConnectionString, CommandType.Text, strSql).Tables[0];
            }
            catch { return new DataTable(); }
        }

        //----------------------------------------------------//

        public static void SetLog(string table, string type, string value)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@LogId", SqlDbType.VarChar, 32),
                    new SqlParameter("@Table", SqlDbType.VarChar, 80),
                    new SqlParameter("@Type", SqlDbType.VarChar, 80),
                    new SqlParameter("@Sql", SqlDbType.Text),
                    new SqlParameter("@InsertTime", SqlDbType.DateTime)
                };

                parameters[0].Value = Guid.NewGuid().ToString().Replace("-", string.Empty);
                parameters[1].Value = table;
                parameters[2].Value = type;
                parameters[3].Value = value;
                parameters[4].Value = DateTime.Now;

                ExecProcedure("SetLogs", parameters);
            }
            catch (Exception ex) { throw ex; }
        }

        public static void ExecProcedure(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                command.ExecuteScalar();

                connection.Close();
            }
        }

        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) && (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }
    }
}
