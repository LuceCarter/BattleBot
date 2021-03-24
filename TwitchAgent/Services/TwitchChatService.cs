using TwitchAgent;
using BattleBot.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using System.Text.RegularExpressions;

namespace TwitchAgent.Services
{
    public class TwitchChatService
    {
        private readonly TwitchClient _client;
        private readonly TwitchSettings _settings;
        private readonly HubConnection _connection;

        public TwitchChatService(
            TwitchSettings twitchSettings,
            HubConnection connection)
        {
            _settings = twitchSettings;
            _connection = connection;
            _connection.StartAsync();

            ConnectionCredentials connectionCredentials = new ConnectionCredentials(_settings.Channel, _settings.AuthToken);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };

            WebSocketClient webSocketClient = new WebSocketClient(clientOptions);
            _client = new TwitchClient(webSocketClient);

            _client.Initialize(connectionCredentials, "LuceCarter");

            _client.OnLog += TwitchClient_OnLog;
            _client.OnJoinedChannel += TwitchClient_OnJoinedChannel;
            _client.OnMessageReceived += TwitchClient_OnMessageReceived;
            _client.OnConnected += TwitchClient_OnConnected;

            _client.Connect();
        }

        private void TwitchClient_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine("Hey guys! I am a bot connected via TwitchLib!");
            _client.SendMessage("LuceCarter", "Battlebot Engaged!!!!");           
        }

        private void TwitchClient_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");           
        }

        private async void TwitchClient_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            var userMessage = e.ChatMessage.Message;
            var hexValue = "";

           if(Regex.IsMatch(userMessage, "^!hex #([a-f0-9]{6}|[a-f0-9]{3})$", RegexOptions.IgnoreCase))
            {
                try
                {
                    hexValue = userMessage.Substring(6);

                    var colourName = await ColourService.GetColourFromHex(hexValue);
                    _client.SendMessage("LuceCarter", $"The closest colour to #{hexValue} is {colourName}");
                   

                } catch
                    {
                        Console.WriteLine("Unable to parse Hex Value");
                    }
            }

            await _connection.InvokeAsync("SendMessage", $"{e.ChatMessage.DisplayName}", $"{e.ChatMessage.Message}");
        }

        private void TwitchClient_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime.ToString()} {e.BotUsername}: {e.Data}");
        }
    }
}
