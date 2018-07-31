using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGUILogger : MonoBehaviour {

	[SerializeField] int maxLineLength = 40;
	[SerializeField] int maxLines = 60;
	List<string> messages = new List<string>();

	public void PushMessage(string message) {
		messages.Add(message);
	}


	void OnGUI() {

		var guiStyle = new GUIStyle();
		var styleState = new GUIStyleState();
		styleState.textColor = Color.black;
		guiStyle.fontSize = 28;
		guiStyle.normal = styleState;

		var y = 0f;
		int linesAcc = 0;
		for (int i = messages.Count - 1; i >= 0; i -= 1) {
			var message = messages[i];
			for(int j = 0; j < message.Length; j += maxLineLength) {
				if(j + maxLineLength > message.Length) {
					GUI.Label(new Rect(0, y, 2800, 28), message.Substring(j), guiStyle);
				} else {
					GUI.Label(new Rect(0, y, 2800, 28), message.Substring(j, maxLineLength), guiStyle);
				}
				y += 28;
				linesAcc += 1;
				if(linesAcc >= maxLines) {
					return;
				}
			}
		}

	}
}
