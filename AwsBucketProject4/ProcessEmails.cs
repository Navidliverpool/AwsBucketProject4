using Amazon.S3;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwsBucketProject4
{
    public class ProcessEmails
    {
        public void EmailProcesser(AwsSettings awsSettings)
        {
            using (var s3Client = new AmazonS3Client(awsSettings.AwsAccessKeyID, awsSettings.AwsSecretAccessKey, awsSettings.Endpoint))
            {

                var objectList = s3Client.ListObjects(awsSettings.BucketName);
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
