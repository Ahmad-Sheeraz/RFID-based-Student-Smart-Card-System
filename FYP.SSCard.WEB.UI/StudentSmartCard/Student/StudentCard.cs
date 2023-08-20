using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSmartCard.Student
{
    public class StudentCard
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string CardId { get; set; }
        [Required]
        public int ProcessedBy { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}
