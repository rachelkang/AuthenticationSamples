namespace MIAUI.Views;

public partial class MainLoginPage : ContentPage
{
	public MainLoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}