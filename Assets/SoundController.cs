using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;

    AudioSource audioSource;
    [SerializeField] AudioClip bounceSound, netSound;
    private void Awake() //Singleton Pattern.
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void playBounceSound()
    {
        audioSource.PlayOneShot(bounceSound);
    }
    public void playnetSound()
    {
        audioSource.PlayOneShot(netSound);
    }



}
