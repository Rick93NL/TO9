using System;


namespace QuizQuestionNamespace {
	public class QuizQuestion {
		public string question;
		public string[] options;
		public double timeout;
		public string answer;
		
		public QuizQuestion (string filename) {
			// Complete file string
			string raw_quiz_data = System.IO.File.ReadAllText(filename);
			// Remove breaklines
			raw_quiz_data = raw_quiz_data.Replace (Environment.NewLine, "");
			
			// Split questions
			string[] question_data_list = raw_quiz_data.Split('~');
			foreach (string question_data in question_data_list) {
				// Parse the question+options+answer (question_timeout[0]) and the timeout value (question_timeout[1])
				string[] question_timeout = question_data.Split ('/');
				
				// Parse the timeout value
				try {
	            	time_left = Convert.ToDouble(question_timeout[1]);
		        } catch (FormatException) {
					time_left = 1000000;
		        } catch (OverflowException) {
					time_left = 1000000;
		        }
				
				// Parse the question+options (question_answer[0]) and the question answer (question_answer[1])
				string[] question_answer = question_timeout[0].Split('`');
				answer = question_answer[1];
				// Split the options
				options = question_answer[0].Split ('.');
			}
		}
	}
}