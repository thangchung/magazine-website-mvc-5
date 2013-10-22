namespace Cik.MagazineWeb.DomainModel
{
    using System;

    public class Item
    {
        public int Id { get; set; }

        public int ItemContentId { get; set; }
       
        public virtual Category Category { get; set; }
        
        public virtual ItemContent ItemContent { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}