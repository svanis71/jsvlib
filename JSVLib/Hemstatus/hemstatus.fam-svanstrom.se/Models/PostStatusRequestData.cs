using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hemstatus.fam_svanstrom.se.Models
{
    public class PostStatusRequestData
    {
        private string _oldStatus;
        private string _newStatus;
        public string Id { get; set; }
        public string OldStatus
        {
            get { return _oldStatus; }
            set 
            {
                if (value == "1" || value == "0")
                    _oldStatus = value;
                else
                    throw new ArgumentException("Bad status");
            }
        }

        // Must be 0 or 1
        public string NewStatus
        {
            get { return _newStatus; }
            set
            {
                if (value == "1" || value == "0")
                    _newStatus = value;
                else
                    throw new ArgumentException("Bad status");
            }
        }

        // Must be 0 or 1
        public override string ToString()
        {
            return string.Format("{0}: [Id = {1}; OldStatus = {2}; NewStatus = {3}]",
                                 this.GetType().Name, Id, OldStatus, NewStatus);
        }
    }
}