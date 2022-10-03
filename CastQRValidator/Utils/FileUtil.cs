using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    }
}
