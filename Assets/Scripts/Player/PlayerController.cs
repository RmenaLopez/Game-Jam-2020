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

    // Start is called before the first frame update
    void Start()
    {
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
        }
    }


    private void SpawnBeat()
    {
        CheckOutterCircleList();
        GameObject newOutterCircle = Instantiate(outterCircle, new Vector3(0, 0, 0), Quaternion.identity);
        newOutterCircle.transform.parent = gameObject.transform;
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
}
