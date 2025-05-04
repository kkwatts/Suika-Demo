using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
    // Movement input
    public float speed;

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
    }
}
