using System.ComponentModel;
using Xamarin.Forms;
using SyncfusionChatUI.ViewModels;

namespace SyncfusionChatUI.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}