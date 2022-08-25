using ButtonControlWithProgressbar.ViewModel;

namespace ButtonControlWithProgressbar;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		this.BindingContext = new MainPageViewModel();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		//count++;

		//if (count == 1)
		//	CounterBtn.Text = $"Clicked {count} time";
		//else
		//	CounterBtn.Text = $"Clicked {count} times";

		//SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private async void btn1_Tapped(object sender, EventArgs e)
	{
		btn1.IsInProgress = true;
		await Task.Delay(1000);
		btn1.IsInProgress = false;
	}
}

