using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AwsCiCdDemo.Services.Aws
{
    public class CodeBuildService
    {
        private AmazonCodeBuildClient client;

        public CodeBuildService()
        {
            this.client = new AmazonCodeBuildClient(AwsCredentialService.Instance.accessKeyId, AwsCredentialService.Instance.secretKey);
            this.listBuilds();
        }

        public void listBuilds()
        {
            ListBuildsResponse response = this.client.ListBuilds(new ListBuildsRequest { SortOrder = SortOrderType.DESCENDING });
            Debug.WriteLine(response.Ids);
        }
    }
}