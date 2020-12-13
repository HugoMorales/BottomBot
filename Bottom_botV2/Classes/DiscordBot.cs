using DSharpPlus;
using DSharpPlus.CommandsNext;
using Bottom_botV2.Utils;

namespace Bottom_botV2.Classes
{
    class DiscordBot
    {
        private DiscordClient botClient;
        private DiscordConnection botConnection;
        private static BotEventHandler eventHandler;
        private static CommandsNextModule botCommands;

        public DiscordBot(string clientId)
        {
            botConnection = new DiscordConnection();
            eventHandler = new BotEventHandler();
            botClient = botConnection.CreateConnection(clientId);

            botCommands = botClient.UseCommandsNext(new CommandsNextConfiguration { StringPrefix = Constants.kBotPrefix });      //Sets the prefix used for commands
            botCommands.RegisterCommands<BotCommands>();

            botClient.MessageCreated += eventHandler.MessageCreatedHandler;
        }

        public void ConnectToDiscod()
        {
            botConnection.ConnectToDiscord(botClient).GetAwaiter().GetResult();
        }
    }
}
