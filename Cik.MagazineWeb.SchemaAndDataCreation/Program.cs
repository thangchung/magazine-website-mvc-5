using System.Linq;

namespace Cik.MagazineWeb.SchemaAndDataCreation
{
    using Cik.MagazineWeb.EntityFrameworkProvider;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new MagazineWebContext();
            var result = context.Categories.ToList();
        }
    }
}
