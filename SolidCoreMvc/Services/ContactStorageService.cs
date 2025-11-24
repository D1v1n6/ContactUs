using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SolidCoreMvc.Models;

namespace SolidCoreMvc.Services
{
    public class ContactStorageService
    {
        private readonly string _filePath = "ContactMessages.json";

        public List<ContactMessage> GetMessages()
        {
            if (!System.IO.File.Exists(_filePath))
                return new List<ContactMessage>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<ContactMessage>>(json)
                   ?? new List<ContactMessage>();
        }

        public void SaveMessage(ContactMessage message)
        {
            var messages = GetMessages();
            messages.Add(message);

            var json = JsonSerializer.Serialize(messages, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_filePath, json);
        }
    }
}
