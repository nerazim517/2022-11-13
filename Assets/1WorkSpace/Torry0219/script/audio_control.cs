using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_control : MonoBehaviour
{
    public AudioClip bgm1;
    public AudioClip bgm2;
    public AudioClip SE;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer.volume = 0.5f;
        audioPlayer.clip = bgm2;
        audioPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSE(){
        audioPlayer.PlayOneShot(SE);
    }
}   
