using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketController : MonoBehaviour
{
    public GameObject basketPart;
    public int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject partClone = Instantiate(basketPart, transform.position, transform.rotation);
            partClone.transform.SetParent(transform);
            Destroy(partClone, 2f);
            score += 1;
        }
    }
}
