namespace CastQRValidator.Models
{
    public class Engine
    {
        public Engine(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public string Name { get; set; }

        public string Path { get; set; }
    }
}
