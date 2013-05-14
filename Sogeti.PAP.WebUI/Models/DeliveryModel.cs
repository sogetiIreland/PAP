using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sogeti.PAP.WebUI.Models
{
    public class DeliveryModel1
    {
        public StatusItemModel1 DeliverablesAndResults { get; set; }
        public StatusItemModel1 Schedule { get; set; }
        public StatusItemModel1 CapacityResources { get; set; }
        public StatusItemModel1 Scope { get; set; }
        public StatusItemModel1 ClientSatisfaction { get; set; }
        public StatusItemModel1 IssuesAndRisks { get; set; }
        public StatusItemModel1 UseOfTestControl { get; set; }
        public StatusItemModel1 EmployeeSatisfactionIssues { get; set; }

        public DeliveryModel1()
        {
        }

        public DeliveryModel1(StatusItemModel1 DeliverablesAndResults, StatusItemModel1 Schedule, StatusItemModel1 CapacityResources,
            StatusItemModel1 Scope, StatusItemModel1 ClientSatisfaction, StatusItemModel1 IssuesAndRisks, StatusItemModel1 UseOfTestControl,
            StatusItemModel1 EmployeeSatisfactionIssues)
        {
            this.DeliverablesAndResults = DeliverablesAndResults;
            this.Schedule = Schedule;
            this.CapacityResources = CapacityResources;
            this.Scope = Scope;
            this.ClientSatisfaction = ClientSatisfaction;
            this.IssuesAndRisks = IssuesAndRisks;
            this.UseOfTestControl = UseOfTestControl;
            this.EmployeeSatisfactionIssues = EmployeeSatisfactionIssues;
        }
    }
}