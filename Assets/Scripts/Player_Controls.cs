using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    [SerializeField]
    private float move_speed = 2f;

    private Rigidbody2D rigibody2D;
    private Vector3 moveDir;

    private void Awake()
    {
        rigibody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

    private void FixedUpdate()
    {
        rigibody2D.velocity = moveDir * move_speed;
    }

    public void SetMoveSpeed(float score)
    {
        float percentage = (1 * score) / 50;
        float acceleration = Mathf.Lerp(0, 8, percentage);
        this.move_speed = 2f + acceleration;
    }
}
