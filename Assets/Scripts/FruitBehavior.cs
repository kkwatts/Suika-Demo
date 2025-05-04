using UnityEngine;
// Game over
using System.Collections;

public class FruitBehavior : MonoBehaviour {
    // Merge behavior
    public int fruitType;
    public GameObject[] fruits;

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

    // Merge behavior
    private void OnCollisionEnter2D(Collision2D col) { 
        if (col.gameObject.CompareTag("Fruit")) {
            GameObject otherFruit = col.gameObject;
            if (fruitType == otherFruit.GetComponent<FruitBehavior>().fruitType && fruitType != 10) {
                if (transform.position.x > otherFruit.transform.position.x || (transform.position.y > otherFruit.transform.position.y && transform.position.x == otherFruit.transform.position.x)) {
                    GameObject newFruit = Instantiate(fruits[fruitType], Vector3.Lerp(transform.position, otherFruit.transform.position, 0.5f), Quaternion.identity);
                    newFruit.GetComponent<CircleCollider2D>().enabled = true;
                    newFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;

                    // Points system
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().AddPoints(fruitType);

                    Destroy(otherFruit);
                    Destroy(gameObject);
                }
            }
        }
    }
}
