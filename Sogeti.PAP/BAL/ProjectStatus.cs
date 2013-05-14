using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sogeti.PAP.BAL
{
    public class ProjectStatus
    {
        #region Members
        public int ProjectStatusID { get; set; }
        public DateTime ProjectStatusDate { get; set; }
        public Delivery ProjectDelivery { get; set; }
        public BusinessDevelopment ProjectBusinessDevelopment { get; set; }
        #endregion

        #region Constructors
        public ProjectStatus()
            : this(0, DateTime.MinValue, new Delivery(), new BusinessDevelopment())
        {
        }

        public ProjectStatus(int statusID, DateTime date, Delivery delivery, BusinessDevelopment businessDevelopment)
        {
            this.ProjectStatusID = statusID;
            this.ProjectStatusDate = date;
            this.ProjectDelivery = delivery;
            this.ProjectBusinessDevelopment = businessDevelopment;
        }
        #endregion

        #region Select Methods
        public static ProjectStatus GetRecentProjectStatus(int projectID)
        {
            ProjectStatus prjStatus = null;

            using (DataSet dsStatusDetails = DAL.ProjectStatus.GetRecentProjectStatus(projectID))
            {
                if ((dsStatusDetails != null) && (dsStatusDetails.Tables.Count > 0))
                {
                    if (dsStatusDetails.Tables[0].Rows.Count > 0)
                    {
                        prjStatus = new ProjectStatus(Convert.ToInt32(dsStatusDetails.Tables[0].Rows[0]["ProjectStatusID"]),
                            Convert.ToDateTime(dsStatusDetails.Tables[0].Rows[0]["ProjectStatusDate"].ToString()),
                            Delivery.GetDelivery(Convert.ToInt32(dsStatusDetails.Tables[0].Rows[0]["ProjectDelivery_DeliveryId"])),
                            BusinessDevelopment.GetBusinessDevelopment(Convert.ToInt32(dsStatusDetails.Tables[0].Rows[0]["ProjectBusinessDevelopment_BusinessDevelopmentId"])));
                    }
                    else
                        prjStatus = new ProjectStatus();
                }
            }

            return prjStatus;
        }

        public static List<ProjectStatus> GetAllStatus(int projectID)
        {
            List<ProjectStatus> prjStatusList = new List<ProjectStatus>();
            ProjectStatus status = null;

            using (DataSet dsProjectStatusDetails = DAL.ProjectStatus.GetAllStatuses(projectID))
            {
                if ((dsProjectStatusDetails != null) && (dsProjectStatusDetails.Tables.Count > 0) && (dsProjectStatusDetails.Tables[0].Rows.Count > 0))
                {
                    foreach (DataRow row in dsProjectStatusDetails.Tables[0].Rows)
                    {
                        status = new ProjectStatus(Convert.ToInt32(row["ProjectStatusID"]),
                            Convert.ToDateTime(row["ProjectStatusDate"]),
                            Delivery.GetDelivery(Convert.ToInt32(row["ProjectDelivery_DeliveryId"])),
                            BusinessDevelopment.GetBusinessDevelopment(Convert.ToInt32(row["ProjectBusinessDevelopment_BusinessDevelopmentId"])));

                        prjStatusList.Add(status);
                    }
                }
                
            }

            return prjStatusList;
        }
        #endregion

        #region InsertMethod
        public bool InsertStatus(int projectID)
        {
            int result = DAL.ProjectStatus.InsertPorjectStatus(projectID, Convert.ToChar(this.ProjectDelivery.DeliverablesAndResults.Status), this.ProjectDelivery.DeliverablesAndResults.Comment,
                Convert.ToChar(this.ProjectDelivery.Schedule.Status), this.ProjectDelivery.Schedule.Comment, Convert.ToChar(this.ProjectDelivery.CapacityResource.Status), this.ProjectDelivery.CapacityResource.Comment,
                Convert.ToChar(this.ProjectDelivery.Scope.Status), this.ProjectDelivery.Scope.Comment, Convert.ToChar(this.ProjectDelivery.ClientSatisfaction.Status), this.ProjectDelivery.ClientSatisfaction.Comment,
                Convert.ToChar(this.ProjectDelivery.IssuesAndRisks.Status), this.ProjectDelivery.IssuesAndRisks.Comment, Convert.ToChar(this.ProjectDelivery.UseOfTestControl.Status), this.ProjectDelivery.UseOfTestControl.Comment,
                Convert.ToChar(this.ProjectDelivery.EmployeeSatisfaction.Status), this.ProjectDelivery.EmployeeSatisfaction.Comment, Convert.ToChar(this.ProjectBusinessDevelopment.KnownOpportunity.Status), this.ProjectBusinessDevelopment.KnownOpportunity.Comment,
                Convert.ToChar(this.ProjectBusinessDevelopment.ClientContact.Status), this.ProjectBusinessDevelopment.ClientContact.Comment);
            if (result > 0)
                return true;
            else
                return false;

        }
        #endregion
    }
}
