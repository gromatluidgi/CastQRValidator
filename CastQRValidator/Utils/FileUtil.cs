using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace CastQRValidator.Utils
{
    public static class FileUtil
    {
        public static T? ReadJsonFromFile<T>(string filepath)
        {
            string json = string.Empty;

            using (StreamReader read = new StreamReader(filepath))
            {
                json = read.ReadToEnd();
            }
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,
            });
        }

        public static List<string> SearchFilesFromBaseDir(string baseDirectory, string regexPattern)
        {
            var dir = new DirectoryInfo(baseDirectory);
            if (!dir.Exists) throw new DirectoryNotFoundException();

            var regex = new Regex(regexPattern);

            List<string> files = dir.EnumerateFiles().Select(f => f.Name).ToList();
            return files.Where(f => regex.IsMatch(f)).ToList();
        }
    }
}
