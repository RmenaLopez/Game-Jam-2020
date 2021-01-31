using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    const int maxScore = 50;

    private MusicManager musicManager;
    void Start()
    {
        score = 0;
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        musicManager.SetMaxScore(maxScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainPoints() 
    {
        score += 1;
        score = Mathf.Clamp(score, 0, maxScore);
        musicManager.UpdateScore(score);
        Debug.Log("score: " + score);

    }

    public void LosePoints()
    {
        score -= 2;
        score = Mathf.Clamp(score, 0, maxScore);
        musicManager.UpdateScore(score);
        Debug.Log("score: " + score);

    }

    public int GetScore()
    {
        return score;
    }

    public int GetMaxScore()
    {
        return maxScore;
    }
}
