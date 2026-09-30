using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class ScoreboardController : Singleton<ScoreboardController>
{
    public TMP_Text textMesh;

    int score;

    void Start()
    {
        score = 0;
        Assert.IsNotNull(textMesh);
    }

    public void AddScore(int dScore)
    {
        score += dScore;
    }

    void Update()
    {
        textMesh.text = score.ToString();
    }

    public void SetScore(int score)
    {
        this.score = score;
    }
}
