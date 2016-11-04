using UnityEngine;
using System.Collections;

public class WorldPlayAudio : MonoBehaviour {

  public AudioClip[] clips;

  private AudioSource audioS;

	void Start () {
    audioS = GetComponent<AudioSource>();
	}

  public void play() {
    audioS.PlayOneShot(clips[Random.Range(0,clips.Length)]);
  }
}
