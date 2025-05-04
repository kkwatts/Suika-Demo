using UnityEngine;

public class QueueManager : MonoBehaviour {
    private GameObject[] display;

    public GameObject[] queue;
    public Sprite[] sprites;
    public GameObject fruitDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        display = new GameObject[4];

        for (int i = 0; i < 4; i++) {
            display[i] = Instantiate(fruitDisplay, new Vector2(4.86f + (i * 1.07f), 3.2f), Quaternion.identity);
        }
    }

    public void UpdateDisplay() {
        for (int i = 0; i < 4; i++) {
            display[i].GetComponent<SpriteRenderer>().sprite = sprites[queue[i].GetComponent<FruitBehavior>().fruitIndex];
                //queue[i].GetComponent<SpriteRenderer>().sprite;
                //sprites[queue[i].GetComponent<FruitBehavior>().fruitIndex];
        }
    }
}
