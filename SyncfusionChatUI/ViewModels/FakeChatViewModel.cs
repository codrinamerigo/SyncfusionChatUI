using Syncfusion.XForms.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace SyncfusionChatUI.ViewModels
{
    class FakeChatViewModel : BaseViewModel
    {
       
        private ObservableCollection<object> messages;

        private Author currentUser;

        private ICommand suggestionItemSelectedCommand;

        public ICommand SuggestionItemSelectedCommand
        {
            get
            {
                return this.suggestionItemSelectedCommand;
            }
            set
            {
                this.suggestionItemSelectedCommand = value;
            }
        }

        public FakeChatViewModel()
        {
            SuggestionItemSelectedCommand = new SuggestionItemSelectedCommandExt();

            this.messages = new ObservableCollection<object>();
            this.currentUser = new Author() { Name = "Support", Avatar = "support.png" };
            this.GenerateMessages();
        }

        public class SuggestionItemSelectedCommandExt : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                var args = parameter as SuggestionItemSelectedEventArgs;
                // Suggestion list not closed after selection.
                args.HideAfterSelection = false;
            }
        }

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

        private void GenerateMessages()
        {
            this.messages.Add(new TextMessage()
            {
                Author = currentUser,
                Text = "Hello, good morning! How may I help you ?",
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "LadyBug", Avatar = "ladybugimg.png" },
                Text = "I have a problem with my computer.",
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "LadyBug", Avatar = "ladybugimg.png" },
                Text = "It makes a weird sound.",
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "LadyBug", Avatar = "ladybugimg.png" },
                Text = "And it stops from working.",
            });

            this.messages.Add(new TextMessage()
            {
                Author = currentUser,
                Text = "Can I have your PC model and number.",
            });
        }
    }
}
