using SyncfusionChatUI.ViewModels;

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
    public partial class CustomBotPage : ContentPage
    {
        private BotSfViewModel ViewModel;

        public CustomBotPage()
        {
            InitializeComponent();

        }
    }
}