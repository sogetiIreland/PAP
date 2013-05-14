using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sogeti.PAP.DAL
{
    public class Person
    {
        #region Select Methods
        public static DataSet GetPersonDetails(int personID)
        {
            SqlParameter param = new SqlParameter("@PersonID", typeof(System.Int32));
            param.Value = personID;
            return DAL.DataBaseGenerics.GetData("Execute SelectPerson @PersonID", param, CommandType.Text);
        }

        public static DataSet GetallPersons()
        {
            return DAL.DataBaseGenerics.GetData("Execute SelectAllPersons", CommandType.Text);
        }
        #endregion

        #region Insert Methods
        public static int InsertPerson(string firstName, string lastName)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@firstName", SqlDbType.NVarChar, 50));
            paramList[0].Value = firstName;
            paramList.Add(new SqlParameter("@lastName", SqlDbType.NVarChar, 50));
            paramList[1].Value = lastName;

            return DataBaseGenerics.InsertData("EXECUTE InsertPerson @firstName, @lastName", paramList, CommandType.Text);
        }
        #endregion

        #region Update Methods
        public static int UpdatePerson(int personID, string firstName, string lastName)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@personID", SqlDbType.Int));
            paramList[0].Value = personID;
            paramList.Add(new SqlParameter("@firstName", SqlDbType.VarChar, 50));
            paramList[1].Value = firstName;
            paramList.Add(new SqlParameter("@lastName", SqlDbType.VarChar, 50));
            paramList[2].Value = lastName;

            return DAL.DataBaseGenerics.InsertData("EXECUTE UpdatePerson @personID, @firstName, @lastName", paramList, CommandType.Text);
        }
        #endregion
    }
}
