using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sogeti.PAP.BAL
{
    public class Person
    {
        #region members
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        #endregion

        #region Constructors
        public Person()
            : this(0, "", "")
        {
        }

        public Person(int personID, string firstName, string lastName)
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        #endregion

        #region Select Methods
        public static Person GetPerson(int personID)
        {
            Person person = null;
            using (DataSet dsPersonDetails = DAL.Person.GetPersonDetails(personID))
            {
                if ((dsPersonDetails != null) && (dsPersonDetails.Tables.Count > 0))
                {
                    person = new Person(personID,
                        dsPersonDetails.Tables[0].Rows[0]["FirstName"].ToString(),
                        dsPersonDetails.Tables[0].Rows[0]["LastName"].ToString());
                }
            }

            return person;
        }

        public static List<Person> GetAllPersons()
        {
            List<Person> personList = new List<Person>();
            Person person;
            using (DataSet dsPersonDetails = DAL.Person.GetallPersons())
            {
                if ((dsPersonDetails != null) && (dsPersonDetails.Tables.Count > 0))
                {
                    foreach (DataRow row in dsPersonDetails.Tables[0].Rows)
                    {
                        person = new Person(Convert.ToInt32(row["PersonID"]),
                            row["FirstName"].ToString(), row["LastName"].ToString());
                        personList.Add(person);
                    }
                }
            }

            return personList;
        }
        #endregion

        #region InsertMethods
        public bool InsertPerson()
        {
            if (DAL.Person.InsertPerson(this.FirstName, this.LastName) > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region Update Methods
        public bool UpdatePerson()
        {
            if (DAL.Person.UpdatePerson(this.PersonID, this.FirstName, this.LastName) > 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}
