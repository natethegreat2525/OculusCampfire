using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEyes : MonoBehaviour
{

    float waitTime;
    float blinkTime;
    float closeTime;
    float visTime;
    
    // Start is called before the first frame update
    void Start()
    {
        waitTime = 0;
        blinkTime = 1.5f;
        visTime = 3;
        closeTime = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime < 0)
        {
            if (waitTime + Time.deltaTime >= 0)
            {
                float ang = Random.Range(0, Mathf.PI * 2);
                float rad = Random.Range(16, 20);
                float x = Mathf.Sin(ang) * rad;
                float z = Mathf.Cos(ang) * rad;
                transform.position = new Vector3(x, .4f, z);
            }
            blinkTime -= Time.deltaTime;
            if (blinkTime < 0)
            {
                closeTime -= Time.deltaTime;
                if (closeTime <= 0)
                {
                    closeTime = 0.1f;
                    blinkTime = 100f;
                }
                this.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                this.GetComponent<MeshRenderer>().enabled = true;
            }
            visTime -= Time.deltaTime;
            if (visTime < 0)
            {
                visTime = Random.Range(3, 10);
                blinkTime = visTime / 2;
                waitTime = Random.Range(10, 60);
            }
        } else
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
