namespace Locator;

public partial class AppFlyoutPage : FlyoutPage
{
	public AppFlyoutPage()
	{
		InitializeComponent();
		flyoutPage.btn.Clicked += OpenSecondPageClicked;
	}

    private void OpenSecondPageClicked(object sender, EventArgs e)
    {
        if (!((IFlyoutPageController)this).ShouldShowSplitMode)
            IsPresented = false;
        Detail = new NavigationPage(new SecondPage());
    }
}