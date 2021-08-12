using MimeKit;
using System;

namespace AwsBucketProject4
{
    internal class EmailContent
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public DateTimeOffset Date { get; set; }
        public InternetAddressList From { get; set; }
        public InternetAddressList To { get; set; }
        public InternetAddressList Cc { get; set; }
        public HeaderList Headers { get; set; }
        public string Body { get; set; }
    }
}