namespace Cik.PP.Web.Data
{
    using System;
    using System.Collections.Generic;

    public class StoryRuntime
    {
        public Guid Id { get; set; }

        public bool IsCurrent { get; set; }

        public bool IsDone { get; set; }

        public Guid? PointId { get; set; }

        public Guid? GameRuntimeId { get; set; }

        public GameRuntime GameRuntime { get; set; }

        public Guid? StoryId { get; set; }

        public Story Story { get; set; }

        public DateTime Created { get; set; }

        public List<Point> VotedPoints { get; set; } // runtime users voted

        public Point FinalPoint { get; set; }
    }
}