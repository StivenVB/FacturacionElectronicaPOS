using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEPOSController.DTO
{
    public class DTOBase
    {
        private DateTime currentDate;

        public DateTime CurrentDate
        {
            get { return currentDate; }
            set { currentDate = value; }
        }

        private int userSessionId;

        public int UserSessionId
        {
            get { return userSessionId; }
            set { userSessionId = value; }
        }
    }
}
