using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sogeti.PAP.WebUI.Models
{
    public class ProjectIDModel
    {
        public long ProjectID { get; set; }
        public string Name { get; set; }

        public ProjectIDModel()
        {
        }

        public ProjectIDModel(long ID, string Name)
        {
            this.ProjectID = ID;
            this.Name = Name;
        }
    }
}