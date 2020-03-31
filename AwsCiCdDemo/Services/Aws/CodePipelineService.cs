using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace AwsCiCdDemo.Services.Aws
{
    public class CodePipelineService
    {
        private static readonly string PipelineName = "aws-ci-cd-demo-pipeline";

        private AmazonCodePipelineClient client;

        public CodePipelineService()
        {
            this.client = new AmazonCodePipelineClient(AwsCredentialService.Instance.accessKeyId, AwsCredentialService.Instance.secretKey);
        }

        public GetPipelineResponse getPipeline()
        {
            return client.GetPipeline(PipelineName);
        }

        public GetPipelineStateResponse getPipelineState()
        {
            return client.GetPipelineState(PipelineName);
        }
    }
}