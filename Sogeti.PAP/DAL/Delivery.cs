using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sogeti.PAP.DAL
{
    public class Delivery
    {
        #region Select Method
        public static DataSet GetDeivery(int deliveryID)
        {
            SqlParameter param = new SqlParameter("@deliveryID", SqlDbType.Int);
            param.Value = deliveryID;

            return DataBaseGenerics.GetData("EXECUTE SelectDelivery @deliveryID", param, CommandType.Text);
        }
        #endregion
    }
}
