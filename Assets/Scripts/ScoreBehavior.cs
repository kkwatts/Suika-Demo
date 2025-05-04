using UnityEngine;
using TMPro;

public class ScoreBehavior : MonoBehaviour {
    private TextMeshProUGUI tmp;

    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        tmp = GetComponent<TextMeshProUGUI>();

        score = 0;
    }

    // Update is called once per frame
    void Update() {
        string text = string.Format("Score: {00}", score);
        tmp.SetText(text);
    }

    public void AddPoints(int points) {
        score += points;
    }
}
