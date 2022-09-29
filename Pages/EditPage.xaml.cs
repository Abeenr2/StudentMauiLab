using Newtonsoft.Json;
using StudentMauiLab.Model;
using System.Text;

namespace StudentMauiLab.Pages;

public partial class EditPage : ContentPage
{
    private ModelClasses _modelClasses;
	public EditPage(ModelClasses modelClasses)
	{
		InitializeComponent();
        _modelClasses = modelClasses;

    }
    
	//private async void Edit_Clicked()
	//{
       
 //   }

    private async void Edit_Clicked_1(object sender, EventArgs e)
    {
        try
        {

            _modelClasses.Name = txtName.Text;
            _modelClasses.Email = txtEmail.Text;


            //10.0.2.2 for Android, localhost for windows
            string apiURL = @"http://localhost:5263/api/Students/" + _modelClasses.StudentId; // @"http://localhost:5125/api/CarBrands";
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(_modelClasses), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync(apiURL, content);
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
    //private async void btnEdit_Clicked(object sender, EventArgs e)
    //{
    //    if (((Button)sender).BindingContext== null)
    //    {
    //        return;
    //    }
    //    ModelClasses selectedStudent =  ((Button)sender).BindingContext as ModelClasses;
    //    //var editPage = new EditPage();
    //    editPage.BindingContext = selectedStudent;
    //    await this.Navigation.PushAsync(editPage);
    //}
}