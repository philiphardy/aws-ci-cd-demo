using AwsCiCdDemo.Models;
using AwsCiCdDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AwsCiCdDemo.Controllers
{
    public class CommitController : ApiController
    {
        private AwsService awsService;
        private CommitService commitService;

        public CommitController()
        {
            this.awsService = new AwsService();
            this.commitService = new CommitService();
        }

        // POST api/commits
        public void Post([FromBody]CommitMessage commitMsg)
        {
            // check if a build is already running and if so, do not allow another commit to be created

            // add the commit
            this.commitService.addEmptyCommit(commitMsg.commitMsg);
        }
    }
}
