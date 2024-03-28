using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundonaWake : MonoBehaviour
{
    // Start is called before the first frame update

    public List<AudioClip> audioClips;

    private AudioSource thisAudioSource;

   void Awake() {
      thisAudioSource = GetComponent<AudioSource>();   
   }
   
   
    void Start()
    {
        AudioClip audioClip = audioClips[Random.Range(0,audioClips.Count)];
        thisAudioSource.PlayOneShot(audioClip);
    }

    // Update is called once per frame
   
}
