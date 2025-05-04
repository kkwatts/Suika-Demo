using UnityEngine;
// Points system
using TMPro;

public class PlayerBehavior : MonoBehaviour {
    // Movement input
    public float speed;

    // Fruit movement
    //public GameObject fruit;

    // Randomize fruits (replaces fruit movement code)
    public GameObject[] fruits;

    // Display game over text
    public GameObject loseText;

    // Points system
    public TextMeshProUGUI pointsText;

    // Instantiate fruits
    private GameObject currentFruit;

    // Player boundaries
    private float minX;
    private float maxX;

    // Adjust game over
    private bool canSpawn;

    // Points system
    private int points;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        minX = -3.5f;
        maxX = 3.5f;

        // Display game over text
        loseText.SetActive(false);

        // Adjust game over
        canSpawn = true;

        // Points system
        points = 0;
    }

    // Update is called once per frame
    void Update() {
        // Movement input
        /*
         * if (Input.GetKey(KeyCode.LeftArrow)) {
         *     transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
         * }
         * if (Input.GetKey(KeyCode.RightArrow)) {
         *     transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
         * }
         */

        // Player boundaries (replaces movement input code)
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
            if (transform.position.x < minX) {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            if (transform.position.x > maxX) {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            }
        }

        // Instantiate fruits
        /*
         * if (currentFruit == null) {
         *     currentFruit = Instantiate(fruit, transform.position, Quaternion.identity);
         * }
         */

        // Randomize fruits
        if (currentFruit == null) {
            currentFruit = Instantiate(fruits[Random.Range(0, fruits.Length)], transform.position, Quaternion.identity);
        }

        // Fruit movement
        /*
         * if (fruit != null) {
         *     Vector3 fruitOffset = new Vector3(0f, -1f, 0f);
         *     fruit.transform.position = transform.position + fruitOffset;
         * }
         * 
         * if (Input.GetKeyDown(KeyCode.Space)) {
         *     fruit = null;
         * }
         */

        // Fruit movement bug fixes (replaces fruit movement code)
        if (currentFruit != null) {
            Vector3 fruitOffset = new Vector3(0f, -1f, 0f);
            currentFruit.transform.position = transform.position + fruitOffset;
            currentFruit.GetComponent<CircleCollider2D>().enabled = false;
            currentFruit.GetComponent<Rigidbody2D>().gravityScale = 0f;

            // Adjust game over: add "&& canSpawn"
            if (Input.GetKeyDown(KeyCode.Space) && canSpawn) {
                currentFruit.GetComponent<CircleCollider2D>().enabled = true;
                currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
                currentFruit = null;
            }
        }

        // Points system
        pointsText.SetText("Points: " + points);
    }

    // Display game over text
    public void GameOver() {
        loseText.SetActive(true);
        // Adjust game over: add "canSpawn = false"
        canSpawn = false;
    }

    // Points system
    public void AddPoints(int num) {
        points += num;
    }
}
