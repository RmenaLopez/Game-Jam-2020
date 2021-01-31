using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Score_Manager : MonoBehaviour
{
    private float score = 0;
    Light_Control lightControls;
    Player_Controls playerControls;
    // Update is called once per frame

    private void Start()
    {
        lightControls = GameObject.FindGameObjectWithTag("PlayerLight").GetComponent<Light_Control>();
        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controls>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (this.score != 50)
            {
                this.score += 1;
            }
            lightControls.SetRadiusRange(this.score);
            playerControls.SetMoveSpeed(this.score);
            Debug.Log("SCORE: " + this.score);

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (this.score != 0)
            {
                this.score -= 1;
            }
            lightControls.SetRadiusRange(this.score);
            playerControls.SetMoveSpeed(this.score);
            Debug.Log("SCORE: " + this.score);
        }

    }
}
