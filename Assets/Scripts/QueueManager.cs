using UnityEngine;

public class QueueManager : MonoBehaviour {
    public Sprite[] queueSprites;
    public int[] queuedFruits;

    private SpriteRenderer[] queueItems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        queueItems = new SpriteRenderer[4];
        queuedFruits = new int[4];

        for (int i = 0; i < transform.childCount; i++) {
            queueItems[i] = transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
        }

        for (int i = 0; i < 4; i++) {
            queuedFruits[i] = Random.Range(0, 4);
        }
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < 4; i++) {
            queueItems[i].sprite = queueSprites[queuedFruits[i]];
        }
    }

    public void UpdateQueue() {
        for (int i = 0; i < 4; i++) {
            if (i != 3) {
                queuedFruits[i] = queuedFruits[i + 1];
            }
            else {
                queuedFruits[3] = Random.Range(0, 4);
            }
        }
    }
}
