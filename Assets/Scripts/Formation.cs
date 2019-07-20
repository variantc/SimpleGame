using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour {

    float speed = 0f;

    private void FixedUpdate()
    {
        this.transform.position -= new Vector3(0f, 0f, Time.deltaTime * speed);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
