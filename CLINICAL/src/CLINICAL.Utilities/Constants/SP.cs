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

        #region uspExams
        public const string GET_EXAMS_LIST = "dbo.GET_EXAMS_LIST";
        public const string SP_GET_EXAM_BY_ID = "dbo.SP_GET_EXAM_BY_ID";
        public const string SP_EXAM_REGISTER = "dbo.SP_EXAM_REGISTER";
        public const string SP_EXAM_EDIT = "dbo.SP_EXAM_EDIT";

        public const string SP_REMOVE_EXAM = "dbo.SP_REMOVE_EXAM";
        public const string SP_CHANGE_STATE_EXAM = "dbo.SP_CHANGE_STATE_EXAM";
        #endregion

        #region #uspPatients
        public const string SP_GET_PATIENT_LIST = "dbo.SP_GET_PATIENT_LIST";
        public const string SP_GET_PATIENT_BY_ID = "dbo.SP_GET_PATIENT_BY_ID";
        public const string SP_PATIENT_REGISTER = "dbo.SP_PATIENT_REGISTER";
        public const string SP_PATIENT_EDIT = "dbo.SP_PATIENT_EDIT";
        public const string SP_PATIENT_REMOVE = "dbo.SP_PATIENT_REMOVE";
        public const string SP_CHANGE_PATIENT_STATE = "dbo.SP_CHANGE_PATIENT_STATE";
        #endregion


        #region uspMedics
        public const string SP_GET_MEDIC_LIST = "dbo.SP_GET_MEDIC_LIST";
        public const string SP_GET_MEDIT_BY_ID = "dbo.SP_GET_MEDIT_BY_ID";
        public const string SP_MEDIC_REGISTER = "dbo.SP_MEDIC_REGISTER";
        public const string SP_MEDIC_EDIT = "dbo.SP_MEDIC_EDIT";
        public const string SP_MEDIC_REMOVE = "dbo.SP_MEDIC_REMOVE";
        public const string SP_CHANGE_STATE_MEDIC = "dbo.SP_CHANGE_STATE_MEDIC";
        #endregion
    }

    public class TB
    {
        public const string Analysis = "dbo.Analysis";
        public const string Exams = "dbo.Exams";
        public const string Medics = "dbo.Medics";
        public const string Patients = "dbo.Patients";
    }
}
