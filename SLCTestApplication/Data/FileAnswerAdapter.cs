namespace SLCTestApplication.Data
{
    public class FileAnswerAdapter
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string FileType { get; set; }
        public string GetAnswerString()
        {
            return Name + '`' + Size + '`' + FileType;
        }
        public FileAnswerAdapter(string name, string size, string fileType) {
            Name = name;
            Size = size;
            FileType = fileType;
        }

        public FileAnswerAdapter(string answerString)
        {
            var splitAnswerString= answerString.Split('`');
            Name = splitAnswerString[0];
            Size = splitAnswerString[1];
            FileType = splitAnswerString[2];
        }
    }
}
