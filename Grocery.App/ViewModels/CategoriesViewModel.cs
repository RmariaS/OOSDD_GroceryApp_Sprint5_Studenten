using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels;

public partial class CategoriesViewModel : ObservableObject
{
    private readonly ICategoryService _categoryService;
    private readonly IProductCategoryService _productCategoryService;

    [ObservableProperty]
    private ObservableCollection<Category> categories = new();

    public CategoriesViewModel(
        ICategoryService categoryService,
        IProductCategoryService productCategoryService)
    {
        _categoryService = categoryService;
        _productCategoryService = productCategoryService;
        LoadCategories();
    }

    private async void LoadCategories()
    {
        var cats = await _categoryService.GetAllCategoriesAsync();
        Categories.Clear();
        foreach (var cat in cats)
            Categories.Add(cat);
    }

    [RelayCommand]
    private async Task AddCategoryAsync()
    {
        string name = await Application.Current.MainPage.DisplayPromptAsync(
            title: "Nieuwe categorie",
            message: "Voer de naam van de categorie in:",
            placeholder: "Bijv. Fruit");

        if (!string.IsNullOrWhiteSpace(name))
        {
            await _categoryService.CreateCategoryAsync(name);
            LoadCategories(); // Vernieuw lijst
        }
    }

    [RelayCommand]
    private async Task DeleteCategoryAsync(Category category)
    {
        bool confirm = await Application.Current.MainPage.DisplayAlert(
            "Verwijderen",
            $"Weet je zeker dat je '{category.Name}' wilt verwijderen?",
            "Ja", "Nee");

        if (confirm)
        {
            await _categoryService.DeleteCategoryAsync(category.Id);
            Categories.Remove(category);
        }
    }

    [RelayCommand]
    private async Task NavigateToProductCategoriesAsync(Category category)
    {
        await Shell.Current.GoToAsync($"//productcategories?categoryId={category.Id}");
    }
}