using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sogeti.PAP.BAL
{
    public class Client
    {
        #region Members
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientContactNumber { get; set; }
        #endregion

        #region Constructors
        public Client()
            : this(0, "", "", "")
        {
        }

        public Client(int id, string name, string address, string contactNumber)
        {
            this.ClientID = id;
            this.ClientName = name;
            this.ClientAddress = address;
            this.ClientContactNumber = contactNumber;
        }
        #endregion

        #region Select Methods
        public static Client GetClient(int clientID)
        {
            Client client = null;

            using (DataSet dsClientDetails = DAL.Client.GetClientDetails(clientID))
            {
                if ((dsClientDetails != null) && (dsClientDetails.Tables.Count > 0))
                {
                    client = new Client(Convert.ToInt32(dsClientDetails.Tables[0].Rows[0]["ClientID"]),
                        dsClientDetails.Tables[0].Rows[0]["ClientName"].ToString(), dsClientDetails.Tables[0].Rows[0]["ClientAddress"].ToString(),
                        dsClientDetails.Tables[0].Rows[0]["ClientContactNumber"].ToString());
                }
            }

            return client;
        }

        public static List<Client> GetAllClients()
        {
            List<Client> clientList = new List<Client>();
            Client client;

            using (DataSet dsClients = DAL.Client.GetAllClients())
            {
                if ((dsClients != null) && (dsClients.Tables.Count > 0))
                {
                    foreach (DataRow row in dsClients.Tables[0].Rows)
                    {
                        client = new Client(Convert.ToInt32(row["ClientID"]), row["ClientName"].ToString(),
                            row["ClientAddress"].ToString(), row["ClientContactNumber"].ToString());

                        clientList.Add(client);
                    }
                }
            }

            return clientList;
        }
        #endregion

        #region InsertMethods
        public bool InsertClient()
        {
            if (DAL.Client.InsertClient(this.ClientName, this.ClientAddress, this.ClientContactNumber) > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region Update Methods
        public bool UpdateClient()
        {
            if (DAL.Client.UpdateClient(this.ClientID, this.ClientName, this.ClientAddress, this.ClientContactNumber) > 0)
                return true;
            else
                return false;
        }
        #endregion

    }
}
