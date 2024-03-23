﻿using eShop.ClientApp.Models.Basket;
using eShop.ClientApp.Services;
using eShop.ClientApp.Services.AppEnvironment;
using eShop.ClientApp.Services.Settings;
using eShop.ClientApp.ViewModels.Base;

namespace eShop.ClientApp.ViewModels;

public partial class BasketViewModel : ViewModelBase
{
    private readonly IAppEnvironmentService _appEnvironmentService;
    private readonly ISettingsService _settingsService;
    private readonly ObservableCollectionEx<BasketItem> _basketItems = new ();

    public int BadgeCount => _basketItems?.Sum(basketItem => basketItem.Quantity) ?? 0;

    public decimal Total => _basketItems?.Sum(basketItem => basketItem.Quantity * basketItem.UnitPrice) ?? 0m;

    public IReadOnlyList<BasketItem> BasketItems => _basketItems;

    public BasketViewModel(
        IAppEnvironmentService appEnvironmentService,
        INavigationService navigationService, ISettingsService settingsService)
        : base(navigationService)
    {
        _appEnvironmentService = appEnvironmentService;
        _settingsService = settingsService;
    }

    public override async Task InitializeAsync()
    {
        var authToken = _settingsService.AuthAccessToken;
        var userInfo = await _appEnvironmentService.IdentityService.GetUserInfoAsync(authToken);

        // Update Basket
        var basket = await _appEnvironmentService.BasketService.GetBasketAsync(userInfo.UserId, authToken);

        if ((basket?.Items?.Count ?? 0) > 0)
        {
            await _basketItems.ReloadDataAsync(
                async innerList =>
                {
                    foreach (var basketItem in basket.Items)
                    {
                        var catalogItem = await _appEnvironmentService.CatalogService.GetCatalogItemAsync(basketItem.ProductId);
                        basketItem.PictureUrl = catalogItem.PictureUri;
                        basketItem.ProductName = catalogItem.Name;
                        basketItem.UnitPrice = catalogItem.Price;
                        await AddBasketItemAsync(basketItem, innerList);
                    }
                });
        }
    }

    [RelayCommand]
    private Task AddAsync(BasketItem item)
    {
        return AddBasketItemAsync(item, _basketItems);
    }

    private async Task AddBasketItemAsync(BasketItem item, IList<BasketItem> basketItems)
    {
        basketItems.Add(item);

        var authToken = _settingsService.AuthAccessToken;
        var userInfo = await _appEnvironmentService.IdentityService.GetUserInfoAsync(authToken);
        var basket = await _appEnvironmentService.BasketService.GetBasketAsync(userInfo.UserId, authToken);
        
        if (basket != null)
        {
            basket.Items.Add(item);
            await _appEnvironmentService.BasketService.UpdateBasketAsync(basket, authToken);
        }

        ReCalculateTotal();
    }

    [RelayCommand]
    private async Task DeleteAsync(BasketItem item)
    {
        _basketItems.Remove(item);

        var authToken = _settingsService.AuthAccessToken;
        var userInfo = await _appEnvironmentService.IdentityService.GetUserInfoAsync(authToken);
        var basket = await _appEnvironmentService.BasketService.GetBasketAsync(userInfo.UserId, authToken);
        if (basket != null)
        {
            basket.Items.Remove(item);
            await _appEnvironmentService.BasketService.UpdateBasketAsync(basket, authToken);
        }

        ReCalculateTotal();
    }

    public async Task ClearBasketItems()
    {
        _basketItems.Clear();
        var authToken = _settingsService.AuthAccessToken;
        var userInfo = await _appEnvironmentService.IdentityService.GetUserInfoAsync(authToken);
        await _appEnvironmentService.BasketService.ClearBasketAsync(userInfo.UserId, authToken);

        ReCalculateTotal();
    }

    private void ReCalculateTotal()
    {
        OnPropertyChanged(nameof(BadgeCount));
        OnPropertyChanged(nameof(Total));
    }

    [RelayCommand]
    private async Task CheckoutAsync()
    {
        if (_basketItems?.Any() ?? false)
        {
            _appEnvironmentService.BasketService.LocalBasketItems = _basketItems;
            await NavigationService.NavigateToAsync("Checkout");
        }
    }
}
