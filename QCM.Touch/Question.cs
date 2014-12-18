using System;
using System.Collections.Generic;
using System.Linq;

namespace qcm.droid
{
	public class Session
	{
		public bool HasNext ()
		{
			return true;
		}

		public Session()
		{
			StartedOn = DateTime.Now;
			CursorIndex = 0;

			Question q1 = new Question () {
				Id = 1,
				Text = "Quelle était la couleur du cheval blanc d'Henry IV ?",
				Answer = new string[]{ "blanc", "vert", "Obi Wan Kennoby", "la réponse D" },
				CorrectAnswerID = 1
			};
			Question q2 = new Question () {
				Id = 1,
				Text = "Qui a volé l'orange du Marchand ?",
				Answer = new string[]{ "SFR", "Guy Montagné", "Obi Wan Kennoby", "la réponse D" },
				CorrectAnswerID = 3
			};
			Question q3 = new Question () {
				Id = 1,
				Text = " 4 + 4?",
				Answer = new string[]{ "42", "8", "Obi Wan Kennoby", "la réponse D" },
				CorrectAnswerID = 2
			};
			Question q4 = new Question () {
				Id = 1,
				Text = "Quelle est la réponse a LA question",
				Answer = new string[]{ "42", "je klaxonne", "Obi Wan Kennoby", "la réponse D" },
				CorrectAnswerID = 4
			};

			Questions = new List<Question>(){q1, q2, q3, q4};
		}

		public DateTime StartedOn { get ; set ;}
		public IEnumerable<Question> Questions {get ; private set;}
		public int CursorIndex { get ; private set ;}
		public double score { get { 
				return (this.correctAnswersCount / this.answeredQuestionCount);
			}}

		private int answeredQuestionCount;
		private int correctAnswersCount;

		public Question Next()
		{
			if (CursorIndex++ == Questions.ToList ().Count) {
				throw new Exception ("Plus de questions");
			} else {
				return Questions.ElementAt (CursorIndex);
			}
		}

		public void SubmitAnswer(int submitIndex)
		{

			Question current = Questions.ElementAt(CursorIndex);
			if(current.IsCorrectAnswer(submitIndex))
			{
				this.correctAnswersCount++;
			}

			this.answeredQuestionCount++;
		}


	}



	public class Question
	{
		public Question ()
		{
		}

		public int Id{ get; set;}
		public string Text{ get; set;}
		public string[] Answer { get; set;}
		public uint CorrectAnswerID { get ; set;}

		public bool IsCorrectAnswer(int submitedAnswerIndex)
		{
			return submitedAnswerIndex == CorrectAnswerID;
		}

	}
}

