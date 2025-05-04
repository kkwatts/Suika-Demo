using UnityEngine;
using System.Collections;

// Assets from Apps2Amigos on Itch.io: https://apps2amigos.itch.io/fruit-game-free-asset-pack
// Original: https://zrghr.itch.io/froots-and-veggies-culinary-pixels

public class FruitBehavior : MonoBehaviour {
    public int fruitIndex;

    private GameObject controller;
    private GameObject score;
    private Rigidbody2D rb;
    private CircleCollider2D col;

    private bool atCutoff;
    private bool deployed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        controller = GameObject.FindGameObjectWithTag("Controller");
        score = GameObject.FindGameObjectWithTag("Score");
        col = GetComponent<CircleCollider2D>();

        atCutoff = false;

        if (transform.position.y == 3.5f) {
            deployed = false;
        }
        else {
            deployed = true;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && !deployed) {
            deployed = true;
        }

        if (deployed) {
            rb.gravityScale = 1;
            rb.bodyType = RigidbodyType2D.Dynamic;
            col.enabled = true;
        }
        else {
            rb.gravityScale = 0;
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.position = new Vector2(controller.transform.position.x, 3.5f);
            col.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Cutoff" && deployed) {
            atCutoff = true;
            StartCoroutine(Wait(1.5f));
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Cutoff" && deployed) {
            atCutoff = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Fruit" && collision.gameObject.GetComponent<FruitBehavior>().deployed && collision.gameObject.GetComponent<FruitBehavior>().fruitIndex == fruitIndex && fruitIndex < 9) {
            if (transform.position.x > collision.gameObject.transform.position.x || (transform.position.x == collision.gameObject.transform.position.x && transform.position.y > collision.gameObject.transform.position.y)) {
                score.GetComponent<ScoreBehavior>().AddPoints(fruitIndex + 1);
                Instantiate(controller.GetComponent<PlayerController>().fruits[fruitIndex + 1], Vector2.Lerp(transform.position, collision.transform.position, 0.5f), Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }

    public IEnumerator Wait(float seconds) {
        yield return new WaitForSeconds(seconds);
        if (atCutoff) {
            Debug.Log("Game over");
        }
    }
}
