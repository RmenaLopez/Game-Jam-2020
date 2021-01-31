using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float score=0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (score != 50 )
            score += 1;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (score != 0)
            score -= 1;
        }
    }
}
