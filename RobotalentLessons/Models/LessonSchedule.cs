using System;
using System.Collections.Generic;

namespace RobotalentLessons.Models
{
    public partial class LessonSchedule
    {
        public uint Id { get; set; }
        public uint LessonId { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
