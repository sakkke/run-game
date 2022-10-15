using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        Debug.Log("Destroyed an off-screen floor.");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
