using Locator.VMs;
using Microsoft.Maui.Controls;
using System;

namespace Locator.Views;

public partial class SendPage : ContentPage
{
	public SendPage(SendViewModel sendViewModel)
	{
		InitializeComponent();
		BindingContext = sendViewModel;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		//Todo set timer
    }
}