using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sogeti.PAP.WebUI.Models
{
    public class ClientModel1
    {
        #region Members
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientContactNumber { get; set; }
        #endregion

        #region Constructors
        public ClientModel1()
            : this(0, "", "", "")
        {
        }

        public ClientModel1(int id, string name, string address, string contactNumber)
        {
            this.ClientID = id;
            this.ClientName = name;
            this.ClientAddress = address;
            this.ClientContactNumber = contactNumber;
        }
        #endregion
    }
 
}