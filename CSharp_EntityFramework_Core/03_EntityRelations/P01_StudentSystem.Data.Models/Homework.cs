﻿using System;
using P01_StudentSystem.Models.Enumerations;

namespace P01_StudentSystem.Models
{
    public partial class Homework
    {
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
        
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
