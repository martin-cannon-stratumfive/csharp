namespace k8s.KubeConfigModels
{
    using System.Collections.Generic;
    using YamlDotNet.Serialization;

    /// <summary>
    /// Exec class for user authentication
    /// </summary>
    /// <example>
    /// exec:
    //    apiVersion: client.authentication.k8s.io/v1alpha1
    //    args:
    //    - token
    //    - -i
    //    - aviso-prd-cluster
    //    command: heptio-authenticator-aws
    //    env: null
    /// </example>
    public class UserExec
    {
        /// <summary>
        /// Gets or sets the API version
        /// </summary>
        [YamlMember(Alias = "apiVersion")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the command to execute
        /// </summary>
        [YamlMember(Alias = "command")]
        public string Command { get; set; }

        /// <summary>
        /// Gets or sets the envronment variables
        /// </summary>
        [YamlMember(Alias = "env")]
        public IDictionary<string, string> Env { get; set; }

        [YamlMember(Alias = "args")]
        /// <summary>
        /// Gets or sets the command arguments
        /// </summary>
        public IList<string> Args { get; set; }
    }
}
