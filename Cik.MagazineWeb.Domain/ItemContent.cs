namespace Cik.MagazineWeb.DomainModel
{
    using System;
    using System.Collections.Generic;

    public sealed class ItemContent
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string ShortDescription { get; set; }
      
        public string Content { get; set; }
        
        public string SmallImage { get; set; }
        
        public string MediumImage { get; set; }
        
        public string BigImage { get; set; }

        public long NumOfView { get; set; }

        public ICollection<Item> Items { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}