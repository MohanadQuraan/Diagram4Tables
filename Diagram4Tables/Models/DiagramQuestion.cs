﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diagram4Tables.Models
{
    public class SETUP_MTS_QUESTION
    {
        public string ID { get; set; }
        public string QuestionText { get; set; }
        public string LOVType { get; set; }
        public Nullable<long> AnswerObject { get; set; }
        public Nullable<long> AnswerAttribute { get; set; }
        public Nullable<bool> IsFreeText { get; set; }
        public string AnswerYesValueCriteria { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATION_DATETIME { get; set; }
        public string DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETE_DATETIME { get; set; }
        public string UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATETIME { get; set; }


    }

}