using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    Light_Control lightControls;
    private int score;
    const int maxScore = 50;

    private MusicManager musicManager;
    void Start()
    {
        score = 0;
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        musicManager.SetMaxScore(maxScore);
        lightControls = GameObject.FindGameObjectWithTag("PlayerLight").GetComponent<Light_Control>();
        lightControls.SetRadiusRange(0f);
    }

    // Update is called once per frame
    void Update()
    {
        float fscore = (float)this.score;
        lightControls.SetRadiusRange(fscore);
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
