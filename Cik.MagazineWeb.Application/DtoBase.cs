using System;

namespace Cik.MagazineWeb.Application
{
    public class DtoBase
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; } 
    }
}