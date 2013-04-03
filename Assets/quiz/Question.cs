using System;

namespace Quiz {
	public class Question {
		public string question;
		public string[] options;
		public int answer;
		
		public Question (string question, string[] options, int answer) {
			this.question = question;
			this.options = options;
			this.answer = answer;
		}
	}
}

