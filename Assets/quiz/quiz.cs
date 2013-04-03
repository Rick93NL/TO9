using UnityEngine;
using System.Collections;
using System; // String

using Quiz;

public class quiz : MonoBehaviour {
	double time_left;
	
	QuizMaster quiz_master;
	Question current_question;
	
	// Use this for initialization
	void Start () {
		quiz_master = new QuizMaster(@"C:\writetext.txt");
		display_next_question();
	}
	
	void display_next_question() {
		current_question = quiz_master.next_question();
		
		guiText.text = current_question.question + "\n";
		foreach(string option in current_question.options) {
			guiText.text += option + "\n";	
		}
		
		guiText.text += current_question.answer;
	}
	
	// Detects keys pressed and prints their keycode
    void OnGUI() {
        Event e = Event.current;
        if (e.isKey && 
			e.type == EventType.KeyDown &&
			e.keyCode >= KeyCode.Alpha0 && 
			e.keyCode <= KeyCode.Alpha9) {
			
            Debug.Log("Is correct? " + (((int)e.keyCode - (int)KeyCode.Alpha0) == current_question.answer ? "yes" : "no"));
			display_next_question();
        }
    }
}
