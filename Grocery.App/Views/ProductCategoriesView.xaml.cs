using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class ProductCategoriesView : ContentPage
{
    public ProductCategoriesView(ProductCategoriesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.LoadDataAsync(); // Laad data bij opstarten
    }
}