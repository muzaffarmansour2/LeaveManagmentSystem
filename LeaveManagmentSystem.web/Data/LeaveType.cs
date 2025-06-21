using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagmentSystem.web.Data
{
    public class LeaveType
    {
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(150)")] /// or use [MaxLength(150)]
        public string Name { get; set; }
        public int NumberOfDays { get; set; }
    }
}
