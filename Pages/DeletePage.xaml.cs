using Newtonsoft.Json;
using StudentMauiLab.Model;
using System.Text;
using System.Xml.Linq;

namespace StudentMauiLab.Pages;

public partial class DeletePage : ContentPage
{
	public DeletePage()
	{
		InitializeComponent();
	}


public async void DeleteAsync(ModelClasses ModelClasses)
{
    try
    {
        ModelClasses modelClasses = new ModelClasses();
       

        //10.0.2.2 for Android, localhost for windows
        string apiURL = @"http://localhost:5263/api/Students" + ModelClasses.StudentId; 
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.DeleteAsync(apiURL);
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
    //private async void btnDelete_Clicked(object sender, EventArgs e)
    //{
    //    ModelClasses modelClasses = BindingContext as ModelClasses;
    //    DeleteAsync(modelClasses);
    //}

    private void btnDelete_Clicked_1(object sender, EventArgs e)
    {
        ModelClasses modelClasses = BindingContext as ModelClasses;
        DeleteAsync(modelClasses);
    }
}