using LaererVikaren.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace LaererVikaren.Persistence
{
    public class LessonRepository : BaseRepo<Lesson>
    {
        public LessonRepository() : base()
        {
        }

        public override void Add(Lesson lesson)
        {
        }
    }
}
