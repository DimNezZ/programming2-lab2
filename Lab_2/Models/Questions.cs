using System;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;

namespace Lab_2.Models
{
    internal class Questions
    {
        private static Questions? instance;
        private readonly List<QuestionWithAnswers> originalQuestions = new List<QuestionWithAnswers>();
        private List<QuestionWithAnswers> currentQuestions = new List<QuestionWithAnswers>();

        private Questions()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ","
            };

            using var textReader = new StringReader(Properties.Resources.Data);
            using var csvReader = new CsvReader(textReader, csvConfig);

            originalQuestions = csvReader.GetRecords<QuestionWithAnswers>().ToList();
            currentQuestions = originalQuestions.ToList();
        }

        public static Questions GetInstance()
        {
            instance ??= new Questions();

            return instance;
        }

        public Questions ShuffleOrder()
        {
            currentQuestions = originalQuestions.OrderBy(_ => Guid.NewGuid()).ToList();

            return this;
        }

        public Questions RestoreOrder()
        {
            currentQuestions = originalQuestions.ToList();

            return this;
        }

        public List<QuestionWithAnswers> GetQuestions()
        {
            return currentQuestions;
        }

        public List<QuestionWithAnswers> GetQuestions(int count)
        {
            return currentQuestions.Take(count).ToList();
        }

        public int GetCount()
        {
            return currentQuestions.Count;
        }
    }
}
