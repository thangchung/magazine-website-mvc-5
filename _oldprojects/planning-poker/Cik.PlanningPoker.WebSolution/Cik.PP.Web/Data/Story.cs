namespace Cik.PP.Web.Data
{
    using System;

    public class Story
    {
        public Guid Id { get; set; }
 
        public string Role { get; set; }

        public string Purpose { get; set; }

        public string Result { get; set; }

        public string Note { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public string CreatedBy { get; set; }

        public Guid? GameId { get; set; }

        public Game Game { get; set; }
    }
}