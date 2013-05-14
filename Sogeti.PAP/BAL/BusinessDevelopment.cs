using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sogeti.PAP.BAL
{
    public class BusinessDevelopment
    {
        #region Members
        public int BusinessDevelopmentId { get; set; }
        public StatusItem KnownOpportunity;
        public StatusItem ClientContact;
        #endregion

        #region Constructor
        public BusinessDevelopment()
            : this(0, new StatusItem(), new StatusItem())
        {
        }

        public BusinessDevelopment(int id, StatusItem knownOpportunity, StatusItem clientContract)
        {
            this.KnownOpportunity = knownOpportunity;
            this.ClientContact = clientContract;
        }
        #endregion

        #region Select Methods
        public static BusinessDevelopment GetBusinessDevelopment(int businessDevelopmentID)
        {
            BusinessDevelopment businessDevelopmentDetails = null;

            using (DataSet dsBusDevDetails = DAL.BusinessDevelopment.GetBusinessDevelopment(businessDevelopmentID))
            {
                if ((dsBusDevDetails != null) && (dsBusDevDetails.Tables.Count > 0))
                {
                    businessDevelopmentDetails = new BusinessDevelopment(
                        Convert.ToInt32(dsBusDevDetails.Tables[0].Rows[0]["BusinessDevelopmentId"]),
                        BAL.StatusItem.GetStatusItem(Convert.ToInt32(dsBusDevDetails.Tables[0].Rows[0]["KnownOpportunity_StatusItemID"])),
                        BAL.StatusItem.GetStatusItem(Convert.ToInt32(dsBusDevDetails.Tables[0].Rows[0]["ClientContact_StatusItemID"])));
                }
            }

            return businessDevelopmentDetails;
        }
        #endregion
    }
}
