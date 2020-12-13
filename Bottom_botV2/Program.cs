using System;
using Bottom_botV2.Classes;

namespace Bottom_botV2
{
    class BottomBot
    {
        static void Main(string[] args)
        {
            string clientId;

            Console.WriteLine("Insert the Bot Client ID: ");
            clientId = Console.ReadLine();
            DiscordBot bottomBot = new DiscordBot(clientId);

            bottomBot.ConnectToDiscod();
        }
    }
}
