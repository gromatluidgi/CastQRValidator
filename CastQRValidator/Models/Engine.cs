namespace CastQRValidator.Models
{
    public class Engine
    {
        public Engine(string name, string path, string arguments)
        {
            Name = name;
            Path = path;
            Arguments = arguments;
        }

        public string Name { get; set; }

        public string Path { get; set; }

        public string Arguments { get; set; }
    }
}
