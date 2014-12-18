using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Linq;
using QCM.Portable;



namespace qcm.droid
{
	[Activity (Label = "qcm.droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{



		private List<Button> answerButtons;

		private Button button1;
		private Button button2;
		private Button button3;
		private Button button4;

		private TextView questiontextView;

		private TextView gradeTextView;

		private TextView progressTextView;

		QuestionnaireViewModel viewModel {
			get;
			set;
		}


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			QuestionnaireViewModel vm = new QuestionnaireViewModel ();
			this.viewModel = vm;

			this.questiontextView = FindViewById<TextView> (Resource.Id.textView1);
			this.button1 = FindViewById<Button> (Resource.Id.button1);
			this.button2 = FindViewById<Button> (Resource.Id.button2);
			this.button3 = FindViewById<Button> (Resource.Id.button3);
			this.button4 = FindViewById<Button> (Resource.Id.button4);
			this.answerButtons = new List<Button>{ button1, button2, button3, button4 };

			foreach (Button b in answerButtons) {
				b.Click += (object sender, EventArgs e) => 
				{
					int answerIdx = answerButtons.IndexOf(b) + 1;
					this.viewModel.SubmitAnswer(answerIdx);
				};
			}

			vm.questionChangeHandler += (object sender, EventArgs e) => {

				RefreshView();

			};

			vm.gameEndedHandler += (object sender, EventArgs e) => {

				var alertMaker=  new AlertMaker(this);
				alertMaker.DisplayAlert("Game over", 
					string.Format("Vos avez un score de {0} %", this.viewModel.score));

			};

			RefreshView ();

		}


		void RefreshView ()
		{
			this.questiontextView.Text = this.viewModel.CurrentQuestion.Text;
			foreach (var button in answerButtons) {
				button.Text = this.viewModel.CurrentQuestion.Answer [answerButtons.IndexOf (button)];
			}
		}
	}
		
}


