using UnityEngine;
using System.Collections;

// dialogue manager, to launch a dialogue when it's needed
public class DialogueManager : MonoBehaviour {
	public AudioSource intro;
	public AudioSource sablierInPlace;
	public AudioSource teleportation;
	public static AudioSource[] dialogues = new AudioSource[3];

	/**
 	* change the current dialogue
 	* @num : the dialogue number
 	* */
	public static void changeDialogue(int num){
		//stops all dialogues
		for (int i=0;i<dialogues.Length;i++){
			dialogues[i].Stop();
		}
		// starts the good dialogue
		dialogues[num].Play();
	}

	void Start () {
		DialogueManager.dialogues[0] = intro;
		DialogueManager.dialogues[1] = sablierInPlace;
		DialogueManager.dialogues[2] = teleportation;
		DialogueManager.changeDialogue(0);

	}

}