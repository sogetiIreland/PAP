using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sogeti.PAP.DAL
{
    public static class User
    {
        public static DataSet VerifyUser(string userName, string password)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@username", SqlDbType.VarChar, 20));
            paramList[0].Value = userName;

            paramList.Add(new SqlParameter("@password", SqlDbType.VarChar, 20));
            paramList[1].Value = password;

            return DataBaseGenerics.GetData("Execute VerifyLogin @username, @password", paramList, CommandType.Text, QueryType.Select_Statement);
        }
    }
}
