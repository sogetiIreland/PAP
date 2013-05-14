using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sogeti.PAP.DAL
{
    public class Project
    {
        #region Select Methods
        public static DataSet GetProjectDetails(int projectID)
        {
            SqlParameter param = new SqlParameter("@projectID", typeof(System.Int32));
            param.Value = projectID;

            return DataBaseGenerics.GetData("Execute SelectProject @projectID", param, CommandType.Text);
        }

        public static DataSet GetAllProjects(int clientID, int accountManager, int deliveryManager, int lead,
            char serviceLine, char commTerms, char reviewFrequency)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@clientID", SqlDbType.Int));
            paramList[0].Value = clientID;
            paramList.Add(new SqlParameter("@accountManager", SqlDbType.Int));
            paramList[1].Value = accountManager;
            paramList.Add(new SqlParameter("@deliveryManager", SqlDbType.Int));
            paramList[2].Value = deliveryManager;
            paramList.Add(new SqlParameter("@lead", SqlDbType.Int));
            paramList[3].Value = lead;
            paramList.Add(new SqlParameter("@serviceLine", SqlDbType.VarChar, 1));
            paramList[4].Value = serviceLine;
            paramList.Add(new SqlParameter("@commTerms", SqlDbType.VarChar, 1));
            paramList[5].Value = commTerms;
            paramList.Add(new SqlParameter("@reviewFrequency", SqlDbType.VarChar, 1));
            paramList[6].Value = reviewFrequency;

            return DataBaseGenerics.GetData("Execute SelectAllProjects @clientID, @accountManager, @deliveryManager, @lead, @serviceLine, @commTerms, @reviewFrequency",paramList, CommandType.Text, QueryType.Select_Statement);
        }
        #endregion  

        #region Insert Methods
        public static int InsertProject(string projectName, string projectDescription, DateTime startDate, DateTime endDate, DateTime revisedDate,
            int sogetiPractitionerID, int accountManagerID, int deliveryManagerID, int administratorID, int clientID, int leadID,
            char commercialTerms, char reviewFrequency, char sogetiServiceLine)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@projectName", SqlDbType.NVarChar, 50));
            paramList[0].Value = projectName;
            paramList.Add(new SqlParameter("@projectDescription", SqlDbType.NVarChar, 100));
            paramList[1].Value = projectDescription;
            paramList.Add(new SqlParameter("@startDate", SqlDbType.SmallDateTime));
            paramList[2].Value = startDate;
            paramList.Add(new SqlParameter("@endDate", SqlDbType.SmallDateTime));
            paramList[3].Value = endDate;
            paramList.Add(new SqlParameter("@revisedDate", SqlDbType.SmallDateTime));
            paramList[4].Value = revisedDate;
            paramList.Add(new SqlParameter("@sogetiPractitioner", SqlDbType.Int));
            paramList[5].Value = sogetiPractitionerID;
            paramList.Add(new SqlParameter("@accountManager", SqlDbType.Int));
            paramList[6].Value = accountManagerID;
            paramList.Add(new SqlParameter("@deliveryManager", SqlDbType.Int));
            paramList[7].Value = deliveryManagerID;
            paramList.Add(new SqlParameter("@admin", SqlDbType.Int));
            paramList[8].Value = administratorID;
            paramList.Add(new SqlParameter("@clientID", SqlDbType.Int));
            paramList[9].Value = clientID;
            paramList.Add(new SqlParameter("@prjLead", SqlDbType.Int));
            paramList[10].Value = leadID;
            paramList.Add(new SqlParameter("@commTerms", SqlDbType.VarChar, 1));
            paramList[11].Value = commercialTerms;
            paramList.Add(new SqlParameter("@reviewFreq", SqlDbType.VarChar, 1));
            paramList[12].Value = reviewFrequency;
            paramList.Add(new SqlParameter("@sogServiceLine", SqlDbType.VarChar, 1));
            paramList[13].Value = sogetiServiceLine;

            return DataBaseGenerics.InsertData("InsertProject @projectName, @projectDescription, @startDate, @endDate, @revisedDate, @sogetiPractitioner, @accountManager, @deliveryManager, @admin, @clientID, @prjLead, @commTerms, @reviewFreq, @sogServiceLine", paramList, CommandType.Text);
        }
        #endregion

        #region Update Methods
        public static int UpdateProject(int projectID, string projectName, string projectDescription, DateTime startDate, DateTime endDate, DateTime revisedDate,
            int sogetiPractitionerID, int accountManagerID, int deliveryManagerID, int administratorID, int clientID, int leadID,
            char commercialTerms, char reviewFrequency, char sogetiServiceLine, string user)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@projectName", SqlDbType.VarChar, 50));
            paramList[0].Value = projectName;

            paramList.Add(new SqlParameter("@projectDescription", SqlDbType.VarChar, 100));
            paramList[1].Value = projectDescription;

            paramList.Add(new SqlParameter("@startDate", SqlDbType.SmallDateTime));
            paramList[2].Value = startDate;

            paramList.Add(new SqlParameter("@endDate", SqlDbType.SmallDateTime));
            paramList[3].Value = endDate;
            paramList.Add(new SqlParameter("@revisedDate", SqlDbType.SmallDateTime));
            paramList[4].Value = revisedDate;
            paramList.Add(new SqlParameter("@sogetiPractitioner", SqlDbType.Int));
            paramList[5].Value = sogetiPractitionerID;
            paramList.Add(new SqlParameter("@accountManager", SqlDbType.Int));
            paramList[6].Value = accountManagerID;
            paramList.Add(new SqlParameter("@deliveryManager", SqlDbType.Int));
            paramList[7].Value = deliveryManagerID;
            paramList.Add(new SqlParameter("@admin", SqlDbType.Int));
            paramList[8].Value = administratorID;
            paramList.Add(new SqlParameter("@clientID", SqlDbType.Int));
            paramList[9].Value = clientID;
            paramList.Add(new SqlParameter("@prjLead", SqlDbType.Int));
            paramList[10].Value = leadID;
            paramList.Add(new SqlParameter("@commTerms", SqlDbType.VarChar, 1));
            paramList[11].Value = commercialTerms;
            paramList.Add(new SqlParameter("@reviewFreq", SqlDbType.VarChar, 1));
            paramList[12].Value = reviewFrequency;
            paramList.Add(new SqlParameter("@sogServiceLine", SqlDbType.VarChar, 1));
            paramList[13].Value = sogetiServiceLine;
            paramList.Add(new SqlParameter("@projectID", SqlDbType.Int));
            paramList[14].Value = projectID;
            paramList.Add(new SqlParameter("@updatingUser", SqlDbType.VarChar, 30));
            paramList[15].Value = user;


            string query = "EXECUTE UpdateProject @projectName, @projectDescription, @startDate, @endDate, @revisedDate, @sogetiPractitioner, @accountManager, @deliveryManager, @admin, @clientID, @prjLead, @commTerms, @reviewFreq, @sogServiceLine, @projectID, @updatingUser";

            return DAL.DataBaseGenerics.InsertData(query, paramList, CommandType.Text);
        }
        #endregion
    }
}
