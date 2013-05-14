using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sogeti.PAP.WebUI.Models
{
    public class PersonModel1
    {
        #region members
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #endregion

        public PersonModel1()
            : this(0, "", "")
        {
        }

        public PersonModel1(int personID, string firstName, string lastName)
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}