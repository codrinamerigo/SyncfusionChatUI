using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncfusionChatUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void myBotWebViewPageButton_Clicked(object sender, EventArgs e)
        {
            string token;

            // Get the token from HTTP Request
            token = await GetBotServiceToken();

            //open the webview 
            await Navigation.PushModalAsync(new myBotWebViewPage(token));
        }

        //get token from Azure
        private async Task<string> GetBotServiceToken()
        {
            HttpClient client = new HttpClient();
            string botKey = Config.WebChatBot;
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("BotConnector", botKey); //azure secret

            var url = new Uri("https://webchat.botframework.com/api/tokens");
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                string token = JsonConvert.DeserializeObject<string>(content);

                return token;
            }

            return String.Empty;
        }

        private async void CustomBotPageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CustomBotPage());
        }

        private async void FakeChatPageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FakeChatPage());
        }

        private async void ComplexChatButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TravelChatPage());
        }


        
    }
}