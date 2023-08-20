using StudentSmartCard.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP.SSCard.WEB.UI.Models.Documents
{
    public class DocumentsModel
    {
        public DocumentsModel()
        {

        }
        public int Id { get; set; }
        public string StudentRollno { get; set; }
        public string Imageupload { get; set; }
        public string Board { get; set; }
        public int PassingYear { get; set; }
        public string Subject { get; set; }
        public int TotalMarks { get; set; }
        public int ObtainMarks { get; set; }
        public IEnumerable<QualCategory> QualificationCategories { get; set; }
    }
}