using DSharpPlus;
using System.Threading.Tasks;
using System;

namespace Bottom_botV2.Classes
{
    class DiscordConnection
    {
        public DiscordClient CreateConnection(string clientId)
        {
            DiscordClient botClient = new DiscordClient(new DiscordConfiguration()
            {
                Token = clientId,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug,
                DateTimeFormat = "dd MM yyyy HH:mm:ss"
            });

            return botClient;
        }

        public async Task ConnectToDiscord(DiscordClient botClient)
        {
            Console.WriteLine("Trying to estabilish a connection to Discord...");

            try
            {
                await botClient.ConnectAsync();
                Console.WriteLine("Connection estabilished! Bot is up and running!");
                await Task.Delay(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to estabilish a connection");
                Console.WriteLine(e.Message);
            }

        }
    }
}
