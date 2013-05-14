using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sogeti.PAP.BAL;
using Sogeti.PAP.WebUI.Models;
using System.Text;

namespace Sogeti.PAP.WebUI.Controllers
{
    public class HomeController : Controller
    {

        #region Side Screens
        public ActionResult NewClient()
        {
            if (Session["User"] == null)
                return RedirectToAction("", "Home");

            //Heading
            ViewBag.Message = "Add New Client";

            return View();
        }

        public ActionResult AddNewClient()
        {
            BAL.Client client = new Client(0, Request.Form["ClientName"], Request.Form["ClientAddress"], Request.Form["ClientContactNumber"]);
            client.InsertClient();

            return RedirectToAction("Dashboard", "Home");
        }

        public ActionResult NewPerson()
        {
            if (Session["User"] == null)
                return RedirectToAction("", "Home");

            ViewBag.Message = "Add New Person";

            return View();
        }

        public ActionResult AddNewPerson()
        {
            BAL.Person person = new Person(0, Request.Form["FirstName"], Request.Form["LastName"]);
            person.InsertPerson();

            return RedirectToAction("Dashboard", "Home");
        }

        public ActionResult UpdateClient()
        {
            if (Session["User"] == null)
                return RedirectToAction("", "Home");

            //Heading
            ViewBag.Message = "Update Client";

            //Create List
            //Create Client list for update
            List<SelectListItem> ClientList = new List<SelectListItem>();
            foreach (BAL.Client client in BAL.Client.GetAllClients())
            {
                ClientList.Add(new SelectListItem { Value = client.ClientID.ToString(), Text = client.ClientName });
            }
            ViewBag.ClientList = ClientList;

            return View();
        }

        public ActionResult UpdateExistingClient(string ClientList)
        {
            BAL.Client client = Client.GetClient(Convert.ToInt32(Request.Form["ClientList"]));
            client.ClientName = Request.Form["ClientName"];
            client.ClientAddress = Request.Form["Address"];
            client.ClientContactNumber = Request.Form["ContactNumber"];
            client.UpdateClient();
            return RedirectToAction("Dashboard", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult GetClientData(string clientID)
        {
            Client client = Client.GetClient(Convert.ToInt32(clientID));
            if (client != null)
            {
                return Json(new
                {
                    success = true,
                    clientName = client.ClientName,
                    clientAddress = client.ClientAddress,
                    clientContact = client.ClientContactNumber
                });
            }
            return Json(new { success = false });

        }

        public ActionResult UpdatePerson()
        {
            if (Session["User"] == null)
                return RedirectToAction("", "Home");

            ViewBag.Message = "Update Person";

            //Create List
            //Create Client list for update
            List<SelectListItem> PersonList = new List<SelectListItem>();
            foreach (BAL.Person person in BAL.Person.GetAllPersons())
            {
                PersonList.Add(new SelectListItem { Value = person.PersonID.ToString(), Text = person.FullName });
            }
            ViewBag.PersonList = PersonList;

            return View();
        }

        [HttpPost]
        public JsonResult GetPersonData(string personID)
        {
            Person person = Person.GetPerson(Convert.ToInt32(personID));
            if (person != null)
            {
                return Json(new { success = true, firstName = person.FirstName, lastName = person.LastName });
            }
            return Json(new { success = false });
        }

        public ActionResult UpdateExistingPerson()
        {
            Person person = Person.GetPerson(Convert.ToInt32(Request.Form["PersonList"]));
            person.FirstName = Request.Form["FirstName"];
            person.LastName = Request.Form["LastName"];
            person.UpdatePerson();
            return RedirectToAction("Dashboard", "Home");
        }
        #endregion

        #region Project related
        public ActionResult NewProject()
        {
            if (Session["User"] == null)
                return RedirectToAction("", "Home");

            ViewBag.Message = "New Project";

            List<SelectListItem> ClientList = new List<SelectListItem>();
            foreach (BAL.Client client in BAL.Client.GetAllClients())
            {
                ClientList.Add(new SelectListItem { Value = client.ClientID.ToString(), Text = client.ClientName });
            }
            ViewBag.ClientList = ClientList;

            List<BAL.Person> personList = BAL.Person.GetAllPersons();

            List<SelectListItem> ProjectLeadList = new List<SelectListItem>();
            foreach (BAL.Person person in personList)
            {
                ProjectLeadList.Add(new SelectListItem { Value = person.PersonID.ToString(), Text = person.FirstName + " " + person.LastName });
            }
            ViewBag.ProjectLeadList = ProjectLeadList;

            //Department List
            ViewBag.DepartmentList = Enum.GetValues(typeof(SogetiDepartments)).Cast<SogetiDepartments>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((char)v).ToString()
            });

            //Commercial Terms List
            ViewBag.CommercialTermsList = Enum.GetValues(typeof(CommercialTerms)).Cast<CommercialTerms>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((char)v).ToString()
            });

            //Review Frequency List
            ViewBag.ReviewFrequencyList = Enum.GetValues(typeof(Frequency)).Cast<Frequency>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((char)v).ToString()
            });

            List<SelectListItem> SogetiPractitionerList = new List<SelectListItem>();
            foreach (BAL.Person person in personList)
            {
                SogetiPractitionerList.Add(new SelectListItem { Value = person.PersonID.ToString(), Text = person.FirstName + " " + person.LastName });
            }
            ViewBag.SogetiPractitionerList = SogetiPractitionerList;

            List<SelectListItem> AccountManagerList = new List<SelectListItem>();
            foreach (BAL.Person person in personList)
            {
                AccountManagerList.Add(new SelectListItem { Value = person.PersonID.ToString(), Text = person.FirstName + " " + person.LastName });
            }
            ViewBag.AccountManagerList = AccountManagerList;

            List<SelectListItem> DeliveryManagerList = new List<SelectListItem>();
            foreach (BAL.Person person in personList)
            {
                DeliveryManagerList.Add(new SelectListItem { Value = person.PersonID.ToString(), Text = person.FirstName + " " + person.LastName });
            }
            ViewBag.DeliveryManagerList = DeliveryManagerList;

            List<SelectListItem> AdministratorList = new List<SelectListItem>();
            foreach (BAL.Person person in personList)
            {
                AdministratorList.Add(new SelectListItem { Value = person.PersonID.ToString(), Text = person.FirstName + " " + person.LastName });
            }
            ViewBag.AdministratorList = AdministratorList;

            return View();
        }

        public ActionResult AddNewProject()
        {
            BAL.Project prj = new Project();
            prj.ProjectID = 0;
            prj.Name = Request.Form["ProjectName"];
            prj.Client = BAL.Client.GetClient(Convert.ToInt32(Request.Form["ClientList"]));
            prj.ProjectLead = BAL.Person.GetPerson(Convert.ToInt32(Request.Form["ProjectLeadList"]));

            String department = Request.Form["DepartmentList"];
            if (department == "A")
                prj.SogetiDepartment = SogetiDepartments.ADNT;
            else if (department == "T")
                prj.SogetiDepartment = SogetiDepartments.Test;
            else if (department == "S")
                prj.SogetiDepartment = SogetiDepartments.SAP;

            prj.Description = Request.Form["ProjectDescription"];

            String terms = Request.Form["CommercialTermsList"];
            if (terms == "F")
                prj.CommercialTermsAndConditions = CommercialTerms.Fixed_Price;
            else if (terms == "V")
                prj.CommercialTermsAndConditions = CommercialTerms.Time_And_Material;

            String frequency = Request.Form["ReviewFrequencyList"];
            if (frequency == "D")
                prj.ReviewFrequency = Frequency.Daily;
            else if (frequency == "W")
                prj.ReviewFrequency = Frequency.Weekly;
            else if (frequency == "M")
                prj.ReviewFrequency = Frequency.Monthly;
            else if (frequency == "Q")
                prj.ReviewFrequency = Frequency.Quaterly;
            else if (frequency == "A")
                prj.ReviewFrequency = Frequency.Annually;

            prj.RevisedDate = Convert.ToDateTime(Request.Form["ProjectStartDate"]);
            prj.SogetiPractitioner = BAL.Person.GetPerson(Convert.ToInt32(Request.Form["SogetiPractitionerList"]));
            prj.AccountManager = BAL.Person.GetPerson(Convert.ToInt32(Request.Form["AccountManagerList"]));
            prj.DeliveryManager = BAL.Person.GetPerson(Convert.ToInt32(Request.Form["DeliveryManagerList"]));
            prj.Administrator = BAL.Person.GetPerson(Convert.ToInt32(Request.Form["AdministratorList"]));
            prj.StartDate = Convert.ToDateTime(Request.Form["ProjectStartDate"]);
            prj.EndDate = Convert.ToDateTime(Request.Form["ProjectEndDate"]);

            prj.InsertProject();

            return RedirectToAction("Dashboard", "Home");
        }

        public ActionResult UpdateProject()
        {
            if (Session["User"] == null)
                return RedirectToAction("", "Home");

            ViewBag.Message = "Update Project Details";

            List<SelectListItem> ProjectDetails = new List<SelectListItem>();
            foreach (BAL.Project prj in BAL.Project.GetAllProjects())
            {
                ProjectDetails.Add(new SelectListItem
                {
                    Value = prj.ProjectID.ToString(),
                    Text = prj.Name
                });
            }

            ViewBag.ProjectList = ProjectDetails;

            List<SelectListItem> clientList = new List<SelectListItem>();
            foreach (BAL.Client client in BAL.Client.GetAllClients())
            {
                clientList.Add(
                    new SelectListItem
                    {
                        Value = client.ClientID.ToString(),
                        Text = client.ClientName
                    }
                    );
            }
            ViewBag.ClientList = clientList;

            List<SelectListItem> personList = new List<SelectListItem>();
            foreach (BAL.Person person in BAL.Person.GetAllPersons())
            {
                personList.Add(
                    new SelectListItem
                    {
                        Value = person.PersonID.ToString(),
                        Text = person.FullName.ToString()
                    }
                    );
            }

            ViewBag.SogetiPractitioner = personList;
            ViewBag.AccountManager = personList;
            ViewBag.DeliveryManager = personList;
            ViewBag.Administrator = personList;
            ViewBag.Lead = personList;

            //Department List
            ViewBag.ServiceLine = Enum.GetValues(typeof(SogetiDepartments)).Cast<SogetiDepartments>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((char)v).ToString()
            });

            //Commercial Terms List
            ViewBag.CommercialTC = Enum.GetValues(typeof(CommercialTerms)).Cast<CommercialTerms>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((char)v).ToString()
            });

            //Review Frequency List
            ViewBag.ReivewFrequency = Enum.GetValues(typeof(Frequency)).Cast<Frequency>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((char)v).ToString()
            });


            return View();
        }

        public ActionResult UpdateExistingProject()
        {
            Project prj = Project.GetProject(Convert.ToInt32(Request.Form["ProjectList"]));
            prj.Name = Request.Form["ProjectName"];
            prj.Description = Request.Form["ProjectDescription"];
            prj.AccountManager = Person.GetPerson(Convert.ToInt32(Request.Form["AccountManager"]));
            prj.Administrator = Person.GetPerson(Convert.ToInt32(Request.Form["Administrator"]));
            prj.Client = Client.GetClient(Convert.ToInt32(Request.Form["ClientList"]));
            prj.CommercialTermsAndConditions = (CommercialTerms)Convert.ToChar(Request.Form["CommercialTC"]);
            prj.DeliveryManager = Person.GetPerson(Convert.ToInt32(Request.Form["DeliveryManager"]));
            prj.EndDate = Convert.ToDateTime(Request.Form["ProjectEndDate"]);
            prj.ProjectLead = Person.GetPerson(Convert.ToInt32(Request.Form["Lead"]));
            prj.ReviewFrequency = (Frequency)Convert.ToChar(Request.Form["ReivewFrequency"]);
            prj.SogetiDepartment = (SogetiDepartments)Convert.ToChar(Request.Form["ServiceLine"]);
            prj.SogetiPractitioner = Person.GetPerson(Convert.ToInt32(Request.Form["SogetiPractitioner"]));
            prj.StartDate = Convert.ToDateTime(Request.Form["ProjectStartDate"]);
            prj.UpdateProject(((Sogeti.PAP.BAL.User)Session["User"]).UserName);
            return RedirectToAction("Dashboard", "Home");
        }

        [HttpPost]
        public JsonResult GetProjectData(string projectID)
        {
            Project prj = Project.GetProject(Convert.ToInt32(projectID));
            if (prj != null)
            {
                return Json(new
                {
                    success = true,
                    projectName = prj.Name,
                    projectDescription = prj.Description,
                    client = prj.Client.ClientID,
                    practitioner = prj.SogetiPractitioner.PersonID,
                    accountManager = prj.AccountManager.PersonID,
                    deliveryManager = prj.DeliveryManager.PersonID,
                    administrator = prj.Administrator.PersonID,
                    startDate = prj.StartDate.ToString("dd/MM/yyyy"),
                    endDate = prj.EndDate.ToString("dd/MM/yyyy"),
                    revisedDate = prj.RevisedDate.ToString("dd/MM/yyyy"),
                    lead = prj.ProjectLead.PersonID,
                    reviewFreq = (char)prj.ReviewFrequency,
                    commercialTC = (char)prj.CommercialTermsAndConditions,
                    serviceLine = (char)prj.SogetiDepartment
                });
            }
            return Json(new { success = false });
        }
        #endregion

        #region ProjectHistory
        public ActionResult ProjectHistory(string projectID)
        {
            if (Session["User"] == null)
                return RedirectToAction("", "Home");

            Project prj = BAL.Project.GetProjectWithStatusHistory(Convert.ToInt32(projectID));
            ViewBag.Project = prj;

            return View(prj);
        }
        #endregion

        #region ProjectStatus
        public ActionResult NewProjectStatus(String ProjectId)
        {
            if (Session["User"] == null)
                return RedirectToAction("", "Home");

            ViewBag.StatusList = Enum.GetValues(typeof(Status)).Cast<Status>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((char)v).ToString()
            });

            int id = Convert.ToInt32(ProjectId);
            Project project = BAL.Project.GetProject(id);
            //ProjectModel project = HomeController.projects[id];
            return View(project);
        }

        public ActionResult AddProjectDetails()
        {
            int projectId = Convert.ToInt32(Request.Form["ProjectId"]);
            Project project = BAL.Project.GetProject(projectId);

            BusinessDevelopment businessDevelopment = new BusinessDevelopment(0,
                new StatusItem(0, (Status)Convert.ToChar(Request.Form["ProjectBusinessDevelopment.KnownOpportunity.Status"]), Request.Form["ProjectBusinessDevelopment.ClientContact.Comment"].ToString()),
                new StatusItem(0, (Status)Convert.ToChar(Request.Form["ProjectBusinessDevelopment.ClientContact.Status"]), Request.Form["ProjectBusinessDevelopment.ClientContact.Comment"].ToString()));

            Delivery delivery = new Delivery(0,
                //deliverables and Results 
                new StatusItem(0, (Status)Convert.ToChar(Request.Form["ProjectDelivery.DeliverablesAndResults.Status"]), Request.Form["ProjectDelivery.DeliverablesAndResults.Comment"].ToString()),
                //Schedule
                new StatusItem(0, (Status)Convert.ToChar(Request.Form["ProjectDelivery.Schedule.Status"]), Request.Form["ProjectDelivery.Schedule.Comment"].ToString()),
                //Capacity Resource
                new StatusItem(0, (Status)Convert.ToChar(Request.Form["ProjectDelivery.CapacityResources.Status"]), Request.Form["ProjectDelivery.CapacityResources.Comment"].ToString()),
                //Scope
                new StatusItem(0, (Status)Convert.ToChar(Request.Form["ProjectDelivery.Scope.Status"]), Request.Form["ProjectDelivery.Scope.Comment"].ToString()),
                //Client Satisfaction
                new StatusItem(0, (Status)Convert.ToChar(Request.Form["ProjectDelivery.ClientSatisfaction.Status"]), Request.Form["ProjectDelivery.ClientSatisfaction.Comment"].ToString()),
                //Issues And Risks
                new StatusItem(0, (Status)Convert.ToChar(Request.Form["ProjectDelivery.IssuesAndRisks.Status"]), Request.Form["ProjectDelivery.IssuesAndRisks.Comment"].ToString()),
                //UOTC
                new StatusItem(0, (Status)Convert.ToChar(Request.Form["ProjectDelivery.UseOfTestControl.Status"]), Request.Form["ProjectDelivery.UseOfTestControl.Comment"].ToString()),
                //Employee Satisfaction
                new StatusItem(0, (Status)Convert.ToChar(Request.Form["ProjectDelivery.EmployeeSatisfactionIssues.Status"]), Request.Form["ProjectDelivery.EmployeeSatisfactionIssues.Comment"].ToString()));

            ProjectStatus status = new ProjectStatus(0, DateTime.Now, delivery, businessDevelopment);

            project.ProjectStatusList[0] = status;

            project.ProjectStatusList[0].InsertStatus(project.ProjectID);

            return RedirectToAction("ProjectDetails", new { ProjectList = project.ProjectID });
        }

        public ActionResult ProjectDetails(String ProjectList)
        {
            if (Session["User"] == null)
                return RedirectToAction("", "Home");

            ViewBag.Message = "Project Details";
            Project viewProject;
            //ProjectModel viewProject;

            viewProject = Project.GetProject(Convert.ToInt32(ProjectList));
            ViewBag.SelectedProject = viewProject;

            return View(viewProject);
        }
        #endregion

        #region Report
        public ActionResult PortfolioReport(char serviceLine)
        {
            //Clients
            List<SelectListItem> clientList = new List<SelectListItem>();
            foreach (BAL.Client client in BAL.Client.GetAllClients())
            {
                clientList.Add(
                    new SelectListItem
                    {
                        Value = client.ClientID.ToString(),
                        Text = client.ClientName
                    }
                    );
            }
            ViewBag.ClientList = clientList;

            //Department List
            var serviceLines = Enum.GetValues(typeof(SogetiDepartments)).Cast<SogetiDepartments>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((char)v).ToString(),
            });
            ViewBag.ServiceLine = serviceLines;

            //Person List for lead, account manager, delivery manager
            List<SelectListItem> personList = new List<SelectListItem>();
            foreach (BAL.Person person in BAL.Person.GetAllPersons())
            {
                personList.Add(
                    new SelectListItem
                    {
                        Value = person.PersonID.ToString(),
                        Text = person.FullName.ToString()
                    }
                    );
            }
            ViewBag.Lead = personList;
            ViewBag.AccountManager = personList;
            ViewBag.DeliveryManager = personList;


            //commercial TC
            var commercialTC = Enum.GetValues(typeof(CommercialTerms)).Cast<CommercialTerms>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((char)v).ToString()
            });
            foreach (SelectListItem item in commercialTC)
            {
                if ((CommercialTerms)Convert.ToChar(item.Value) == CommercialTerms.BLANK)
                    item.Selected = true;
            }
            ViewBag.CommercialTC = commercialTC;



            //Review Frequency List
            var reviewFrequemcy = Enum.GetValues(typeof(Frequency)).Cast<Frequency>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((char)v).ToString()
            });
            foreach (SelectListItem item in reviewFrequemcy)
            {
                if (Convert.ToChar(item.Value) == '_')
                    item.Selected = true;
            }
            ViewBag.ReivewFrequency = reviewFrequemcy;
            return View();
        }

        public ActionResult PartialView1(int clientID, int accountManager, int deliveryManager, int lead,
    char serviceLine, char commTerms, char reviewFrequency)
        {
            ViewBag.Projects = BAL.Project.GetAllProjects(clientID, accountManager, deliveryManager, lead, serviceLine, commTerms, reviewFrequency);

            return PartialView();
        }

        [HttpPost]
        public JsonResult RefreshPortfolioReport(int clientID, int accountManager, int deliveryManager, int lead, char serviceLine, char commercialTC, char reviewFrequency)
        {
            List<Project> prjList = BAL.Project.GetAllProjects(clientID, accountManager, deliveryManager, lead, serviceLine, commercialTC, reviewFrequency);
            StringBuilder str = new StringBuilder();
            str.Append("<table class=\"roundedTable\">");
            str.Append("<thead class=\"frontTable\">");
            str.Append("<tr>");
            str.Append("<th>Client/Project</th>");
            str.Append("<th>Lead</th>");
            str.Append("<th>Commercial TC</th>");
            str.Append("<th>Review Frequency</th>");
            str.Append("<th>Deliverables & Results</th>");
            str.Append("<th>Schedule</th>");
            str.Append("<th>Capacity / Resources</th>");
            str.Append("<th>Scope</th>");
            str.Append("<th>Client Satisfaction</th>");
            str.Append("<th>Issues & Risks</th>");
            str.Append("<th>Use of TMap</th>");
            str.Append("<th>Employee Satisfaction</th>");
            str.Append("<th>Known Opportunities</th>");
            str.Append("<th>Client Contact</th>");
            str.Append("</tr>");
            str.Append("</thead>");
            str.Append("<tbody class=\"frontTblBody\">");
            foreach (Project prj in prjList)
            {
                str.Append("<tr>");
                str.Append("<td>" + prj.Name + "</td>");
                str.Append("<td>" + prj.ProjectLead.FullName + "</td>");
                str.Append("<td>" + prj.CommercialTermsAndConditions + "</td>");
                str.Append("<td>" + prj.ReviewFrequency + "</td>");
                str.Append("<td class=\"" + prj.ProjectStatusList[0].ProjectDelivery.DeliverablesAndResults.Status + "Front rotate\"></td>");
                str.Append("<td class=\"" + prj.ProjectStatusList[0].ProjectDelivery.Schedule.Status + "Front rotate\"></td>");
                str.Append("<td class=\"" + prj.ProjectStatusList[0].ProjectDelivery.CapacityResource.Status + "Front rotate\"></td>");
                str.Append("<td class=\"" + prj.ProjectStatusList[0].ProjectDelivery.Scope.Status + "Front rotate\"></td>");
                str.Append("<td class=\"" + prj.ProjectStatusList[0].ProjectDelivery.ClientSatisfaction.Status + "Front rotate\"></td>");
                str.Append("<td class=\"" + prj.ProjectStatusList[0].ProjectDelivery.IssuesAndRisks.Status + "Front rotate\"></td>");
                str.Append("<td class=\"" + prj.ProjectStatusList[0].ProjectDelivery.UseOfTestControl.Status + "Front rotate\"></td>");
                str.Append("<td class=\"" + prj.ProjectStatusList[0].ProjectDelivery.EmployeeSatisfaction.Status + "Front rotate\"></td>");
                str.Append("<td class=\"" + prj.ProjectStatusList[0].ProjectBusinessDevelopment.KnownOpportunity.Status + "Front rotate\"></td>");
                str.Append("<td class=\"" + prj.ProjectStatusList[0].ProjectBusinessDevelopment.ClientContact.Status + "Front rotate\"></td>");
                str.Append("</tr>");
            }
            str.Append("</tbody>");
            str.Append("</table>");

            return Json(new
            {
                success = true,
                htmlCode = str.ToString()
            });
        }
        #endregion

        #region Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult VerifyLoginDetails(string loginName, string password)
        {
            BAL.Login login = new Login();
            LoginVerification verified = LoginVerification.LOGIN_VERIFIED;
            BAL.User user = BAL.User.VerifyUser(loginName, password, out verified);

            if (verified == LoginVerification.LOGIN_VERIFIED)
            {
                Session["UserName"] = user.Name;
                Session["User"] = user;
            }

            return Json(new
            {
                success = true,
                loginAuthentication = verified
            });
        }

        public ActionResult LoginRedirect()
        {
            return RedirectToAction("Dashboard");
        }
        #endregion

        public ActionResult Dashboard()
        {
            if (Session["User"] == null)
                return RedirectToAction("", "Home");

            ViewBag.Projects = BAL.Project.GetAllProjects();

            ViewBag.Message = ".Net MVC 4 Prototype.";

            List<SelectListItem> projects = new List<SelectListItem>();

            ViewBag.ProjectList = projects;

            return View();
        }
        
        
    }
}
