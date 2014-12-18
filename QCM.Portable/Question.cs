using System;
using System.Collections.Generic;
using System.Linq;
using QCM.Portable;

namespace QCM.Portable
{
	public class Session
	{





		public Session()
		{
			CursorIndex = 0;

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

		IEnumerable<Question> Questions;
		int CursorIndex;


		public double score { get { 
				return (this.correctAnswersCount / this.answeredQuestionCount);
			}}

		private int answeredQuestionCount;
		private int correctAnswersCount;

		public bool HasNext {get { 
				return CursorIndex < Questions.Count() - 1;
			}
		}

		public Question CurrentQuestion{ get { 
				return Questions.ElementAt (CursorIndex);
			}
		}


		public Question Next { get { 
				if (!HasNext) {
					return null;
				} else {
					CursorIndex++;
				}
				return CurrentQuestion;
			}}

		public void SubmitAnswer(int submitIndex)
		{

			Question current = CurrentQuestion;
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

