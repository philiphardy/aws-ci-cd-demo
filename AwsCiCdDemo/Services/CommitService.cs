using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AwsCiCdDemo.Services
{
    public class CommitService
    {
        private string gitProjectPath;

        public CommitService()
        {
            this.gitProjectPath = Environment.GetEnvironmentVariable("GIT_PROJECT_PATH", EnvironmentVariableTarget.Machine);
            if (this.gitProjectPath == null)
            {
                Debug.WriteLine("No `GIT_PROJECT_PATH` env variable found.");
            }
        }

        public void addEmptyCommit(string commitMsg)
        {
            if (this.gitProjectPath == null)
            {
                throw new Exception("No `GIT_PROJECT_PATH` env variable configured. Create it and restart the server.");
            }

            // format the commit message
            commitMsg = commitMsg.Trim();
            if (commitMsg.Length > 0)
            {
                commitMsg = String.Format(" {0}", commitMsg);
            }

            // run the git cmds via cmd prompt
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = String.Format("/c cd {0} && git commit --allow-empty -m \"Triggering build...{1}\" && git push origin build-and-deploy", this.gitProjectPath, commitMsg);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(startInfo);
        }
    }
}