using System;

namespace Fitness.BL.Model
{
    public class ExerciseList
    {
        public int Id { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public ExerciseList(Exercise exercise, Activity activity)
        {
            Exercise = exercise;
            Activity = activity;
        }
    }
}
