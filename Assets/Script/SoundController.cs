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

    bool InGame(bool InGame)
    {
        GameManager.Instance.gamestate = GameManager.GameState.InGame; // Fall the ball, show game over panel.
        return(InGame);
    }

    public void playBounceSound()
    {
        if (GameManager.Instance.gamestate == GameManager.GameState.InGame)
            audioSource.PlayOneShot(bounceSound);
    }
    public void playnetSound()
    {
        if (GameManager.Instance.gamestate==GameManager.GameState.InGame)
            audioSource.PlayOneShot(netSound);
    }



}
