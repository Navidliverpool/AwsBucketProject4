using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwsBucketProject4
{
    public class AwsSettings
    {
        public string AwsAccessKeyID { get; set; }
        public string AwsSecretAccessKey { get; set; }
        public RegionEndpoint Endpoint { get; set; } = RegionEndpoint.USEast1;
        public string BucketName { get; set; }
    }
}
