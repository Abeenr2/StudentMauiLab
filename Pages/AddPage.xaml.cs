using Newtonsoft.Json;
using StudentMauiLab.Model;
using System.Text;

namespace StudentMauiLab.Pages;

public partial class AddPage : ContentPage
{
	public AddPage()
	{
		InitializeComponent();
	}

	private async void btnSave_Clicked(object sender, EventArgs e)
	{
        try
        {
            ModelClasses modelClasses = new ModelClasses();
            modelClasses.Name = txtName.Text;
            modelClasses.Email = txtEmail.Text;


            //10.0.2.2 for Android, localhost for windows
            string apiURL = @"http://localhost:5263/api/Students"; // @"http://localhost:5125/api/CarBrands";
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(modelClasses), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.DisplayAlert("Saving", "Your brand was saved succesfully", "OK");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "We are sorry, the internet connection is not available", "OK");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "We are sorry, the internet connection is not available. (" +
            ex.Message + ")", "OK");
        }

    }
}