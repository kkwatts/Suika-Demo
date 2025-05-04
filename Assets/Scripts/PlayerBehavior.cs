using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    // Movement input
    public float speed;

    // Fruit movement
    public GameObject fruit;

    // Instantiate fruits
    private GameObject currentFruit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // Movement input
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }

        // Instantiate fruits
        if (currentFruit == null) {
            currentFruit = Instantiate(fruit, transform.position, Quaternion.identity);
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

            if (Input.GetKeyDown(KeyCode.Space)) {
                currentFruit.GetComponent<CircleCollider2D>().enabled = true;
                currentFruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
                currentFruit = null;
            }
        }
    }
}
