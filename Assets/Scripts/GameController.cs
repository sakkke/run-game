using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject Barrier;
    public GameObject Floor;
    public GameObject Player;
    public TextMeshProUGUI ScoreValue;

    private float deltaTime = 0f;
    private int elapsedTime = 0;
    private int score = 0;
    private bool scoreChanged = false;
    private float spawnX = 40f;

    void GenerateFloor()
    {
        if (Player.transform.position.x > this.spawnX - 80f)
        {
            GameObject cloned = Instantiate(this.Floor, new Vector2(this.spawnX, -5f), Quaternion.identity);
            cloned.tag = "Floor";
            Debug.Log("Cloned a floor.");
            this.GenerateSprites();
            Debug.Log("Generated sprites.");
            this.spawnX += 40f;
        }
    }

    void GenerateSprites()
    {
        var radius = 15;
        var x = this.spawnX + (float)Random.Range(-radius, radius);
        var cloned = Instantiate(this.Barrier, new Vector2(x, -4f), Quaternion.identity);
        Debug.Log($"A barrier spawned at x={x}.");
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateFields();
        this.UpdateScore();
        this.GenerateFloor();
    }

    void UpdateFields()
    {
        this.deltaTime += Time.deltaTime;

        if (this.deltaTime >= 1f)
        {
            this.deltaTime = 0f;
            this.elapsedTime++;
        }
    }

    void UpdateScore()
    {
        if (this.elapsedTime == 0) {
            return;
        }

        if (this.elapsedTime % 10 == 0)
        {
            if (this.scoreChanged)
            {
                return;
            }

            this.score += 10;
            ScoreValue.text = $"{this.score}";
            this.scoreChanged = true;
            Debug.Log("Increased score.");
        }
        else
        {
            this.scoreChanged = false;
        }
    }
}


