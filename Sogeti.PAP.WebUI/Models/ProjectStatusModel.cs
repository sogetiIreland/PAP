using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sogeti.PAP.WebUI.Models
{
    public class ProjectStatusModel1
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public DeliveryModel1 Delivery { get; set; }
        public BusinessDevelopmentModel1 BusinessDevelopment { get; set; }

        public ProjectStatusModel1()
        {
        }

        public ProjectStatusModel1(long Id, DateTime Date, DeliveryModel1 Delivery, BusinessDevelopmentModel1 BusinessDevelopment)
        {
            this.Id = Id;
            this.Date = Date;
            this.Delivery = Delivery;
            this.BusinessDevelopment = BusinessDevelopment;
        }
    }
}