namespace Cik.PP.Web.Data
{
    using System;
    using System.Collections.Generic;

    public class GameRuntime
    {
        public Guid Id { get; set; }
 
        public Guid?  ParticipantId { get; set; }

        public Participant Participant { get; set; }

        public Guid? GameId { get; set; }

        public Game Game { get; set; }

        public DateTime Created { get; set; }

        public ICollection<StoryRuntime> StoryRuntimes { get; set; }
    }
}