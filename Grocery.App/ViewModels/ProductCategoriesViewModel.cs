using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels;  // ← let op: punt niet underscore

[QueryProperty(nameof(CategoryId), "categoryId")]  // ← verplaats naar class level
public partial class ProductCategoriesViewModel : ObservableObject
{
    private readonly IProductCategoryService _productCategoryService;
    private readonly ICategoryService _categoryService;

    [ObservableProperty]
    private Category? selectedCategory;

    [ObservableProperty]
    private ObservableCollection<ProductCategory> productCategories = new();

    public int CategoryId { get; set; }  // ← verwijder QueryProperty hier

    public ProductCategoriesViewModel(
        IProductCategoryService productCategoryService,
        ICategoryService categoryService)
    {
        _productCategoryService = productCategoryService;
        _categoryService = categoryService;
    }

    public async Task LoadDataAsync()
    {
        // Haal categorienaam op
        SelectedCategory = await _categoryService.GetCategoryByIdAsync(CategoryId);

        // Haal gekoppelde producten op
        var pcs = await _productCategoryService.GetProductsInCategoryAsync(CategoryId);
        ProductCategories.Clear();
        foreach (var pc in pcs)
            ProductCategories.Add(pc);
    }
}