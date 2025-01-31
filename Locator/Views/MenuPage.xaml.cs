using Locator.VMs;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Locator.Views;

public partial class MenuPage : ContentPage
{
    ObservableCollection<FlyoutPageItem> flyoutPageItems = new ObservableCollection<FlyoutPageItem>();
    public ObservableCollection<FlyoutPageItem> FlyoutPageItems { get { return flyoutPageItems; } }
    public MenuPage()
	{
		InitializeComponent();
        flyoutPageItems.Add(new FlyoutPageItem ("Receive"));
        flyoutPageItems.Add(new FlyoutPageItem ("Send"));
        flyoutPageItems.Add(new FlyoutPageItem ("Settings"));

        collectionViewFlyout.ItemsSource = flyoutPageItems;
    }
}