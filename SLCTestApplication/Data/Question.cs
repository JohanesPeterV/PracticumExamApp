using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLCTestApplication.Data
{
    public class Question
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string QuestionType { get; set; }
        public List<string>? Choices { get; set; }
        public int? AnswerIndex { get; set; }
        public static string MultipleChoice = "MultipleChoice";
        public static string TrueOrFalse = "TrueOrFalse";
        public static string ChooseOne = "ChooseOne";
        public static string Essay = "Essay";
        public static string SubmitFile = "SubmitFile";
        public static List<string> AllTypes = new List<String>{ "MultipleChoice",
            "TrueOrFalse",
            "ChooseOne",
            "Essay",
            "SubmitFile"
            };
    }
}
