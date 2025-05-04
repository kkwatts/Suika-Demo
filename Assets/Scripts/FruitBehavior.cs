using UnityEngine;
// Game over
using System.Collections;

public class FruitBehavior : MonoBehaviour {
    // Game over
    private float timeLimit;
    private float gameOverTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        // Game over
        timeLimit = 2f;
        gameOverTimer = 0f;
    }

    // Update is called once per frame
    void Update() {
        
    }

    // Game over
    private IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds);
        if (gameOverTimer >= timeLimit) {
            Debug.Log("Game over");
            DisplayGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D col) { 
        if (col.gameObject.CompareTag("Game Over")) {
            gameOverTimer += Time.deltaTime;
            StartCoroutine(Wait(timeLimit));
        }
    }

    private void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.CompareTag("Game Over")) {
            gameOverTimer += Time.deltaTime;
        }
    }

    // Display game over text
    private void DisplayGameOver() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().GameOver();
    }
}
