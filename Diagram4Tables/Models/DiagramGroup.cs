using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagram4Tables.Models
{
    public class SETUP_MTS_GROUP
    {

        public string ID { get; set; }
        public string ProblemID { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public Nullable<int> GroupOrder { get; set; }
        public long? GroupYesResult { get; set; }
        public long? GroupNoResult { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATION_DATETIME { get; set; }
        public string DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETE_DATETIME { get; set; }
        public string UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATETIME { get; set; }



    }

}