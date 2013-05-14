using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sogeti.PAP.DAL
{
    public class ProjectStatus
    {
        #region SelectMethods
        public static DataSet GetRecentProjectStatus(int projectID)
        {
            SqlParameter param = new SqlParameter("@projectID", SqlDbType.Int);
            param.Value = projectID;

            return DataBaseGenerics.GetData("EXECUTE SelectRecentProjectStatus @projectID", param, CommandType.Text);
        }

        public static DataSet GetAllStatuses(int projectID)
        {
            SqlParameter param = new SqlParameter("@projectID", SqlDbType.Int);
            param.Value = projectID;

            return DataBaseGenerics.GetData("EXECUTE SelectAllProjectStatus @projectID", param, CommandType.Text);
        }
        #endregion

        #region InsertMethods
        public static int InsertPorjectStatus(int projectID, char deliverablesAndResultsStatus, string deliverablesAndResultsComments, char scheduleStatus,
            string scheduleComment, char capacityResourceStatus, string capacityResourceComment, char scopeStatus, string scopeComment, char clientSatisfactionStatus,
            string clientSatisfactionComment, char issuesAndRisksStatus, string issuesAndRisksComment, char useOfTestcontrolStatus, string useOfTestcontrolComment,
            char employeeSatisfactionStatus, string employeeSatisfactionComment, char knownOpportunityStatus, string knownOpportunityComment, char clientContactStatus, string clientContactComment)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();

            string query = "EXECUTE dbo.InsertProjectStatus @projectID, @deliverablesAndResultsStatus, @deliverablesAndResultsComment, @schedueStatus,"
                    + "@scheduleComment, @capacityResourceStatus, @capacityResourceComment, @scopeStatus, @scopeComment, @clientSatisfactionStatus,"
                    + "@clientSatisfactionComment, @issuesAndRisksStatus, @issuesAndRisksComment, @useOfTestControlStatus, @useOfTestControlComment,"
                    + "@employeeSatisfactionStatus, @employeeSatisfactionComment, @knownOpportunityStatus, @knownOpportunityComment, @clientContactStatus, @clientContactComment";

            #region Parameters

            paramList.Add(new SqlParameter("@projectID", SqlDbType.Int));
            paramList[0].Value = projectID;
            paramList.Add(new SqlParameter("@deliverablesAndResultsStatus", SqlDbType.VarChar, 1));
            paramList[1].Value = deliverablesAndResultsStatus;
            paramList.Add(new SqlParameter("@deliverablesAndResultsComment", SqlDbType.VarChar, -1));
            paramList[2].Value = deliverablesAndResultsComments;
            paramList.Add(new SqlParameter("@schedueStatus", SqlDbType.VarChar, 1));
            paramList[3].Value = scheduleStatus;
            paramList.Add(new SqlParameter("@scheduleComment", SqlDbType.VarChar, -1));
            paramList[4].Value = scheduleComment;
            paramList.Add(new SqlParameter("@capacityResourceStatus", SqlDbType.VarChar, 1));
            paramList[5].Value = capacityResourceStatus;
            paramList.Add(new SqlParameter("@capacityResourceComment", SqlDbType.VarChar, -1));
            paramList[6].Value = capacityResourceComment;
            paramList.Add(new SqlParameter("@scopeStatus", SqlDbType.VarChar, 1));
            paramList[7].Value = scopeStatus;
            paramList.Add(new SqlParameter("@scopeComment", SqlDbType.VarChar, -1));
            paramList[8].Value = scopeComment;
            paramList.Add(new SqlParameter("@clientSatisfactionStatus", SqlDbType.VarChar, 1));
            paramList[9].Value = clientSatisfactionStatus;
            paramList.Add(new SqlParameter("@clientSatisfactionComment", SqlDbType.VarChar, -1));
            paramList[10].Value = clientSatisfactionComment;
            paramList.Add(new SqlParameter("@issuesAndRisksStatus", SqlDbType.VarChar, 1));
            paramList[11].Value = issuesAndRisksStatus;
            paramList.Add(new SqlParameter("@issuesAndRisksComment", SqlDbType.VarChar, -1));
            paramList[12].Value = issuesAndRisksComment;
            paramList.Add(new SqlParameter("@useOfTestControlStatus", SqlDbType.VarChar, 1));
            paramList[13].Value = useOfTestcontrolStatus;
            paramList.Add(new SqlParameter("@useOfTestControlComment", SqlDbType.VarChar, -1));
            paramList[14].Value = useOfTestcontrolComment;
            paramList.Add(new SqlParameter("@employeeSatisfactionStatus", SqlDbType.VarChar, 1));
            paramList[15].Value = employeeSatisfactionStatus;
            paramList.Add(new SqlParameter("@employeeSatisfactionComment", SqlDbType.VarChar, -1));
            paramList[16].Value = employeeSatisfactionComment;
            paramList.Add(new SqlParameter("@knownOpportunityStatus", SqlDbType.VarChar, 1));
            paramList[17].Value = knownOpportunityStatus;
            paramList.Add(new SqlParameter("@knownOpportunityComment", SqlDbType.VarChar, -1));
            paramList[18].Value = knownOpportunityComment;
            paramList.Add(new SqlParameter("@clientContactStatus", SqlDbType.VarChar, 1));
            paramList[19].Value = clientContactStatus;
            paramList.Add(new SqlParameter("@clientContactComment", SqlDbType.VarChar, -1));
            paramList[20].Value = clientContactComment;
            #endregion

            return DataBaseGenerics.InsertData(query, paramList, CommandType.Text);
        }
        #endregion


    }
}
