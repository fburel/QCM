using System;

namespace QCM.Portable
{
	public class QuestionnaireViewModel
	{

		Session CurrentSession;

		public Question CurrentQuestion { get{ 
				return CurrentSession.CurrentQuestion;
			}
		}
		public double score { get { 
				return CurrentSession.score;
			}
		}

		public delegate void QuestionChanged (object sender, EventArgs e);
		public event QuestionChanged questionChangeHandler;

		public delegate void GameEnded (object sender, EventArgs e);
		public event GameEnded gameEndedHandler;



		public QuestionnaireViewModel ()
		{
			CurrentSession = new Session ();
		}

		public void SubmitAnswer(int answerIndex)
		{
			CurrentSession.SubmitAnswer (answerIndex);
			if (CurrentSession.HasNext) {
				Question nextQuestion = CurrentSession.Next;
				questionChangeHandler (this, null);

			} else {
				gameEndedHandler (this, null);
			}

		}



	}
}

