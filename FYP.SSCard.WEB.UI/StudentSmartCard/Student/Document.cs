using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSmartCard.Student
{
    public class Document
    { 
      
        public int Id { get; set; }
        public string StuRollNo { get; set; }
        public string Imageupload { get; set; }
        public string Board { get; set; }
        public int PassingYear { get; set; }
        public string Subjects { get; set; }
        public int TotalMarks { get; set; }
        public int ObtainMarks { get; set; }
        public virtual QualCategory QualCategory { get; set; }
    }
}
