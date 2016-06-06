using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace AttachmentBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {

        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                if (message.Text.ToLower() == "small image" || message.Text.ToLower() == "smallimage")
                    return this.GetSmallImageMessage(message);

                if (message.Text.ToLower() == "large image" || message.Text.ToLower() == "largeimage")
                    return this.GetLargeImageMessage(message);

                if (message.Text.ToLower() == "pdf")
                    return this.GetPdfMessage(message);

                if (message.Text.ToLower() == "word")
                    return this.GetWordMessage(message);

                if (message.Text.ToLower() == "rich content")
                    return this.GetRichContentMessage(message);

                return this.GetHelpMessage(message);
            }
            return HandleSystemMessage(message);
        }

        private Message GetRichContentMessage(Message message)
        {
            var returnMessage =
                message.CreateReplyMessage("Here is a message with rich content" + Environment.NewLine);
            returnMessage.Attachments = new List<Attachment>
            {
                new Attachment
                {
                    Title = "Here is the PDF you requested." + Environment.NewLine,
                    Text = "Hope you like attachments!",
                    TitleLink = "http://lukkhacoder.com",
                    ContentUrl = "http://lukkhacoder.com/shared/publicfiles/WhatAreTheBotBuilderSdks.pdf",
                    ContentType = "application/pdf",
                    ThumbnailUrl = "https://openclipart.org/image/60px/svg_to_png/237990/pdf17.png"

                }
            };
            return returnMessage;
        }

        private Message GetSmallImageMessage(Message message)
        {
            var returnMessage = message.CreateReplyMessage("Here is a message with a small image of the Microsoft logo."+Environment.NewLine);
            returnMessage.Attachments = new List<Attachment>
            {
                new Attachment
                {
                    ContentType = "image/png",
                    ContentUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/96/Microsoft_logo_%282012%29.svg/200px-Microsoft_logo_%282012%29.svg.png"

                }
            };

            return returnMessage;
        }

        private Message GetLargeImageMessage(Message message)
        {
            var returnMessage = message.CreateReplyMessage("Here is a message with a large image from the Microsoft campus." + Environment.NewLine);
            returnMessage.Attachments = new List<Attachment>
            {
                new Attachment
                {
                    ContentType = "image/jpeg",
                    ContentUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Microsoft_RedWest_Landscaping.JPG/800px-Microsoft_RedWest_Landscaping.JPG"

                }
            };

            return returnMessage;
        }

        private Message GetPdfMessage(Message message)
        {
            var returnMessage = message.CreateReplyMessage("Here is a message with a PDF." + Environment.NewLine);
            returnMessage.Attachments = new List<Attachment>
            {
                new Attachment
                {
                    ContentType = "application/pdf",
                    ContentUrl = "http://lukkhacoder.com/shared/publicfiles/WhatAreTheBotBuilderSdks.pdf"
                }
            };
            return returnMessage;
        }
        private Message GetWordMessage(Message message)
        {
            var returnMessage = message.CreateReplyMessage("Here is a message with a PDF." + Environment.NewLine);
            returnMessage.Attachments = new List<Attachment>
            {
                new Attachment
                {
                    ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    ContentUrl = "http://lukkhacoder.com/shared/publicfiles/WhatAreTheBotBuilderSdks.docx"
                }
            };
            return returnMessage;
        }
        private Message GetHelpMessage(Message message)
        {
            string formattedMessage = "- type **small image** to get a message with a small image" + Environment.NewLine
                                      + "- type **large image** to get a message with a large image" +
                                      Environment.NewLine
                                      + "- type **pdf** to get a message with a pdf file" + Environment.NewLine
                                      + "- type **word** to get a message with a word document" + Environment.NewLine
                                      + "- type **rich content** to get an example of a rich content attachment" +
                                      Environment.NewLine;

            return message.CreateReplyMessage(formattedMessage);
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}