using System;
using System.Collections.Generic;

namespace RobotalentLessons.Models
{
    public partial class Persons
    {
        public Persons()
        {
            PersonInLessons = new HashSet<PersonInLessons>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Mobile { get; set; }
        public string Wechat { get; set; }
        public sbyte PersonType { get; set; }

        public ICollection<PersonInLessons> PersonInLessons { get; set; }
    }
}
