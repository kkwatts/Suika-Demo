using UnityEngine;

public class BackgroundManager : MonoBehaviour {
    public GameObject background;
    public float speed;

    private GameObject[] bgObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        bgObj = new GameObject[3];

        for (int i = 0; i < 3; i++) {
            bgObj[i] = Instantiate(background, new Vector2(-10.24f + (i * 5.12f), -10.24f + (i * 5.12f)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < 3; i++) {
            bgObj[i].transform.position = new Vector3(bgObj[i].transform.position.x + speed, bgObj[i].transform.position.y + speed, 10);
            if (bgObj[i].transform.position.x > 5.12f) {
                bgObj[i].transform.position = new Vector3(-10.24f, -10.24f, 10);
            }
        }
    }
}
