namespace Cik.PP.Web.Data
{
    using System;
    using System.Collections.Generic;

    public class Participant
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsCreatedGame { get; set; }

        public DateTime Created { get; set; }
    }
}