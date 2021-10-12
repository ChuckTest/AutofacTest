using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Helper.Validation
{
    public class ValidationHelperBase<T> where T : CustomTableBase
    {
        protected virtual void CheckExist(int customTableItemId)
        {
           //do logic check, and throw exception when check failed
        }
    }
}