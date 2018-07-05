using System;
using System.Collections.Generic;
using System.Diagnostics;
using k8s;

namespace simple
{
    internal class PodList
    {
        private static void Main(string[] args)
        {
            KubernetesClientConfiguration.ShellExecute = ShellHelper.Exec;
            var config = KubernetesClientConfiguration.BuildConfigFromConfigFile();
            IKubernetes client = new Kubernetes(config);
            Console.WriteLine("Starting Request!");

            var list = client.ListNamespacedPod("default");
            foreach (var item in list.Items)
            {
                Console.WriteLine(item.Metadata.Name);
            }
            if (list.Items.Count == 0)
            {
                Console.WriteLine("Empty!");
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }

    public static class ShellHelper
    {
        public static string Exec(string cmd, IList<string> args, IDictionary<string, string> env)
        {
            var escapedArgs = string.Join(" ", args).Replace("\"", "\\\"");

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = cmd,
                    Arguments = escapedArgs,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            if (env != null && env.Count > 0)
            {
                foreach (var envVar in env)
                {
                    process.StartInfo.EnvironmentVariables[envVar.Key] = envVar.Value;
                }
            }
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }
    }
}
