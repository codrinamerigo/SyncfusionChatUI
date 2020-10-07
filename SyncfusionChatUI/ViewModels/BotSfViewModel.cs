using Syncfusion.XForms.Chat;
using SyncfusionChatUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SyncfusionChatUI.ViewModels
{
    class BotSfViewModel :BaseViewModel
    {
        private ObservableCollection<object> messages;

        private Author currentUser;

        private string _textMsg;

        private bool _isRefreshing;

        private ICommand _sendMessageCommand;

        private ChatBotService _chatBotService = new ChatBotService();

        public BotSfViewModel()
        {

            this.messages = new ObservableCollection<object>();
            this.currentUser = new Author() { Name = "LadyBug Bot", Avatar = "ladybugimg.png" };

            Messages.Add(new TextMessage
            {
                Author = currentUser,
                Text = "Hi this is ladybug bot, how may I help you?",
            });

        }

        public string TextMsg
        {
            get { return _textMsg; }
            set
            {
                _textMsg = value;
                OnPropertyChanged("TextMsg");
            }
        }

        public ICommand SendMessageCommand
        {
            get
            {
                return _sendMessageCommand = _sendMessageCommand ?? new Command(async () =>
                {
                    Messages.Add(new TextMessage
                    {
                        Author = new Author() { Name = "LadyBug Bot", Avatar = "ladybugimg.png" },
                        Text = "hi",
                    });

                    IsRefreshing = true;

                    var reply = await _chatBotService.SendMessage(TextMsg);

                    TextMsg = "hi";

                    Messages.Clear();

                    Author tempAuthor;

                    foreach (var msgItem in reply.Messages)
                    {
                        if (msgItem.From == "myXamTestBot")
                            tempAuthor = new Author() { Name = "LadyBug Bot", Avatar = "ladybugimg.png" };

                        else
                            tempAuthor = new Author() { Name = "User", Avatar = "user.png" };

                        Messages.Add(new TextMessage
                        {
                           
                            Author = tempAuthor,
                            Text = msgItem.Text

                        });
                    }

                    IsRefreshing = false;
                });
            }
        }


        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
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

    }
}
