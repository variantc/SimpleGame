using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public ReferenceController rc;

    public bool ballShot = false;
    bool returned = true;

    Ball ball;

    float returnSpeed = 10f;

    Vector3 startPos;

    private void Start()
    {
        startPos = this.transform.position;
    }

    public void Shot(Ball ball)
    {
        this.ball = ball;
        ballShot = true;
        returned = false;
    }

    private void Update()
    {
        if (ballShot == true)
        {
            if (ball != null)
            {
                this.transform.position = startPos + new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z) * 0.80f;
            }
        }
        else
        {
            if (returned == false)
                ReturnCamera();
        }
    }

    public void ShotLanded()
    {
        ballShot = false;
    }

    public void ReturnCamera()
    {
        this.transform.position -= (this.transform.position - startPos).normalized * Time.deltaTime * returnSpeed;
        returnSpeed += Time.deltaTime * 50f;

        if ((this.transform.position - startPos).magnitude <= 2.5f)
        {
            returned = true;
            this.transform.position = startPos;
            returnSpeed = 20f;
        }
    }
}