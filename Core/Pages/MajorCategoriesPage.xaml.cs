using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SunstateEquip.RentalQuotes.Core.Pages
{
    public partial class MajorCategoriesPage : BasePage
    {
        public MajorCategoriesPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.MajorCategoriesViewModel;
        }
    }
}
