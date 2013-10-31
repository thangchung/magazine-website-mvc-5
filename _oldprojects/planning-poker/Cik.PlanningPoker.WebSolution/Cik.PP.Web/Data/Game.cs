namespace Cik.PP.Web.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Game
    {
        public Guid Id { get; set; }
 
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public string CreatedBy { get; set; }

        public ICollection<Story> Stories { get; set; } 

        public ICollection<GameRuntime> GameRuntimes { get; set; }
    }
}