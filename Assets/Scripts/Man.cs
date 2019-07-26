using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour {

    float counter = 0f;

    void Update () {
		if (this.transform.rotation.eulerAngles.x > 10f || this.transform.rotation.eulerAngles.x < -10f 
            || this.transform.rotation.eulerAngles.z > 10f || this.transform.rotation.eulerAngles.z < -10f)
        {
            this.transform.SetParent(null);
            counter += Time.deltaTime;
            if (counter >= 5f)
            {
                Destroy(this.gameObject);
            }
        }
	}
}
