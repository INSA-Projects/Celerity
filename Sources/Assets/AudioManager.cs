using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public GameObject[] musics; //contains the musics
	public int nbOfMusics;		//number of musics

	/**
	 * change the current ambient music
	 * @num : the music number
	 * */
	public void changeMusic(int num){
		//stops all the musics
		for (int i=0;i<nbOfMusics;i++){
			musics[i].audio.Stop();
		}
		// starts the music
		musics[num].audio.Play();
	}
}