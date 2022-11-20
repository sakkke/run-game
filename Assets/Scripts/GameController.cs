using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject Barrier;
    public GameObject Bird;
    public GameObject Floor;
    public GameObject Player;
    public GameObject Star;
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
        this.SpawnBarrier();

        if (Random.value < 1 / 1000) {
            this.SpawnBird();
        }

        if (Random.value < 10 / 100) {
            this.SpawnStar();
        }
    }

    public void IncreaseScore(int n) {
        this.score += n;
        ScoreValue.text = $"{this.score}";
        Debug.Log("Increased score.");
    }

    float RandomX() {
        var radius = 15;
        return this.spawnX + (float)Random.Range(-radius, radius);
    }

    float RandomY() {
        return (float)Random.Range(-1, -3);
    }

    void SpawnBarrier() {
        var x = this.RandomX();
        var cloned = Instantiate(this.Barrier, new Vector2(x, -4f), Quaternion.identity);
        Debug.Log($"A barrier spawned at x={x}.");
    }

    void SpawnBird() {
        var x = this.RandomX();
        var cloned = Instantiate(this.Bird, new Vector2(x, 0f), Quaternion.identity);
        Debug.Log($"A barrier spawned at x={x}.");
    }

    void SpawnStar() {
        var x = this.RandomX();
        var y = this.RandomY();
        var cloned = Instantiate(this.Star, new Vector2(x, y), Quaternion.identity);
        Debug.Log($"A star spawned at x={x}, y={y}.");
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

            this.IncreaseScore(10);
            this.scoreChanged = true;
        }
        else
        {
            this.scoreChanged = false;
        }
    }
}


