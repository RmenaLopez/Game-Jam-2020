using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Collider2D innerCircle;
    [SerializeField]
    private GameObject outterCircle;

    private float spawnTime = 60f / 100f;
    [SerializeField]
    private List<GameObject> outterCircleList;

    private GameManager gameManager;

    private Rigidbody2D rigibody2D;
    private Vector3 moveDir;

    [SerializeField]
    private float move_speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rigibody2D = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnBeat", 0, spawnTime * 2);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            if (IsHitAttemptSuccessful())
            {
                gameManager.GainPoints();

            }
            else
            {
                gameManager.LosePoints();
            }
            SetMoveSpeed(gameManager.GetScore());
        }

        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }

        moveDir = new Vector3(moveX, moveY).normalized;
    }


    private void SpawnBeat()
    {
        CheckOutterCircleList();
        GameObject newOutterCircle = Instantiate(outterCircle, transform.position, transform.rotation);
        newOutterCircle.transform.SetParent(transform);
        newOutterCircle.transform.localScale = new Vector3(2.0f, 2.0f, 0.0f);
        outterCircleList.Add(newOutterCircle);
    }

    private void CheckOutterCircleList()
    {
        if (outterCircleList.Count > 0)
        {
            if (!outterCircleList[0])
            {
                outterCircleList.RemoveAt(0);
            }
        }
    }

    private bool IsHitAttemptSuccessful()
    {
        CheckOutterCircleList();
        if (outterCircleList.Count > 0)
        {
            bool res = outterCircleList[0].GetComponent<OutterCircleController>().IsInputSuccessful();
            Destroy(outterCircleList[0].gameObject);
            return res;
        }
        return false;
    }

    private void FixedUpdate()
    {
        rigibody2D.velocity = moveDir * move_speed;
    }

    private void SetMoveSpeed(float score)
    {
        float percentage = (1 * score) / 50;
        float acceleration = Mathf.Lerp(0, 8, percentage);
        this.move_speed = 2f + acceleration;
    }
}
