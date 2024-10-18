using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace EnterpriseInfoManager.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [StringLength(33, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(0, 9999)]
        public int Salary { get; set; }

        public bool Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}