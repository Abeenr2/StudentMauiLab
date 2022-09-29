using StudentMauiLab.Model;

namespace StudentMauiLab.Pages;

public partial class DetailsPage : ContentPage
{
	public DetailsPage()
	{
		InitializeComponent();
	}

	private async void btnDelete_Clicked(ModelClasses modelClasses)
	{
        try
        {

            //10.0.2.2 for Android, localhost for windows
            string apiURL = @"http://localhost:5263/api/Students/" + modelClasses.StudentId;
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

    private void Delete_Clicked(object sender, EventArgs e)
    {
        ModelClasses modelClasses = BindingContext as ModelClasses;
        btnDelete_Clicked(modelClasses);
    }

    private async void Edit_Clicked(object sender, EventArgs e)
    {
        ModelClasses modelClasses = BindingContext as ModelClasses;
        EditPage editPage = new EditPage(modelClasses);
        await Navigation.PushAsync(editPage);
    }

}