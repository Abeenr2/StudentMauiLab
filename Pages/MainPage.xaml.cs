using Newtonsoft.Json;
using StudentMauiLab.Model;
using StudentMauiLab.Pages;


namespace StudentMauiLab;

public partial class MainPage : ContentPage
{
	
    public MainPage()
    {
        InitializeComponent();
        InitData();

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        InitData();
    }
    public async Task InitData()
    {
        try
        {
            //10.0.2.2 for Android, localhost for windows
            string apiURL = @"http://localhost:5263/api/Students"; // @"http://localhost:5125/api/CarBrands";
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                content = content.Replace("<P>", "");

                //List<Datum> serviceResponse = JsonConvert.DeserializeObject<List<Datum>>(content);
                List<ModelClasses> serviceResponse = JsonConvert.DeserializeObject<List<ModelClasses>>(content);
                lstStudent.ItemsSource = serviceResponse;
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "We are sorry, the internet connection is not available", "OK");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "We are sorry, the internet connection is not available.(" + ex.Message + ")", "OK");
        }
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        AddPage addpage = new AddPage();
        Navigation.PushAsync(addpage);
    }
}

