using System;
using System.Collections.Generic;
using SyncfusionChatUI.ViewModels;
using SyncfusionChatUI.Views;
using Xamarin.Forms;

namespace SyncfusionChatUI
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, false);
        }

    }
}
