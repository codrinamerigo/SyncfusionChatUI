using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SyncfusionChatUI.Models
{

        public class ConversationMessage
        {
            public string Id { get; set; }

            public string Message { get; set; }

            public string FromUser { get; set; }

            public ImageSource UserImageUrl { get; set; }
        }
    
}
