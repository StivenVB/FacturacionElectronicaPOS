using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEPOS.Controllers
{
    public class BaseController : Controller
    {
        public bool VerifySession()
        {
            return Session.Count > 0;
        }
    }
}