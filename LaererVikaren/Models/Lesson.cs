using System;
using System.Collections.Generic;
using System.Text;

namespace LaererVikaren.Models
{
    public class Lesson
    {
        public DateOnly LessonDate { get; set; }
        public int Timespan { get; set; }
        public string School { get; set; }
        public string Room { get; set; }

        public Lesson()
        {
        }
    }
}
