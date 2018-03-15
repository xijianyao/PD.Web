using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

namespace Ankj.Game.Controls
{
    public class RoleBO
    {
        /*通过角色ID获得权限*/
//        public List<Permissions> GetPer(string RoleID)
//        {
//            try
//            {
//                List<Permissions> list = new List<Permissions>();
//                string sql = @" SELECT  [PID]
//                              ,[ParentID]
//                              ,[PName]
//                              ,[PUrl]
//                              ,[Description]
//                              ,[CreateTime]
//                              ,[OpenType]
//                              ,[Sort]
//                          FROM Permissions where PID in(select PID from PerRole  where RoleID='" + RoleID + "')  order by sort";
//                SqlDataReader reder = (SqlDataReader)Access.Access.ExecuteReader(sql);
//                while (reder.Read())
//                {
//                    Permissions per = new Permissions();
//                    per.PID = reder["PID"].ToString();
//                    per.ParentID = reder["ParentID"].ToString();
//                    per.PName = reder["PName"].ToString();
//                    per.PUrl = reder["PUrl"].ToString();
//                    per.Description = reder["Description"].ToString();
//                    per.Sort = Convert.ToInt32(reder["Sort"].ToString() == null ? "0" : reder["Sort"].ToString());
//                    list.Add(per);
//                }
//                return list;
//            }
//            catch
//            {
//                throw;
//            }
//        }
    }
}
