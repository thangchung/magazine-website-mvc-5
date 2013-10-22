namespace Cik.MagazineWeb.Application.ViewModels
{
    public abstract class FrontPageViewModelBase
    {
        protected FrontPageViewModelBase()
        {
            this.TopMenu = new CategoryMenuViewModel();
        }

        public CategoryMenuViewModel TopMenu { get; set; }  
    }
}