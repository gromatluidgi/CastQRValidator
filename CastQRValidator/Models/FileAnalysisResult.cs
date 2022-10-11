using System.Collections.Generic;

namespace CastQRValidator.Models
{
    internal class FileAnalysisResult
    {
        public FileAnalysisResult(string file, List<ResultViolation> results)
        {
            File = file;
            Results = results;
        }

        public string File { get; set; }
        public List<ResultViolation> Results { get; set; }

        public bool ViolationsMatch(List<Violation> violations)
        {
            return true;
        }
    }

    public struct ResultViolation
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Count { get; set; }
        public List<ResultViolationDetails> Violations { get; set; }
    }

    public struct ResultViolationDetails
    {
        public int Id { get; set; }
        public List<ResultViolationBookmarks> Bookmarks { get; set; }
    }

    public struct ResultViolationBookmarks
    {

    }
}
