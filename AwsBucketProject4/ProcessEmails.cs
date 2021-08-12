using Amazon.S3;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwsBucketProject4
{
    internal class ProcessEmails
    {
        public readonly List<EmailContent> EmailList = new List<EmailContent>();
        public int LastYearCount;
        public int ThisYearCount;
        public int ThisMonthCount;
        public int ThisWeekCount;
        public int TotalRecipientsCount;
        public int ToCount;
        public int CcCount;
        public int SubjectsContainsConfusionCount;
        public int MessagesContainsHeader_x_gt_settings;
        public int MessagesContainsThreeMusketeers;
        public int Error;
        int errorCounter;

        public void EmailProcesser(AwsSettings awsSettings)
        {
            using (var s3Client = new AmazonS3Client(awsSettings.AwsAccessKeyID, awsSettings.AwsSecretAccessKey, awsSettings.Endpoint))
            {

                var objectList = s3Client.ListObjects(awsSettings.BucketName);
                try
                {
                    foreach (var s3Object in objectList.S3Objects)
                    {

                        using (var retrievedObject = s3Client.GetObject(s3Object.BucketName, s3Object.Key))
                        {

                            MimeMessage message = MimeMessage.Load(retrievedObject.ResponseStream);

                            EmailContent result = new EmailContent()
                            {
                                Email = retrievedObject.Key,
                                Subject = message.Subject,
                                Date = message.Date,
                                From = message.From,
                                To = message.To,
                                Cc = message.Cc,
                                Headers = message.Headers,
                                Body = message.TextBody
                            };

                            EmailList.Add(result);
                        }
                    }
                }
                catch(Exception ex)
                {
                    errorCounter++;
                    Console.WriteLine($"Errors: {ex.Message}");
                }

                DateTimeOffset now = DateTimeOffset.Now;
                var lastYearDateTime = new DateTimeOffset(now.Year - 1, 1, 1, 0, 0, 0, DateTimeOffset.Now.Offset);
                var thisYearDateTime = new DateTimeOffset(now.Year, 1, 1, 0, 0, 0, DateTimeOffset.Now.Offset);
                var thisWeekDateTime = new DateTimeOffset(now.Year, now.Month, now.Day - 7, 0, 0, 0, DateTimeOffset.Now.Offset);

                LastYearCount = EmailList.Count(d => d.Date >= lastYearDateTime && d.Date < thisYearDateTime);
                ThisYearCount = EmailList.Count(d => d.Date >= thisYearDateTime);
                ThisMonthCount = EmailList.Count(d => d.Date.Month == now.Month);
                ThisWeekCount = EmailList.Count(d => d.Date >= thisWeekDateTime);
                ToCount = EmailList.Sum(t => t.To.Count);
                CcCount = EmailList.Sum(c => c.Cc.Count);
                TotalRecipientsCount = ToCount + CcCount;
                SubjectsContainsConfusionCount = EmailList.Count(s => s.Subject.ToLower().Contains("confusion"));
                MessagesContainsHeader_x_gt_settings = EmailList.Count(m => m.Headers.Contains("x-gt-settings"));
                MessagesContainsThreeMusketeers = EmailList.Count(m => m.Body.ToLower().Contains("athos")
                                                                       || m.Body.ToLower().Contains("aramis")
                                                                       || m.Body.ToLower().Contains("porthos"));
            }
        }
    }
}
