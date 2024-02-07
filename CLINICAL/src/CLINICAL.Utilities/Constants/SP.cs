﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Utilities.Constants
{
    public class SP
    {
        #region uspAnalysis
        public const string SP_GET_ANALYSIS_LIST = "dbo.SP_GET_ANALYSIS_LIST";
        public const string SP_GET_ANALYSIS_LIST_BY_ID = "dbo.SP_GET_ANALYSIS_LIST_BY_ID";
        public const string SP_ANALYSIS_EDIT = "dbo.SP_ANALYSIS_EDIT";
        public const string SP_ANALYSIS_REMOVE = "dbo.SP_ANALYSIS_REMOVE";
        public const string SP_ANALYSIS_REGISTER = "dbo.SP_ANALYSIS_REGISTER";
        public const string SP_CHANGE_ANALYSIS_STATE = "dbo.SP_CHANGE_ANALYSIS_STATE";
        #endregion

        #region Exams
        public const string GET_EXAMS_LIST = "dbo.GET_EXAMS_LIST";
        public const string SP_GET_EXAM_BY_ID = "dbo.SP_GET_EXAM_BY_ID";
        public const string SP_EXAM_REGISTER = "dbo.SP_EXAM_REGISTER";
        public const string SP_EXAM_EDIT = "dbo.SP_EXAM_EDIT";

        public const string SP_REMOVE_EXAM = "dbo.SP_REMOVE_EXAM";
        public const string SP_CHANGE_STATE_EXAM = "dbo.SP_CHANGE_STATE_EXAM";
        #endregion

    }
}