using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sogeti.PAP.WebUI.Models
{
    public class ProjectModel1
    {
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string SogetiPractitioner { get; set; }
        public string AccountManager { get; set; }
        public string DeliveryManager { get; set; }
        public string Administrator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RevisedDate { get; set; }

        public List<ProjectStatusModel1> ProjectStatusList { get; set; }

        public ProjectModel1()
        {
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.RevisedDate = DateTime.Now;
        }

        public ProjectModel1(int Id, string Name, string Description, string Client, string SogetiPractitioner, List<ProjectStatusModel1> ProjectStatusList)
        {
            this.ProjectID = Id;
            this.Name = Name;
            this.Description = Description;
            this.Client = Client;
            this.SogetiPractitioner = SogetiPractitioner;

            this.AccountManager = "Account Manager";
            this.DeliveryManager = "Delivery Manager";
            this.Administrator = "Administrator";
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.RevisedDate = DateTime.Now;

            this.ProjectStatusList = ProjectStatusList;
        }

    }
}