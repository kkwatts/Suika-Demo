using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public GameObject[] fruits;
    public GameObject[] queue;
    public float minX;
    public float maxX;
    public float speed;
    public bool hasFruit;

    private GameObject queueDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        queueDisplay = GameObject.FindGameObjectWithTag("Queue");
        queue = new GameObject[4];

        hasFruit = false;
        for (int i = 0; i < 4; i++) {
            queue[i] = fruits[Random.Range(0, 4)];
        }
    }

    // Update is called once per frame
    void Update() {
        queueDisplay.GetComponent<QueueManager>().queue = queue;
        queueDisplay.GetComponent<QueueManager>().UpdateDisplay();

        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }

        if (transform.position.x < minX) {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > maxX) {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }

        if (!hasFruit) {
            GetFromQueue(queue, new Vector2(transform.position.x, 3.5f), Quaternion.identity);
            hasFruit = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            hasFruit = false;
        }
    }

    private void GetFromQueue(GameObject[] queue, Vector2 position, Quaternion rotation) {
        GameObject nextFruit = queue[0];
        for (int i = 0; i < 3; i++) {
            queue[i] = queue[i + 1];
        }
        queue[3] = fruits[Random.Range(0, 4)];
        Instantiate(nextFruit, position, rotation);
    }
}
