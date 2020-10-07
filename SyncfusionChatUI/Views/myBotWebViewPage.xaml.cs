using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncfusionChatUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class myBotWebViewPage : ContentPage
    {
        public myBotWebViewPage(string token)
        {
            InitializeComponent();

            

            string botWebViewUrl = "https://webchat.botframework.com/embed/myXamTestBot?s=" + token;
            this.myBotWebView.Source = botWebViewUrl;
            
        }
    }
}