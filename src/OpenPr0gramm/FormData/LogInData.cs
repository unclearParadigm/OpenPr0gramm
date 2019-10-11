using System.Diagnostics;
using Refit;

namespace OpenPr0gramm.FormData
{
    public class LogInData
    {
        [AliasAs("name")] public string Name { get; set; }
        [AliasAs("password")] public string Password { get; set; }

        public LogInData(string name, string password)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(name));
            Name = name;
            Password = password;
        }
    }
}
