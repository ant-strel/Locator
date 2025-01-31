using CommunicationLib.Services;
using Locator.VMs;
using Microsoft.Maui.Controls;
using System.Linq;

namespace Locator.Views;

public partial class FlyoutSamplePage : FlyoutPage
{
    private SettingsPage _settingsPage;
    private ReceivePage _receivePage;
    private SendPage _sendPage;
    private SendViewModel _sendViewModel;
   // private TrackerService _trackerService;
	public FlyoutSamplePage()
	{
        //_trackerService = new TrackerService("http://192.168.0.17",50051);
        _sendViewModel = new SendViewModel();
        //_sendViewModel.AddTrackerSevice(_trackerService);
        InitializeComponent();
        _settingsPage = new SettingsPage();
        _receivePage = new ReceivePage();
        _sendPage = new SendPage(_sendViewModel);

        flyoutPage.collectionViewFlyout.SelectionChanged += OnSelectionChanged;
	}
    void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
        if (item != null)
        {

            if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                IsPresented = false;

            switch (item.Title)
            {
                case "Settings":
                    Detail = new NavigationPage(_settingsPage);
                    break;

                case "Receive":
                    
                    Detail = new NavigationPage(_receivePage);

                    break;

                case "Send":
                    Detail = new NavigationPage(_sendPage);

                    break;
            }
        }
    }

}