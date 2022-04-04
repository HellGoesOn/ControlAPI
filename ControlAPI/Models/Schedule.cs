using System.ComponentModel.DataAnnotations;

namespace ControlAPI.Models
{
    public class Schedule : BaseModel
    {
        public int IDTeacherSubject { get; set; }
        public DateTime Day { get; set; }
    }
}
