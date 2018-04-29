using System;
using System.Collections.Generic;

namespace RobotalentLessons.Models
{
    public partial class PersonInLessons
    {
        public uint PersonId { get; set; }
        public uint Lessonid { get; set; }
        public sbyte Actor { get; set; }

        public Lessons Lesson { get; set; }
        public Persons Person { get; set; }
    }
}
