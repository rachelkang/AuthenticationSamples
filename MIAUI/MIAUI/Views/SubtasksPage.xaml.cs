namespace MIAUI.Views;

public partial class SubtasksPage : ContentPage
{
	public SubtasksPage()
	{
		InitializeComponent();
		BindingContext = new SubtasksViewModel();
	}
}