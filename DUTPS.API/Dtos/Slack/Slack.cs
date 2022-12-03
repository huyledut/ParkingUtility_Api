using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SlackBotMessages;
using SlackBotMessages.Models;

namespace DUTPS.API.Dtos.Slack
{
    public class Slack
    {
        private Slack() { }
        private static Slack _instance;
        public static Slack GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Slack();
            }
            return _instance;
        }
        private SbmClient client = new SbmClient("https://hooks.slack.com/services/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");
        public void SendMessage(string msg)
        {
            var message = new Message("Notification <!channel> " + Emoji.Warning)
            .SetUserWithEmoji("Website", Emoji.Warning);
            message.AddAttachment(new SlackBotMessages.Models.Attachment()
            .AddField("Error", msg , false)
            .AddField("Team", "BCHTQ", true)
            .AddField("BOT create by:", "Binh Phan", true)
            .SetThumbUrl("https://cdn3.iconfinder.com/data/icons/basicolor-signs-warnings/24/182_warning_notice_error-512.png")
            .SetColor("#f50515"));
            client.Send(message);
        }
    }
}

