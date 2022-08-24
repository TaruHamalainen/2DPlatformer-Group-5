using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    public AudioSource source;
    public AudioClip spiderDie;
    public AudioClip fireFlyDie;
    public AudioClip jumpPad;
    public AudioClip shootingEnemy;
    public AudioClip gameOver;
    public AudioClip playerHurt;
    public AudioClip heal;
    public AudioClip score;
    public AudioClip rope;


    private void Awake()
    {
        audioManager = this;
    }
    public void PlaySound(AudioClip aud)
    {
        source.PlayOneShot(aud);
    }

}
