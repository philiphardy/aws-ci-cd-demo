using Amazon.CodePipeline.Model;
using AwsCiCdDemo.Services.Aws;
using System.Web.Http;

namespace AwsCiCdDemo.Controllers
{
    public class PipelineController : ApiController
    {
        private CodePipelineService service;

        public PipelineController()
        {
            this.service = new CodePipelineService();
        }

        [HttpGet]
        public GetPipelineStateResponse getPipelineState()
        {
            return service.getPipelineState();
        }
    }
}