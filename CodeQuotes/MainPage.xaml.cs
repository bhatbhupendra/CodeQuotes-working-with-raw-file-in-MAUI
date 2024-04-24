using System;

namespace CodeQuotes
{
	public partial class MainPage : ContentPage
	{	List<string> quotes = new List<string>();
		public MainPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await LoadMauiAsset();
		}

		async Task LoadMauiAsset()
		{
			using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
			using var reader = new StreamReader(stream);

			while(reader.Peek() != -1)
			{
				quotes.Add(reader.ReadLine());
			}
		}

		private void btnGenerateQuote_Clicked(object sender, EventArgs e)
		{
			Random random = new Random();
			int index = random.Next(quotes.Count);
			quote.Text = quotes[index];
		}
	}

}
