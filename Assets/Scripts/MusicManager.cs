using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource track1;
    [SerializeField]
    private AudioSource track2;
    [SerializeField]
    private AudioSource track3;
    [SerializeField]
    private AudioSource track4;
    [SerializeField]
    private AudioSource track5;


    private bool startPlaying = false;
    private bool lockFlag = false;

    private int score;
    private int maxScore;

    private float fadeTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !lockFlag)
        {
            startPlaying = true;
        }

        if (startPlaying && !lockFlag)
        {
            lockFlag = true; 

            track1.Play();
            track1.volume = 0.0f;

            track2.Play();
            track2.volume = 0.0f;

            track3.Play();
            track3.volume = 0.0f;

            track4.Play();
            track4.volume = 0.0f;

            track5.Play();
            track5.volume = 0.0f;
        }

        if (score > 0 && track1.volume <= 0.0f)
        {
            StartCoroutine(StartFade(track1, fadeTime, 1.0f));
        }
        else if (score <= 0 && track1.volume > 0.0f)
        {
            StartCoroutine(StartFade(track1, fadeTime, 0.0f));
        }

        if (score > maxScore/5 && track2.volume <= 0.0f)
        {
            StartCoroutine(StartFade(track2, fadeTime, 1.0f));
        }
        else if (score <= maxScore/5 && track2.volume > 0.0f)
        {
            StartCoroutine(StartFade(track2, fadeTime, 0.0f));
        }

        if (score > 2*(maxScore/5) && track3.volume <= 0.0f)
        {
            StartCoroutine(StartFade(track3, fadeTime, 1.0f));
        }
        else if (score <= 2 * (maxScore / 5) && track3.volume > 0.0f)
        {
            StartCoroutine(StartFade(track3, fadeTime, 0.0f));
        }

        if (score > 3 * (maxScore / 5) && track4.volume <= 0.0f)
        {
            StartCoroutine(StartFade(track4, fadeTime, 1.0f));
        }
        else if (score <= 3 * (maxScore / 5) && track4.volume > 0.0f)
        {
            StartCoroutine(StartFade(track4, fadeTime, 0.0f));
        }

        if (score > 4 * (maxScore / 5) && track5.volume <= 0.0f)
        {
            StartCoroutine(StartFade(track5, fadeTime, 1.0f));
        }
        else if (score <= 4 * (maxScore / 5) && track5.volume > 0.0f)
        {
            StartCoroutine(StartFade(track5, fadeTime, 0.0f));
        }
    }

    public void UpdateScore(int score)
    {
        this.score = score;
    }

    public void SetMaxScore(int maxScore)
    {
        this.maxScore = maxScore;
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 1f;
    }
}
