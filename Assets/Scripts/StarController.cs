using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    GameController Controller;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            this.Controller.IncreaseScore(10);
            Debug.Log("Score up by a star!");
            Destroy(this.gameObject);
            Debug.Log("Destroyed a star.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Controller = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
