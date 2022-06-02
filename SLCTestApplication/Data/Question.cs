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
        public List<ScheduleQuestion> ScheduleQuestions { get; set; }
        public List<ChoiceAdapter>? GetChoiceAdapters()
        {
            if (Choices == null) return null;
            List<ChoiceAdapter> choiceAdapterList = new List<ChoiceAdapter>();
            var i = 0;
            foreach (var choice in Choices)
            {
                choiceAdapterList.Add(new ChoiceAdapter { Index = ++i, Value = choice });
            }
            return choiceAdapterList;
        }
        public List<ChoiceAdapter> GetNullSafeChoiceAdapters()
        {
            if (Choices == null) return new List<ChoiceAdapter>();
            List<ChoiceAdapter> choiceAdapterList = new List<ChoiceAdapter>();
            var i = 0;
            foreach (var choice in Choices)
            {
                choiceAdapterList.Add(new ChoiceAdapter { Index = ++i, Value = choice });
            }
            return choiceAdapterList;
        }
        public void SetChoices(List<ChoiceAdapter>? choiceAdapters)
        {
            if (Choices == null || choiceAdapters == null) return;
            Choices.Clear();
            foreach (var choiceAdapter in choiceAdapters)
            {
                Choices.Add(choiceAdapter.Value);
            }
        }
        public static string MultipleChoice = "MultipleChoice";
        public static string TrueOrFalse = "TrueOrFalse";
        public static string ChooseOne = "ChooseOne";
        public static string Essay = "Essay";
        public static string SubmitFile = "SubmitFile";
        public static List<string> AllTypes = new List<string>{ "MultipleChoice",
            "TrueOrFalse",
            "ChooseOne",
            "Essay",
            "SubmitFile"
            };

    }
}
