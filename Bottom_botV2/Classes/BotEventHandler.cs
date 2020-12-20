using System.Collections.Generic;
using System.Text;
using DSharpPlus;
using System.Threading.Tasks;
using Bottom_botV2.Utils;
using DSharpPlus.EventArgs;
using System;

namespace Bottom_botV2.Classes
{
    class BotEventHandler
    {
        private static RandomMessages randomMessages;
        private Dictionary<string, int> contChannels;   //Used to keep track of how many messages were sent in each channel

        public BotEventHandler()
        {
            randomMessages = new RandomMessages();
            contChannels = new Dictionary<string, int>();
        }

        public async Task MessageCreatedHandler(MessageCreateEventArgs botEvent)
        {
            string channelId = botEvent.Channel.Id.ToString();
            bool isBot = botEvent.Author.IsBot;
            bool isCommand = botEvent.Message.Content.StartsWith(Constants.kBotPrefix);

            if(!isBot && !isCommand) //Only continue if the new message is not a command and either created by a bot
            {
                if(contChannels.ContainsKey(channelId))
                {
                    contChannels[channelId]++;   

                    if(contChannels[channelId] >= Constants.kMessagesToTrigger)
                    {
                        string newMessage = randomMessages.GetNewMessage(botEvent.Author.Username);
                        await botEvent.Message.RespondAsync(newMessage);

                        contChannels[channelId] = 0;
                    }
                }
                else
                {
                    contChannels.Add(channelId, 1);
                }
            }
        }
    }
}
