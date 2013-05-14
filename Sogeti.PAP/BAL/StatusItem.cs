using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sogeti.PAP.BAL
{
    public class StatusItem
    {
        #region Members
        public int StatusItemID { get; set; }
        public Status Status { get; set; }
        public string Comment { get; set; }
        #endregion

        #region Constructors
        public StatusItem()
            : this(0, Status.Blank, "")
        {
        }

        public StatusItem(int statusID, Status status, string comment)
        {
            this.StatusItemID = statusID;
            this.Status = status;
            this.Comment = comment;
        }
        #endregion

        #region Select Methods
        public static StatusItem GetStatusItem(int statusItemID)
        {
            StatusItem item = null;

            using (DataSet dsStatusItemDetails = DAL.StatusItem.GetStatusItem(statusItemID))
            {
                if ((dsStatusItemDetails != null) && (dsStatusItemDetails.Tables.Count > 0))
                {
                    item = new StatusItem(Convert.ToInt32(dsStatusItemDetails.Tables[0].Rows[0]["StatusItemID"]),
                        (BAL.Status)Convert.ToChar(dsStatusItemDetails.Tables[0].Rows[0]["Status"]),
                        dsStatusItemDetails.Tables[0].Rows[0]["Comment"].ToString());
                }
            }

            return item;
        }
        #endregion
    }
}
