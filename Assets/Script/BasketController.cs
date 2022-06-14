using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BasketController : MonoBehaviour
{
    public static BasketController instance;
    public GameObject basketPart;


    private void Awake() //Singleton Pattern.
    {
        if (instance == null)
        {
            instance = this;
        }

    }


    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            GameObject partClone = Instantiate(basketPart, transform.position, transform.rotation);
            partClone.transform.SetParent(transform);
            Destroy(partClone, 2f);
            transform.GetComponent<BoxCollider>().isTrigger = false; // for two point
            SoundController.instance.playnetSound();
            GameManager.Instance.gamestate = GameManager.GameState.Next; // Next Level
        }
    }
}
