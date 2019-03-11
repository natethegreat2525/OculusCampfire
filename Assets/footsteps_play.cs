using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps_play : MonoBehaviour
{
    public AudioSource audioData;
    public Vector3 direction;
    float waitTime;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = Random.Range(120, 600);
        startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        audioData.spatialize = true;
        audioData.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        audioData.transform.position += direction * Time.deltaTime;
        waitTime -= Time.deltaTime;
        if (waitTime < 0)
        {
            waitTime = Random.Range(120, 600);
            audioData.transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
        }
    }
}
