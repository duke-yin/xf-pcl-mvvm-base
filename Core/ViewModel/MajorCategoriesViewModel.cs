using System.Collections.ObjectModel;
using System.Windows.Input;
using BaseSolution.Core.Enums;
using BaseSolution.Core.Infrastructure.Services;
using BaseSolution.Core.Model;
using Xamarin.Forms;

namespace BaseSolution.Core.ViewModel
{
    public class MajorCategoriesViewModel: BaseViewModel
    {
        public ObservableCollection<EquipmentMajorCategory> MajorCategories { get; set; } = new ObservableCollection<EquipmentMajorCategory>(){
            new EquipmentMajorCategory(){ Name = "Aeiral Work Platforms"},
            new EquipmentMajorCategory(){ Name = "Air Compressors & Air Tools"},
            new EquipmentMajorCategory(){ Name = "All Other Equipment"},
            new EquipmentMajorCategory(){ Name = "Compaction"},
            new EquipmentMajorCategory(){ Name = "Concrete & Masonry"},
            new EquipmentMajorCategory(){ Name = "Cranes"},
            new EquipmentMajorCategory(){ Name = "Earthmoving Equipment"},
            new EquipmentMajorCategory(){ Name = "Forklifts & Material Handling"},
            new EquipmentMajorCategory(){ Name = "Industrial Tools & Accessories"},
            new EquipmentMajorCategory(){ Name = "Lawn & Landscape"},
            new EquipmentMajorCategory(){ Name = "Light Towers & Generators"},
            new EquipmentMajorCategory(){ Name = "Plumbing & Pipes"}
        };

        private readonly INavigationService _navigationService;

        public ICommand NavigateCommand { get; private set; }


        public MajorCategoriesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new Command(() => Navigate());
        }

        private void Navigate()
        {
            _navigationService.NavigateTo(AppPages.DetailsPage);
        }
    }
}
