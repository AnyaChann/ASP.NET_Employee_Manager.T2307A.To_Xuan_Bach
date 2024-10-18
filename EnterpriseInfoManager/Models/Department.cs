using System.ComponentModel.DataAnnotations;

namespace EnterpriseInfoManager.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 3)]
        public required string Name { get; set; }
    }
}