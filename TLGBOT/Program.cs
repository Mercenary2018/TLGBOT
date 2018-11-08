using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using GetProxy;
using NetTelegramBotApi;
using Telegram;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using БиблиотекаМодерации;

namespace TLGBOT
{
    class Program
    {
    
    static WebProxy wp = new WebProxy(GetGoodProxy.ParseProxies(), true);

        private static readonly TelegramBotClient Bot = new TelegramBotClient("TOKEN", wp);
        private static readonly TelegramBot NetBot = new TelegramBot("TOKEN");
        static void Main(string[] args)
        {
            Console.WriteLine("Телеграм-бот \"SHARP_POLICE\"");
            Console.WriteLine("Адресс прокси: " + GetGoodProxy.ParseProxies());
            try
            {
                Bot.OnMessage += Bot_OnMessage;
                Bot.OnMessageEdited += Bot_OnMessage;
                Bot.StartReceiving();
                Console.ReadLine();
                Bot.StopReceiving();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private static void BOT_TEST(object sender, Telegram.Bot.Args.InlineQueryEventArgs w)
        {
            
        }
        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            
            if (e.Message.Type == MessageType.TextMessage)
            {
                if (e.Message.Text != null)
                {
                    if (Антимат.ФильтрацияМата(e.Message.Text))
                    {
                       Bot.SendTextMessageAsync(e.Message.Chat.Id, "Антимат чекнул по ключу: "+ e.Message.Text);
                    }

                    
                    if (e.Message.Text == "/status")
                    {
                        Bot.SendTextMessageAsync(e.Message.Chat.Id, "Бот работает. Адрес прокси: "+ GetGoodProxy.ParseProxies());
                    }
                }
                else
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Bad");
                }
            }
        }
    }
}
