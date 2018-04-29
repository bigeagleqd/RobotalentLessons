using System;
using System.Collections.Generic;

namespace RobotalentLessons.Models
{
    public partial class Lessons
    {
        public Lessons()
        {
            PersonInLessons = new HashSet<PersonInLessons>();
        }

        public uint Id { get; set; }
        public sbyte LessonType { get; set; }
        public string Name { get; set; }
        public int LessonNumbers { get; set; }
        public string Description { get; set; }
        public int CurrentLessonNumber { get; set; }
        public sbyte? Status { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ICollection<PersonInLessons> PersonInLessons { get; set; }
    }
}
