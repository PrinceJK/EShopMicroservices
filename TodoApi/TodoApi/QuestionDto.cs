namespace TodoApi
{
    public class QuestionDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public class ParagraphQuestionDto : QuestionDto
    {
        public int MaxLength { get; set; } // Maximum length of the paragraph
    }

    public class YesNoQuestionDto : QuestionDto
    {
        public bool DefaultValue { get; set; } // Default value (true/false)
    }

    public class DropdownQuestionDto : QuestionDto
    {
        public List<string> Options { get; set; } // List of dropdown options
    }

    public class MultipleChoiceQuestionDto : QuestionDto
    {
        public List<string> Choices { get; set; } // List of multiple choices
    }

    public class DateQuestionDto : QuestionDto
    {
        public DateTime MinDate { get; set; } // Minimum allowed date
        public DateTime MaxDate { get; set; } // Maximum allowed date
    }

    public class NumberQuestionDto : QuestionDto
    {
        public double MinValue { get; set; } // Minimum allowed value
        public double MaxValue { get; set; } // Maximum allowed value
    }

}
