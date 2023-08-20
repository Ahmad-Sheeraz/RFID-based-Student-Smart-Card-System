using FYP.SSCard.WEB.UI.Models.Documents;
using StudentSmartCard.Location;
using StudentSmartCard.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP.SSCard.WEB.UI.Models.Students
{
    public class DetailsModel
    {
        public StudentsModel students { get; set; }
        public List<DocumentsModel> documents { get; set; }
    }
}