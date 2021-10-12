﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationMvc.Models;

namespace WebApplicationMvc.Helper.Validation
{
    public interface ICustomValidation<T> where T : CustomTableBase
    {
        void CheckExist(int id);
    }

    public class ValidationHelperBase<T> where T : CustomTableBase
    {
        public virtual void CheckExist(int customTableItemId)
        {
            //do logic check, and throw exception when check failed
        }
    }
}