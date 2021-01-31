using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutterCircleController : MonoBehaviour
{
    [SerializeField]
    private Collider2D beat;

    private bool isColliding;
    private float spawnTime = 60f / 100f;

    private GameManager gameManager;
    private PlayerController player;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        isColliding = false;
        ScaleToTarget(new Vector3(0.75f, 0.75f), spawnTime * 2);
    }

    public void ScaleToTarget(Vector3 targetScale, float duration)
    {
        StartCoroutine(ScaleToTargetCoroutine(targetScale, duration));
    }

    private IEnumerator ScaleToTargetCoroutine(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float timer = 0.0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            //smoother step algorithm
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }
        gameManager.LosePoints();
        player.SetMoveSpeed(gameManager.GetScore());
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isColliding = true;
        }
    }

    public bool IsInputSuccessful()
    {
        return isColliding;
    }

}
