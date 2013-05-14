using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sogeti.PAP.WebUI.Models
{
    public class BusinessDevelopmentModel1
    {
        public StatusItemModel1 KnownOpportunity { get; set; }
        public StatusItemModel1 ClientContact { get; set; }

        public BusinessDevelopmentModel1()
        {
        }

        public BusinessDevelopmentModel1(StatusItemModel1 KnownOpportunity, StatusItemModel1 ClientContact)
        {
            this.KnownOpportunity = KnownOpportunity;
            this.ClientContact = ClientContact;
        }
    }
}