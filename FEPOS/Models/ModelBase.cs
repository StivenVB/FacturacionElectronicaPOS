using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FEPOS.Models
{
    public class ModelBase
    {
        private DateTime currentDate;

        public DateTime CurrentDate
        {
            get { return DateTime.Now; }
        }

        private int userSessionId;

        public int UserSessionId
        {
            get { return userSessionId; }
            set { userSessionId = value; }
        }
    }
}