using System;

namespace Quiz {
	public class QuizMaster {
		public int current_question;
		public int total_questions_count;
		
		private Question[] questions;
		
		public QuizMaster (string filename) {
			// Complete file string
			string raw_quiz_data = System.IO.File.ReadAllText(filename);
			// Remove breaklines
			raw_quiz_data = raw_quiz_data.Replace (Environment.NewLine, "");
			
			// Split questions
			string[] question_data_list = raw_quiz_data.Split('~');
			questions = new Question[question_data_list.Length + 1]; // Last question is filled with empty data
			
			int i = 0;
			foreach (string question_data in question_data_list) {				
				// Parse the question+options (question_answer[0]) and the question answer (question_answer[1])
				string[] question_options_answer = question_data.Split('`');
				int answer = (int) char.GetNumericValue(question_options_answer[1][0]);
				// Split the options
				string[] question_options = question_options_answer[0].Split ('.');
				
				string[] options = new string[question_options.Length - 1];
				for (int option = 0; option < options.Length; option++) {
					options[option] = question_options[option + 1];	
				}
				questions[i] = new Question(question_options[0], options, answer);
				
				i++;
			}
			
			questions[questions.Length - 1] = new Question("No more questions", new string[]{}, -1);
			
			current_question = -1;
			total_questions_count = questions.Length;
		}
		
		public Question next_question() {
			if (current_question < questions.Length - 1) {
				current_question++;
			}
			return questions[(current_question)];
		}
	}
}

