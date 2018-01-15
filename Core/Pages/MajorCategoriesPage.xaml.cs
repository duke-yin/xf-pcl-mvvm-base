using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BaseSolution.Core.Pages
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
