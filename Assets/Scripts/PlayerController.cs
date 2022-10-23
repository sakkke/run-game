using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static float JUMP_POWER = 7.5f;
    static float MAX_SPEED = 4f;
    static float SPEED_POWER = 20f;

    public GameObject GameOverPanel;

    private bool jumped = true;
    private Rigidbody2D rb;

    void FixedUpdate()
    {
        this.JumpEvent();
        this.Move();
    }

    float GetJumpPower()
    {
        var result = PlayerController.JUMP_POWER;
        return result;
    }

    float GetSpeedPower()
    {
        var result = (PlayerController.MAX_SPEED - this.rb.velocity.x) * PlayerController.SPEED_POWER;
        return result;
    }

    void JumpEvent()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (this.jumped)
            {
                Debug.Log("Could not jump.");
                return;
            }

            this.rb.AddForce(Vector2.up * this.GetJumpPower(), ForceMode2D.Impulse);
            this.jumped = true;
            Debug.Log("Jumped.");
        }
    }

    void Move()
    {
        this.rb.AddForce(Vector2.right * this.GetSpeedPower());
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Barrier")
        {
            Time.timeScale = 0f;
            GameOverPanel.SetActive(true);
            Debug.Log("Game over!");
        }
        else if (collision2D.gameObject.tag == "Floor")
        {
            this.jumped = false;
            Debug.Log("Recovered jump limit.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
