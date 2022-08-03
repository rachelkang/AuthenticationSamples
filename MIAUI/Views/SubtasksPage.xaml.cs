using MIAUI.ViewModels;

namespace MIAUI.Views;

public partial class SubtasksPage : ContentPage
{
	public SubtasksPage(SubtasksViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}