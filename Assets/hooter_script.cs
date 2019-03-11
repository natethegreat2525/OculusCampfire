using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hooter_script : MonoBehaviour
{
    public AudioSource audioData;
    float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = Random.Range(5, 200);
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;

        if (waitTime < 0)
        {
            waitTime = Random.Range(5, 200);
            float ang = Random.Range(0, 360);
            float range = Random.Range(5, 10);
            audioData.transform.position = new Vector3(Mathf.Cos(ang / (2*Mathf.PI)) * range, 0, Mathf.Sin(ang / (2*Mathf.PI))*range);
            audioData.Play(0);
        }
    }
}
