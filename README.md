## <p>*AwsBucketProject4* is a C# Console Application with the target framework of 4.5 which reads some data from an AWS bucket and displays two sets of data to the output.<p> 
<p>The project needs to have an access to the AWS bucket "awsAccessKeyID", "awsSecretAccessKey" and "bucketName".<p>



##### Dataset 1 displays a bunch of information prepared from the bucket such as:
```
Email:                 Name of file obtained from retrievedObject.Key
Subject:               The subject of the email
Date:                  the date
From:                  Who the message is from
To:                    The number count of To recipients
Cc:                    Cc The number count of Cc recipients
``` 
 

##### Dataset 2 displays a count of some extreated information from the dataset 1:
```
Last Year:                                Count of emails dated from the year before the current year
This Year:                                Count of emails dated in the current year
This Month:                               Count of emails dated in the current month
This Week:                                Count of emails dated in the current week
To Count:                                 Count of all ‘To’ recipients
CC Count:                                 Count of all ‘CC’ recipients
Subjects Contains Confusion:              Count of the emails where the character string ‘confusion’ appears in the subject
Messages Contains Header x-gt-settings:   Count of the emails where the headers contains the character string ‘x-gt-settings’
Messages Contains Three Musketeers:       Count of the times any of the Three Musketeers (Athos, Aramis or Porthos)
Sender From space.corp:                   Count of the emails where a sender has the domain space.corp
Errors:                                   Count of the errors encountered
```
