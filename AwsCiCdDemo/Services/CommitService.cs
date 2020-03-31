using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
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
            this.validateEnvironment();

            // format the commit message
            commitMsg = commitMsg == null ? "" : commitMsg.Trim();
            if (commitMsg.Length > 0)
            {
                commitMsg = String.Format(" {0}", commitMsg);
            }

            // run the git cmds via cmd prompt
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.Arguments = String.Format("/c cd {0} && git checkout build-and-deploy && git commit --allow-empty -m \"Triggering build...{1}\" && echo committed > C:\\watch\\committed", this.gitProjectPath, commitMsg);
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "C:\\Windows\\System32\\cmd.exe";
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process process = Process.Start(startInfo);
            process.Exited += new EventHandler((sender, e) =>
            {
                File.WriteAllText("C:\\temp\\exit-code.txt", process.ExitCode.ToString());
            });

            process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                File.AppendAllText("C:\\temp\\log.err", e.Data);
            });

            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) => {
                File.AppendAllText("C:\\temp\\log.out", e.Data);
            });

            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

        }

        private void validateEnvironment()
        {
            if (this.gitProjectPath == null)
            {
                throw new Exception("No `GIT_PROJECT_PATH` env variable configured. Create it and restart the server.");
            }
        }
    }
}