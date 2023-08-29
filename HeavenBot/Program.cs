using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace HeavenBot
{
    class Program
    {

        private DiscordSocketClient _client;

        static void Main(string[] args)
        {
            Console.WriteLine("Bot operativo");
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;

            var token = Config.Token;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Manda un mensaje al iniciar el bot de heaven jijijija
            var channel = await _client.GetChannelAsync(1138263856569909348) as IMessageChannel;
            await channel.SendMessageAsync("🟢 | HeavenBot Operativo");

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
