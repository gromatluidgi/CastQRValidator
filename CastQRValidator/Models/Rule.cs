namespace CastQRValidator.Models
{
    public class Rule
    {
        public Rule(int id, string originalName)
        {
            Id = id;
            OriginalName = originalName;
        }

        public int Id {  get; }

        public string OriginalName { get; }
    }
}
