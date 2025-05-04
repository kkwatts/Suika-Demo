using UnityEngine;

public class BackgroundManager : MonoBehaviour {
    public GameObject bg;
    public float speed;

    private GameObject[] bgObj;
    private int size;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        size = 3;
        bgObj = new GameObject[size];

        for (int i = 0; i < size; i++) {
            bgObj[i] = Instantiate(bg, new Vector2(-10.24f + (i * 5.12f), -10.24f + (i * 5.12f)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < size; i++) {
            bgObj[i].transform.position = new Vector3(bgObj[i].transform.position.x + speed, bgObj[i].transform.position.y + speed, 1);
            if (!(bgObj[i].transform.position.x <= 5.12f)) {
                bgObj[i].transform.position = new Vector3(-10.24f, -10.24f, 1);
            }
        }
    }
}
