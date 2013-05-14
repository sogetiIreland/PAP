using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sogeti.PAP.BAL
{
    public class Project
    {
        #region Members
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Client Client { get; set; }
        public Person SogetiPractitioner { get; set; }
        public Person AccountManager { get; set; }
        public Person DeliveryManager { get; set; }
        public Person Administrator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RevisedDate { get; set; }
        public List<ProjectStatus> ProjectStatusList { get; set; }
        public Person ProjectLead { get; set; }
        public Frequency ReviewFrequency { get; set; }
        public CommercialTerms CommercialTermsAndConditions { get; set; }
        public SogetiDepartments SogetiDepartment { get; set; }
        #endregion

        #region Constructor
        public Project()
            : this(0, "", "", new Person(), new Person(), new Person(), new Person(), new Client(), DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue, new Person(), CommercialTerms.Fixed_Price, Frequency.Monthly, SogetiDepartments.ADNT)
        {
        }

        public Project(int projectID, string name, string description)
            : this(projectID, name, description,
                new Person(), new Person(), new Person(), new Person(), new Client(), DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, new Person(), CommercialTerms.Fixed_Price, Frequency.Monthly, SogetiDepartments.ADNT)
        {
        }

        public Project(int projectID, string name, string description, Person sogetiPractitioner, Person accountManager,
            Person deliveryManager, Person administrator, Client client, DateTime startDate, DateTime endDate, DateTime revisedDate, Person projectLead, CommercialTerms commercialTerms, Frequency reviewFrequency, SogetiDepartments sogetiDept)
        {
            this.ProjectID = projectID;
            this.Name = name;
            this.Description = description;
            this.SogetiPractitioner = sogetiPractitioner;
            this.AccountManager = accountManager;
            this.DeliveryManager = deliveryManager;
            this.Administrator = administrator;
            this.ProjectLead = projectLead;
            this.ReviewFrequency = reviewFrequency;
            this.CommercialTermsAndConditions = commercialTerms;
            this.Client = client;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.RevisedDate = revisedDate;
            this.SogetiDepartment = sogetiDept;
            this.ProjectStatusList = new List<ProjectStatus>();
        }
        #endregion

        #region Select Methods
        public static Project GetProject(int projectID)
        {
            Project prj = null;
            using (DataSet prjDetails = DAL.Project.GetProjectDetails(projectID))
            {
                if ((prjDetails != null) && (prjDetails.Tables.Count > 0))
                {
                    prj = new Project(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["ProjectID"]),
                        prjDetails.Tables[0].Rows[0]["Name"].ToString(), prjDetails.Tables[0].Rows[0]["Description"].ToString(),
                        Person.GetPerson(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["SogetiPractitioner_PersonID"])),
                        Person.GetPerson(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["AccountManager_PersonID"])),
                        Person.GetPerson(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["DeliveryManager_PersonID"])),
                        Person.GetPerson(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["Administrator_PersonID"])),
                        Client.GetClient(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["Client_ClientID"])),
                        Convert.ToDateTime(prjDetails.Tables[0].Rows[0]["StartDate"].ToString()),
                        Convert.ToDateTime(prjDetails.Tables[0].Rows[0]["EndDate"].ToString()),
                        Convert.ToDateTime(prjDetails.Tables[0].Rows[0]["RevisedDate"].ToString()),
                        Person.GetPerson(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["Lead_PersonID"])),
                        (CommercialTerms)Convert.ToChar(prjDetails.Tables[0].Rows[0]["CommercialTerms"]),
                        (Frequency)Convert.ToChar(prjDetails.Tables[0].Rows[0]["ReviewFrequency"]),
                        (SogetiDepartments)Convert.ToChar(prjDetails.Tables[0].Rows[0]["SogetiServiceLine"]));

                    prj.ProjectStatusList = new List<ProjectStatus>();
                    prj.ProjectStatusList.Add(ProjectStatus.GetRecentProjectStatus(prj.ProjectID));
                }
            }

            return prj;
        }

        public static List<Project> GetAllProjects()
        {
            return GetAllProjects(0, 0, 0, 0, '_', '_', '_');
        }

        public static Project GetProjectWithStatusHistory(int projectID)
        {
            Project prj = null;
            using (DataSet prjDetails = DAL.Project.GetProjectDetails(projectID))
            {
                if ((prjDetails != null) && (prjDetails.Tables.Count > 0))
                {
                    prj = new Project(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["ProjectID"]),
                        prjDetails.Tables[0].Rows[0]["Name"].ToString(), prjDetails.Tables[0].Rows[0]["Description"].ToString(),
                        Person.GetPerson(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["SogetiPractitioner_PersonID"])),
                        Person.GetPerson(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["AccountManager_PersonID"])),
                        Person.GetPerson(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["DeliveryManager_PersonID"])),
                        Person.GetPerson(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["Administrator_PersonID"])),
                        Client.GetClient(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["Client_ClientID"])),
                        Convert.ToDateTime(prjDetails.Tables[0].Rows[0]["StartDate"].ToString()),
                        Convert.ToDateTime(prjDetails.Tables[0].Rows[0]["EndDate"].ToString()),
                        Convert.ToDateTime(prjDetails.Tables[0].Rows[0]["RevisedDate"].ToString()),
                        Person.GetPerson(Convert.ToInt32(prjDetails.Tables[0].Rows[0]["Lead_PersonID"])),
                        (CommercialTerms)Convert.ToChar(prjDetails.Tables[0].Rows[0]["CommercialTerms"]),
                        (Frequency)Convert.ToChar(prjDetails.Tables[0].Rows[0]["ReviewFrequency"]),
                        (SogetiDepartments)Convert.ToChar(prjDetails.Tables[0].Rows[0]["SogetiServiceLine"]));

                    prj.ProjectStatusList = ProjectStatus.GetAllStatus(prj.ProjectID);
                }
            }

            return prj;
        }

        public static List<Project> GetAllProjects(int clientID, int accountManager, int deliveryManager, int lead,
            char serviceLine, char commTerms, char reviewFrequency)
        {
            List<Project> prjList = new List<Project>();
            Project prj;

            using (DataSet dsProjects = DAL.Project.GetAllProjects(clientID, accountManager, deliveryManager, lead, serviceLine, commTerms, reviewFrequency))
            {
                if ((dsProjects != null) && (dsProjects.Tables.Count > 0))
                {
                    foreach (DataRow row in dsProjects.Tables[0].Rows)
                    {
                        prj = new Project();
                        prj = new Project(Convert.ToInt32(row["ProjectID"]),
                        row["Name"].ToString(), row["Description"].ToString(),
                        Person.GetPerson(Convert.ToInt32(row["SogetiPractitioner_PersonID"])),
                        Person.GetPerson(Convert.ToInt32(row["AccountManager_PersonID"])),
                        Person.GetPerson(Convert.ToInt32(row["DeliveryManager_PersonID"])),
                        Person.GetPerson(Convert.ToInt32(row["Administrator_PersonID"])),
                        Client.GetClient(Convert.ToInt32(row["Client_ClientID"])),
                        Convert.ToDateTime(row["StartDate"].ToString()),
                        Convert.ToDateTime(row["EndDate"].ToString()),
                        Convert.ToDateTime(row["RevisedDate"].ToString()),
                        Person.GetPerson(Convert.ToInt32(row["Lead_PersonID"])),
                        (CommercialTerms)Convert.ToChar(row["CommercialTerms"]),
                        (Frequency)Convert.ToChar(row["ReviewFrequency"]),
                        (SogetiDepartments)Convert.ToChar(row["SogetiServiceLine"]));
                        prj.ProjectStatusList = new List<ProjectStatus>();
                        prj.ProjectStatusList.Add(BAL.ProjectStatus.GetRecentProjectStatus(prj.ProjectID));

                        prjList.Add(prj);
                    }
                }
            }

            return prjList;

        }
        #endregion

        #region InsertMethod
        public bool InsertProject()
        {
            if (DAL.Project.InsertProject(this.Name, this.Description, this.StartDate, this.EndDate, this.RevisedDate,
                this.SogetiPractitioner.PersonID, this.AccountManager.PersonID, this.DeliveryManager.PersonID, this.Administrator.PersonID,
                this.Client.ClientID, this.ProjectLead.PersonID, (char)this.CommercialTermsAndConditions, (char)this.ReviewFrequency, (char)this.SogetiDepartment) > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region Update methods
        public bool UpdateProject(string updatingUser)
        {
            int result = DAL.Project.UpdateProject(this.ProjectID, this.Name, this.Description, this.StartDate, this.EndDate,
                this.RevisedDate, this.SogetiPractitioner.PersonID, this.AccountManager.PersonID, this.DeliveryManager.PersonID, this.Administrator.PersonID,
                this.Client.ClientID, this.ProjectLead.PersonID, (char)this.CommercialTermsAndConditions, (char)this.ReviewFrequency, (char)this.SogetiDepartment, updatingUser);

            if (result > 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}
