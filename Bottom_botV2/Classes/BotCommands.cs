using System;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using System.Linq;
using Bottom_botV2.Utils;

namespace Bottom_botV2.Classes
{
    class BotCommands
    {

        private static RandomMessages randomMessages = new RandomMessages();
        private static string[] listCharacters = Constants.kListSmashCharacters;

        [Command("boneco"),
        Description("Seleciona um boneco de Smash randomicamente")]
        public async Task boneco(CommandContext ctx)
        {
            Random randomizer = new Random();
            int indexChar = randomizer.Next(0, listCharacters.Length);
            string selectedChar = listCharacters[indexChar];

            await ctx.Message.RespondAsync(selectedChar);
        }

        [Command("bottom"),
        Aliases("noel"),
        Description("Gera uma bottomzisse no chat")]
        public async Task bottom(CommandContext ctx)
        {
            string newMessage = randomMessages.GetNewMessage(ctx.User.Username);
            await ctx.Message.RespondAsync(newMessage);
        }

        [Command("setGame"),                    //Sets the game in the bot's status
        Description("Muda o jogo que o bot está jogando"),
        Cooldown(max_uses: 3, reset: 600, bucket_type: CooldownBucketType.Guild)]                                                 
        public async Task setGame(CommandContext ctx, [RemainingText] string gameName)
        {
            DiscordGame botGame = new DiscordGame();
            botGame.Name = gameName;
            await ctx.Client.UpdateStatusAsync(botGame);
            await ctx.Message.RespondAsync($"Done! Game {botGame.Name}");
        }

        [Command("github"),
        Aliases("source"),
        Description("Link para o código fonte do bot")]
        public async Task github(CommandContext ctx)
        {
            await ctx.Message.RespondAsync("https://github.com/HugoMorales/BottomBot");
        }

        [Command("invite"),                                         //creates and post a invite link to the server
        Description("Cria um invite temporário para o server")]
        public async Task invite(CommandContext ctx)
        {
            var invChannel = ctx.Guild.Channels.FirstOrDefault(channel => channel.Name == "geral");
            DiscordInvite invite;
            invite = await invChannel.CreateInviteAsync(temporary: true);
            await ctx.Message.RespondAsync($"{invite.ToString()}");
        }

        [Command("roll"),     //returns a random number
        Description("Gera um número randômico de 1 até o valor máximo informado"),
        Aliases("dice", "random")]
        public async Task random(CommandContext ctx, int max)
        {
            int number;
            max--;
            Random rdm = new Random();
            number = rdm.Next(1, max);
            await ctx.Message.RespondAsync($":game_die: {number} :game_die:");
        }
    }
}
