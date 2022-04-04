using System.ComponentModel.DataAnnotations;

namespace ControlAPI.Models
{
    public class TeacherSubject : BaseModel
    {
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
    }
}
