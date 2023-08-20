using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSmartCard.UserManagement
{
    public class User : IListable
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string LoginId { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string ContactNumber { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string ImageUrl { get; set; }

        public Nullable<DateTime> BirthDate { get; set; }

        public Nullable<bool> IsActive { get; set; }


        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string SecurityQuestion { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string SecurityAnswer { get; set; }

        [Required]
        public virtual Role Role { get; set; }


        public bool IsInRole(int id)
        {
            return Role != null && Role.Id == id;
        }

    }
}
