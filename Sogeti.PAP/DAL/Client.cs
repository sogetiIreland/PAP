using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sogeti.PAP.DAL
{
    public class Client
    {
        #region Select Methods
        public static DataSet GetClientDetails(int clientID)
        {
            SqlParameter param = new SqlParameter("@clientID", typeof(System.Int32));
            param.Value = clientID;

            return DataBaseGenerics.GetData("Execute SelectClient @clientID", param, CommandType.Text);
        }

        public static DataSet GetAllClients()
        {
            return DataBaseGenerics.GetData("Execute SelectAllClients", CommandType.Text);
        }
        #endregion

        #region Insert Methods
        public static int InsertClient(string clientName, string clientAddress, string clientContactNumber)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@clientName", SqlDbType.NVarChar, 50));
            paramList[0].Value = clientName;

            paramList.Add(new SqlParameter("@clientAddress", SqlDbType.NVarChar, 100));
            paramList[1].Value = clientAddress;

            paramList.Add(new SqlParameter("@clientContactNumber", SqlDbType.NVarChar, 30));
            paramList[2].Value = clientContactNumber;

            return DataBaseGenerics.InsertData("EXECUTE InsertClient @clientName, @clientAddress, @clientContactNumber", paramList, CommandType.Text);
        }
        #endregion

        #region Update Methods
        public static int UpdateClient(int cliendID, string clientName, string clientAddress, string clientContactNumber)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@clientID", SqlDbType.Int));
            paramList[0].Value = cliendID;
            paramList.Add(new SqlParameter("@clientName", SqlDbType.VarChar, 50));
            paramList[1].Value = clientName;
            paramList.Add(new SqlParameter("@clientAddress", SqlDbType.VarChar, 100));
            paramList[2].Value = clientAddress;
            paramList.Add(new SqlParameter("@clientContactNumber", SqlDbType.VarChar, 30));
            paramList[3].Value = clientContactNumber;

            return DAL.DataBaseGenerics.InsertData("EXECUTE UpdateClient @clientID, @clientName, @clientAddress, @clientContactNumber", paramList, CommandType.Text);
        }
        #endregion
    }
}
