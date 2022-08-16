namespace MIAUI.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage()
	{
		InitializeComponent();
		BindingContext = new DetailsViewModel();
	}
}