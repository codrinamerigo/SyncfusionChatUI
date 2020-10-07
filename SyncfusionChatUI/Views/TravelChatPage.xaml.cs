using Syncfusion.XForms.Chat;
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
    public partial class TravelChatPage : ContentPage
    {
        public TravelChatPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            this.sfChat.SuggestionItemSelected += this.SfChat_SuggestionItemSelected;
        }
        private void SfChat_SuggestionItemSelected(object sender, SuggestionItemSelectedEventArgs e)
        {
            // Suggestion list not closed after selection.
            e.HideAfterSelection = false;

        }
    }
}