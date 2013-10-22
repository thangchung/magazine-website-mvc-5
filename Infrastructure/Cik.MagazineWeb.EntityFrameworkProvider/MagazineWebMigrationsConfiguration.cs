namespace Cik.MagazineWeb.EntityFrameworkProvider
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Cik.MagazineWeb.DomainModel;

    public class MagazineWebMigrationsConfiguration : DbMigrationsConfiguration<MagazineWebContext>
    {
        public MagazineWebMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MagazineWebContext context)
        {
            base.Seed(context);
#if DEBUG
            if (!context.Categories.Any())
            {
                var item1 = new Item
                            {
                                CreatedBy = "thangchung",
                                CreatedDate = DateTime.UtcNow,
                                ItemContent =
                                    new ItemContent
                                    {
                                        CreatedBy = "thangchung",
                                        CreatedDate = DateTime.UtcNow,
                                        BigImage = "/Upload/img/sample.png",
                                        SmallImage = "/Upload/img/sample.png",
                                        MediumImage = "/Upload/img/sample.png",
                                        NumOfView = 100,
                                        Title = "Augue rhoncus cum lectus dapibus et duis in",
                                        ShortDescription =
                                            "Porta nec lectus nascetur nisi quis, in augue dolor, elementum amet egestas pid diam magna, turpis, elementum elementum? Dictumst risus montes? Rhoncus, arcu, turpis elit parturient magnis cursus, ac scelerisque, risus ac, placerat odio nunc placerat, ultricies placerat porta rhoncus dolor rhoncus porttitor amet egestas, et porta dapibus, lacus, nunc placerat ac odio in? Dis? Elit, in. Montes quis diam, tristique integer sed, vut odio ultrices nunc adipiscing, placerat integer, aliquet aliquam, magna et et turpis tincidunt ut, eu velit. Mauris etiam mus pulvinar, proin cras, dolor auctor? A et diam sed ultricies arcu nisi. Hac, lacus, et, lacus phasellus aliquet tincidunt in vut in? Urna a parturient mid cras odio hac massa tortor enim egestas non ultrices pulvinar. Aliquet.",
                                        Content =
                                            "Porta nec lectus nascetur nisi quis, in augue dolor, elementum amet egestas pid diam magna, turpis, elementum elementum? Dictumst risus montes? Rhoncus, arcu, turpis elit parturient magnis cursus, ac scelerisque, risus ac, placerat odio nunc placerat, ultricies placerat porta rhoncus dolor rhoncus porttitor amet egestas, et porta dapibus, lacus, nunc placerat ac odio in? Dis? Elit, in. Montes quis diam, tristique integer sed, vut odio ultrices nunc adipiscing, placerat integer, aliquet aliquam, magna et et turpis tincidunt ut, eu velit. Mauris etiam mus pulvinar, proin cras, dolor auctor? A et diam sed ultricies arcu nisi. Hac, lacus, et, lacus phasellus aliquet tincidunt in vut in? Urna a parturient mid cras odio hac massa tortor enim egestas non ultrices pulvinar. Aliquet. Et integer? Ridiculus, sed phasellus amet dignissim porttitor proin, egestas porttitor, velit augue platea? Porttitor pid a pellentesque magnis, nascetur. Scelerisque duis mid! Sit? Ultricies ultricies ut porta scelerisque. Porta integer! Nisi dolor. Nec integer, nunc, urna turpis! Hac adipiscing proin mid duis phasellus dapibus tincidunt sed, elementum urna amet, dolor dignissim odio cursus risus. Hac nunc in eu, nec a in pulvinar integer sit est aenean lorem dis ut lacus, in et risus pid, ac placerat dis urna nec. Porttitor, urna eros enim urna enim! Sed, enim purus? Porttitor penatibus penatibus est habitasse aenean, et elit enim cras platea? Ut! Egestas elit, cum ac non cras amet adipiscing. Placerat lorem auctor et a placerat ultricies, in dictumst nunc."
                                    }
                            };

                var item2 = new Item
                            {
                                CreatedBy = "thangchung",
                                CreatedDate = DateTime.UtcNow,
                                ItemContent =
                                    new ItemContent
                                    {
                                        CreatedBy = "thangchung",
                                        CreatedDate = DateTime.UtcNow,
                                        BigImage = "/Upload/img/sample.png",
                                        SmallImage = "/Upload/img/sample.png",
                                        MediumImage = "/Upload/img/sample.png",
                                        NumOfView = 200,
                                        Title = "Augue rhoncus cum lectus dapibus et duis in",
                                        ShortDescription =
                                            "Porta nec lectus nascetur nisi quis, in augue dolor, elementum amet egestas pid diam magna, turpis, elementum elementum? Dictumst risus montes? Rhoncus, arcu, turpis elit parturient magnis cursus, ac scelerisque, risus ac, placerat odio nunc placerat, ultricies placerat porta rhoncus dolor rhoncus porttitor amet egestas, et porta dapibus, lacus, nunc placerat ac odio in? Dis? Elit, in. Montes quis diam, tristique integer sed, vut odio ultrices nunc adipiscing, placerat integer, aliquet aliquam, magna et et turpis tincidunt ut, eu velit. Mauris etiam mus pulvinar, proin cras, dolor auctor? A et diam sed ultricies arcu nisi. Hac, lacus, et, lacus phasellus aliquet tincidunt in vut in? Urna a parturient mid cras odio hac massa tortor enim egestas non ultrices pulvinar. Aliquet.",
                                        Content =
                                            "Porta nec lectus nascetur nisi quis, in augue dolor, elementum amet egestas pid diam magna, turpis, elementum elementum? Dictumst risus montes? Rhoncus, arcu, turpis elit parturient magnis cursus, ac scelerisque, risus ac, placerat odio nunc placerat, ultricies placerat porta rhoncus dolor rhoncus porttitor amet egestas, et porta dapibus, lacus, nunc placerat ac odio in? Dis? Elit, in. Montes quis diam, tristique integer sed, vut odio ultrices nunc adipiscing, placerat integer, aliquet aliquam, magna et et turpis tincidunt ut, eu velit. Mauris etiam mus pulvinar, proin cras, dolor auctor? A et diam sed ultricies arcu nisi. Hac, lacus, et, lacus phasellus aliquet tincidunt in vut in? Urna a parturient mid cras odio hac massa tortor enim egestas non ultrices pulvinar. Aliquet. Et integer? Ridiculus, sed phasellus amet dignissim porttitor proin, egestas porttitor, velit augue platea? Porttitor pid a pellentesque magnis, nascetur. Scelerisque duis mid! Sit? Ultricies ultricies ut porta scelerisque. Porta integer! Nisi dolor. Nec integer, nunc, urna turpis! Hac adipiscing proin mid duis phasellus dapibus tincidunt sed, elementum urna amet, dolor dignissim odio cursus risus. Hac nunc in eu, nec a in pulvinar integer sit est aenean lorem dis ut lacus, in et risus pid, ac placerat dis urna nec. Porttitor, urna eros enim urna enim! Sed, enim purus? Porttitor penatibus penatibus est habitasse aenean, et elit enim cras platea? Ut! Egestas elit, cum ac non cras amet adipiscing. Placerat lorem auctor et a placerat ultricies, in dictumst nunc."
                                    }
                            };

                var cat1 = new Category { Name = "Sport", CreatedDate = DateTime.UtcNow, CreatedBy = "thangchung", Items = new Collection<Item> { item1 } };
                var cat2 = new Category { Name = "Fashion", CreatedDate = DateTime.UtcNow, CreatedBy = "thangchung", Items = new Collection<Item> { item2 } };

                context.Categories.Add(cat1);
                context.Categories.Add(cat2);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // TODO: write log here
                    var message = ex.Message;
                }
            }
#endif
        }
    }
}
