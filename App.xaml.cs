using System.Windows.Markup;

namespace m0.maui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}
}
