using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerNivel : MonoBehaviour {

	[SerializeField]
	private AudioSource MusicLevel;

	// Use this for initialization
	void Start () {
		

		StartCoroutine(Fadein(MusicLevel, 1.5f, 0.4f));

	}
	// Update is called once per frame
	void Update () {
		
	}


	public IEnumerator FadeOut(AudioSource a,float Fadetime) {
		float StartVolume = a.volume;

		while (a.volume > 0) {
			a.volume -= StartVolume * Time.deltaTime / Fadetime;
			yield return null;
		}

		a.Stop();
		a.volume = StartVolume;
	}
	public IEnumerator Fadein(AudioSource a, float Fadetime,float volumenMax)
	{
		float StartVolume = volumenMax;
		a.Play();

		while (a.volume < volumenMax)
		{
			a.volume += StartVolume * Time.deltaTime / Fadetime;
			yield return null;
		}

		a.volume = StartVolume;
	}
}
