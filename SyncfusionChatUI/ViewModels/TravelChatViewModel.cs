using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Syncfusion.XForms.Chat;

namespace SyncfusionChatUI.ViewModels
{
    


    class TravelChatViewModel :BaseViewModel
    {
        private ObservableCollection<object> messages;

        public ObservableCollection<object> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }

        private Author currentUser;

        public Author CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                SetProperty(ref currentUser, value);
            }
            
        }

        private ChatSuggestions chatSuggestions;

        private ObservableCollection<ISuggestion> suggestions;

        public TravelChatViewModel()
        {
            this.messages = new ObservableCollection<object>();
            this.CurrentUser = new Author() { Name = "LadyBug", Avatar = "ladybugimg.png" };

            chatSuggestions = new ChatSuggestions();

            suggestions = new ObservableCollection<ISuggestion>();
            suggestions.Add(new Suggestion() { Text = "Airways 1", Image ="plane.png" });
            suggestions.Add(new Suggestion() { Text = "Airways 2" });
            suggestions.Add(new Suggestion() { Text = "Airways 3" });
            suggestions.Add(new Suggestion() { Text = "Airways 4" });

            chatSuggestions.Orientation = SuggestionsOrientation.Vertical;

            chatSuggestions.Items = suggestions;
            this.GenerateMessages();

        }

        private void GenerateMessages()
        {
            this.messages.Add(new TextMessage()
            {
                Author = CurrentUser,
                Text = "Flight to Milan",
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Avatar = "support.png", Name = "My Travel Bot" },
                Text = "Here's my suggestion",
                Suggestions = chatSuggestions,
            });
        }
    }

}
