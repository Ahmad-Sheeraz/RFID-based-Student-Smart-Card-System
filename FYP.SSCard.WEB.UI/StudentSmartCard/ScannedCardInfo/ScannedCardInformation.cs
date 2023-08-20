using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSmartCard.ScannedCardInfo
{
    public class ScannedCardInformation 
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        public string CardId { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool IsProcessed { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int ProcessedBy { get; set; }
    }
    
}
