using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraController : MonoBehaviour
{
    public GameObject Player;

    private GameObject cam;

    void Move()
    {
        Vector3 position = Player.transform.position;

        if (position.x < 0)
        {
            position.x = 0;
        }

        position.y = 0;
        position.z = -10;

        this.cam.transform.position = position;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.cam = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
