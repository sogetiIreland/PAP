using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sogeti.PAP.DAL
{
    public class BusinessDevelopment
    {
        #region Select Method
        public static DataSet GetBusinessDevelopment(int businessDevelopmentID)
        {
            SqlParameter param = new SqlParameter("@businessDevelopmentID", SqlDbType.Int);
            param.Value = businessDevelopmentID;

            return DataBaseGenerics.GetData("EXECUTE SelectBusinessDevelopment @businessDevelopmentID", param, CommandType.Text);
        }
        #endregion
    }
}
