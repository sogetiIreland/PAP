using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sogeti.PAP.BAL
{
    public class Delivery
    {
        #region Members
        public int DeliveryId { get; set; }
        public StatusItem DeliverablesAndResults { get; set; }
        public StatusItem Schedule { get; set; }
        public StatusItem CapacityResource { get; set; }
        public StatusItem Scope { get; set; }
        public StatusItem ClientSatisfaction { get; set; }
        public StatusItem IssuesAndRisks { get; set; }
        public StatusItem UseOfTestControl { get; set; }
        public StatusItem EmployeeSatisfaction { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Delivery()
            : this(0, new StatusItem(), new StatusItem(), new StatusItem(), new StatusItem(), new StatusItem(),
                new StatusItem(), new StatusItem(), new StatusItem())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="deliverablesAndResults"></param>
        /// <param name="schedule"></param>
        /// <param name="capacityResource"></param>
        /// <param name="scope"></param>
        /// <param name="clientSatisfication"></param>
        /// <param name="issuesAndRisks"></param>
        /// <param name="useOfTestcontrol"></param>
        /// <param name="employeeSatisfcation"></param>
        public Delivery(int deliveryID, StatusItem deliverablesAndResults, StatusItem schedule, StatusItem capacityResource,
            StatusItem scope, StatusItem clientSatisfication, StatusItem issuesAndRisks, StatusItem useOfTestcontrol,
            StatusItem employeeSatisfcation)
        {
            this.DeliveryId = deliveryID;
            this.DeliverablesAndResults = deliverablesAndResults;
            this.Schedule = schedule;
            this.CapacityResource = capacityResource;
            this.Scope = scope;
            this.ClientSatisfaction = clientSatisfication;
            this.IssuesAndRisks = issuesAndRisks;
            this.UseOfTestControl = useOfTestcontrol;
            this.EmployeeSatisfaction = employeeSatisfcation;
        }
        #endregion

        #region Select Methods
        public static Delivery GetDelivery(int deliveryID)
        {
            Delivery delivery = null;

            using (DataSet dsDeliveryDetails = DAL.Delivery.GetDeivery(deliveryID))
            {
                if ((dsDeliveryDetails != null) && (dsDeliveryDetails.Tables.Count > 0))
                {
                    delivery = new Delivery(Convert.ToInt32(dsDeliveryDetails.Tables[0].Rows[0]["DeliveryID"]),
                        BAL.StatusItem.GetStatusItem(Convert.ToInt32(dsDeliveryDetails.Tables[0].Rows[0]["DeliverablesAndResults_StatusItemID"])),
                        BAL.StatusItem.GetStatusItem(Convert.ToInt32(dsDeliveryDetails.Tables[0].Rows[0]["Schedule_StatusItemID"])),
                        BAL.StatusItem.GetStatusItem(Convert.ToInt32(dsDeliveryDetails.Tables[0].Rows[0]["CapacityResource_StatusItemID"])),
                        BAL.StatusItem.GetStatusItem(Convert.ToInt32(dsDeliveryDetails.Tables[0].Rows[0]["Scope_StatusItemID"])),
                        BAL.StatusItem.GetStatusItem(Convert.ToInt32(dsDeliveryDetails.Tables[0].Rows[0]["ClientSatisfaction_StatusItemID"])),
                        BAL.StatusItem.GetStatusItem(Convert.ToInt32(dsDeliveryDetails.Tables[0].Rows[0]["IssuesAndRisks_StatusItemID"])),
                        BAL.StatusItem.GetStatusItem(Convert.ToInt32(dsDeliveryDetails.Tables[0].Rows[0]["UseOfTestControl_StatusItemID"])),
                        BAL.StatusItem.GetStatusItem(Convert.ToInt32(dsDeliveryDetails.Tables[0].Rows[0]["EmployeeSatisfaction_StatusItemID"])));
                }
            }

            return delivery;
        }
        #endregion
    }
}
