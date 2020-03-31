using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwsCiCdDemo.Services.Aws
{
    public class AwsCredentialService
    {
        public static readonly AwsCredentialService Instance = new AwsCredentialService();

        public string accessKeyId { get; }
        public string secretKey { get; }
        
        private AwsCredentialService()
        {
            this.accessKeyId = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID", EnvironmentVariableTarget.Machine);
            this.secretKey = Environment.GetEnvironmentVariable("AWS_SECRET_KEY", EnvironmentVariableTarget.Machine);
            if (this.accessKeyId == null || this.secretKey == null)
            {
                throw new Exception("Could not configure AwsCredentialService: Missing `AWS_ACCESS_KEY_ID` and/or `AWS_SECRET_KEY` env variables");
            }
        }
    }
}