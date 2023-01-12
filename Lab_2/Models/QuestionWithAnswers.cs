namespace Lab_2.Models
{
    // DTO - Data Transfer Object или Data Class
    internal class QuestionWithAnswers
    {
        public string? Question { get; set; }
        public float VariantA { get; set; }
        public float VariantB { get; set; }
        public float VariantC { get; set; }
        public float VariantD { get; set; }
        public int AnswerNumber { get; set; }
    }
}