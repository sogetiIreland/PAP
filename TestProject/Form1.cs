using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sogeti.PAP.BAL.Project prj = new Sogeti.PAP.BAL.Project();
            prj.ProjectID = 5;
            prj.Name = "ProejctTest";
            prj.StartDate = DateTime.Today.AddMonths(-3);
            prj.EndDate = DateTime.Today.AddMonths(9);
            prj.RevisedDate = DateTime.Today;

            prj.AccountManager = Sogeti.PAP.BAL.Person.GetPerson(7);
            prj.Administrator = Sogeti.PAP.BAL.Person.GetPerson(7);
            prj.Client = Sogeti.PAP.BAL.Client.GetClient(1);
            prj.DeliveryManager = Sogeti.PAP.BAL.Person.GetPerson(7);
            prj.Description = "Checking Update Status";
            prj.SogetiPractitioner = Sogeti.PAP.BAL.Person.GetPerson(7);
            prj.CommercialTermsAndConditions = Sogeti.PAP.BAL.CommercialTerms.Fixed_Price;
            prj.ProjectLead = Sogeti.PAP.BAL.Person.GetPerson(7);
            prj.ReviewFrequency = Sogeti.PAP.BAL.Frequency.Annually;
            prj.SogetiDepartment = Sogeti.PAP.BAL.SogetiDepartments.ADNT;

            prj.ProjectStatusList.Add(new Sogeti.PAP.BAL.ProjectStatus());
            prj.ProjectStatusList[0].ProjectDelivery.CapacityResource.Status = Sogeti.PAP.BAL.Status.Alert;
            prj.ProjectStatusList[0].ProjectDelivery.CapacityResource.Comment = "Capacity Resource Alert";
            prj.ProjectStatusList[0].ProjectDelivery.ClientSatisfaction.Status = Sogeti.PAP.BAL.Status.Blank;
            prj.ProjectStatusList[0].ProjectDelivery.ClientSatisfaction.Comment = "Client Satisfaction Blank";
            prj.ProjectStatusList[0].ProjectDelivery.DeliverablesAndResults.Status = Sogeti.PAP.BAL.Status.Excellent;
            prj.ProjectStatusList[0].ProjectDelivery.DeliverablesAndResults.Comment = "Deliverables And Results Excellent";
            prj.ProjectStatusList[0].ProjectDelivery.EmployeeSatisfaction.Status = Sogeti.PAP.BAL.Status.Normal;
            prj.ProjectStatusList[0].ProjectDelivery.EmployeeSatisfaction.Comment = "Employee Satisfaction Normal";
            prj.ProjectStatusList[0].ProjectDelivery.IssuesAndRisks.Status = Sogeti.PAP.BAL.Status.Warning;
            prj.ProjectStatusList[0].ProjectDelivery.IssuesAndRisks.Comment = "Issues And Risks Warning";
            prj.ProjectStatusList[0].ProjectDelivery.Schedule.Status = Sogeti.PAP.BAL.Status.Alert;
            prj.ProjectStatusList[0].ProjectDelivery.Schedule.Comment = "Schedule Alert";
            prj.ProjectStatusList[0].ProjectDelivery.Scope.Status = Sogeti.PAP.BAL.Status.Blank;
            prj.ProjectStatusList[0].ProjectDelivery.Scope.Comment = "Scope Blank";
            prj.ProjectStatusList[0].ProjectDelivery.UseOfTestControl.Status = Sogeti.PAP.BAL.Status.Excellent;
            prj.ProjectStatusList[0].ProjectDelivery.UseOfTestControl.Comment = "Use of Test Control Excellent";

            prj.ProjectStatusList[0].ProjectBusinessDevelopment.ClientContact.Status = Sogeti.PAP.BAL.Status.Normal;
            prj.ProjectStatusList[0].ProjectBusinessDevelopment.ClientContact.Comment = "Client Contact Normal";
            prj.ProjectStatusList[0].ProjectBusinessDevelopment.KnownOpportunity.Status = Sogeti.PAP.BAL.Status.Warning;
            prj.ProjectStatusList[0].ProjectBusinessDevelopment.KnownOpportunity.Comment = "Known Opportunity Warning";
            prj.ProjectStatusList[0].ProjectStatusDate = System.DateTime.Today;

            //prj.UpdateProject();

            prj.ProjectLead.FirstName = "Abdul Naqeeb";
            prj.ProjectLead.LastName = "Abbasi123";
            //prj.ProjectLead.UpdatePerson();

            prj.Client.ClientName = "Vodafone Ireland";
            prj.Client.ClientAddress = "Address of Vodafone";
            prj.Client.ClientContactNumber = "123321";
            prj.Client.UpdateClient();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sogeti.PAP.BAL.Project prj = Sogeti.PAP.BAL.Project.GetProject(2);

            MessageBox.Show(prj.ProjectLead.FullName);
            int x = 10;
            x = x + 1;
        }
    }
}
