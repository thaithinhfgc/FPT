using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.UserModule
{
    public enum UserRole
    {
        STUDENT = 1,
        LECTURER = 2,
        ADMIN = 3,
        BUSINESS = 4,
    }

    public enum UserStatus
    {
        ACTIVE = 1,
        INACTIVE = 2
    }
    public class User
    {
        [Key]
        [Required]
        [StringLength(40)]
        public string Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        [StringLength(30)]
        public string UserCode { get; set; }
        [Required]
        public UserStatus Status { get; set; }
        [Required]
        public UserRole Role { get; set; }
        [StringLength(30)]
        public string GoogleId { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public string CV { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
    }
}
