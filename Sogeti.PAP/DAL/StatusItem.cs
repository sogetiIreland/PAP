using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sogeti.PAP.DAL
{
    public class StatusItem
    {
        #region Select Method
        public static DataSet GetStatusItem(int statusItemID)
        {
            SqlParameter param = new SqlParameter("@statusItemID", SqlDbType.Int);
            param.Value = statusItemID;

            return DataBaseGenerics.GetData("EXECUTE SelectStatusItem @statusItemID", param, CommandType.Text);
        }
        #endregion
    }
}
