using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sogeti.PAP.DAL
{
    public static class Login
    {
        public static DataSet VerifyLoginDetails(string username, string password)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@username", System.Data.SqlDbType.VarChar, 30));
            paramList[0].Value = username;

            paramList.Add(new SqlParameter("@password", System.Data.SqlDbType.VarChar, 30));
            paramList[1].Value = password;

            return DataBaseGenerics.GetData("Execute VerifyLogin @username, @password", paramList, CommandType.Text, QueryType.Select_Statement);
        }
    }
}
