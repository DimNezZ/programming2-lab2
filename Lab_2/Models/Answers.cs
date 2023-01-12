using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.Models
{
    internal class Answers
    {
        private readonly Dictionary<int, int> answers = new Dictionary<int, int>();

        public void SaveAnswer(int questionId, int answerId)
        {
            answers[questionId] = answerId;
        }
        public int GetAnswer(int questionId)
        {
            if (answers.ContainsKey(questionId))
            {
                return answers[questionId];
            }

            return 0;
        }

        public float GetMatchingPercentage(Answers other)
        {
            List<int> answersIds = answers.Keys.Union(other.answers.Keys).Distinct().ToList();
            int correntAnswersCount = 0;
            foreach (int answersId in answersIds)
            {
                if (GetAnswer(answersId) == other.GetAnswer(answersId))
                {
                    correntAnswersCount++;

                }
            }

            return (float) correntAnswersCount / answersIds.Count;
        }
    }
}
