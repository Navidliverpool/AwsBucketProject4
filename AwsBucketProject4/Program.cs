using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwsBucketProject4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process Email
            var processEmails = new ProcessEmails();

            AwsSettings awsSettings = new AwsSettings()
            {
                AwsAccessKeyID = ConfigurationManager.AppSettings["awsAccessKeyID"],
                AwsSecretAccessKey = ConfigurationManager.AppSettings["awsSecretAccessKey"],
                BucketName = ConfigurationManager.AppSettings["bucketName"]
            };

            //Display Dataset 1
            processEmails.EmailProcesser(awsSettings);
            foreach (var email in processEmails.EmailList)
            {
                Console.WriteLine($"Email:  {email.Email}");
                Console.WriteLine($"Subject:  {email.Subject}");
                Console.WriteLine($"Data:  {email.Date}");
                Console.WriteLine($"From:  {email.From}");
                Console.WriteLine($"To:  {email.To}");
                Console.WriteLine($"Cc:  {email.Cc}");
                Console.WriteLine("-----------------------------------------------------------");
            }
        }
    }
}
