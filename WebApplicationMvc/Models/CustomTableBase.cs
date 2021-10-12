using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationMvc.Models
{
    public class CustomTableBase
    {
        public int CustomTableItemId { get; set; }
    }

    public class Student : CustomTableBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}