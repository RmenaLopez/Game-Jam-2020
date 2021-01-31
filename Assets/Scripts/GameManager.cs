using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    Light_Control lightControls;
    private int score;
    const int maxScore = 50;

    [SerializeField]
    private List<GameObject> collectibles;

    private PathManager pathManager;

    private MusicManager musicManager;

    public Animator animator;
    public float transitionDelayTime = 1.0f;
    void Start()
    {
        for (int i = 1; i < collectibles.Count; i++)
        {
            collectibles[i].SetActive(false);
        }

        pathManager = GameObject.FindGameObjectWithTag("PathManager").GetComponent<PathManager>();
        pathManager.SetEnd(collectibles[0].GetComponent<Rigidbody2D>());
        //pathManager.EnableSeeker();

        score = 0;
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        musicManager.SetMaxScore(maxScore);
        lightControls = GameObject.FindGameObjectWithTag("PlayerLight").GetComponent<Light_Control>();
        lightControls.SetRadiusRange(0f);

        animator = GameObject.Find("Transition").GetComponent<Animator>();

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
        if (score >= 15)
        {
            pathManager.EnableSeeker();
        }
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

    public void UpdatePathManagerEnd()
    {
        if (collectibles.Count > 0)
        {
            collectibles.RemoveAt(0);
        }

        if (collectibles.Count <= 0)
        {
            pathManager.DisableSeeker();
            LoadLevel();
        }
        else 
        {
            collectibles[0].SetActive(true);
            pathManager.SetEnd(collectibles[0].GetComponent<Rigidbody2D>());
        }
    }

    public void LoadLevel()
    {
        StartCoroutine(DelayLoadLevel(0));
    }

    IEnumerator DelayLoadLevel(int index)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene(index);
    }
}
