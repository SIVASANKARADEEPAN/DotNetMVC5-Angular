using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class TodoLIst
    {
        public int Id { get; set; }
 
        public string Content { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }
        public int Progress { get; set; }
    }
}