using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sogeti.PAP.WebUI.Models
{
    public class StatusItemModel1
    {
        public int Id { get; set; }
        public StatusEnum1 State { get; set; }
        public string Comment { get; set; }

        public StatusItemModel1()
        {
        }

        public StatusItemModel1(int Id, StatusEnum1 State, string Comment)
        {
            this.Id = Id;
            this.State = State;
            this.Comment = Comment;
        }
    }
}