using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Contact
    {
        private const string TEXT_FILE_NAME = "Contact.txt";
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public static void WriteContact (Contact contact)
        {
            var contactData = $"{contact.Name}, {contact.PhoneNumber}";
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, contactData);
        }

        public async static Task<ICollection<Contact>>
            GetAllContactsAsync()
        {
            var contacts = new List<Contact>();
            var content = await
                FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            var lines = content.Split('\r', '\n');
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                var lineParts = line.Split(',');
                var contact = new Contact
                {
                    Name = lineParts[0],
                    PhoneNumber = lineParts[1]
                };
                contacts.Add(contact);
            }

            return contacts;
        }
    }
}
