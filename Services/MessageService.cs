using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorMvc.Models;

namespace RazorMvc.Services
{
    public class MessageService
    {
        private readonly List<Message> allMessages;

        public MessageService()
        {
            allMessages = new List<Message>();
        }

        public List<Message> GetAllMessages()
        {
            return allMessages;
        }

        public void AddMessage(string user, string message)
        {
            Message messageObj = new Message(user, message);
            allMessages.Add(messageObj);
        }
    }
}