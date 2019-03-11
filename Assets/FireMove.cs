using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour
{

    Vector3 stPos;
    Vector3 targPos;
    float targBrightness;
    float timer = 0;
    public float maxTimer = .5f;
    public float scale = .1f;

    // Start is called before the first frame update
    void Start()
    {
        stPos = gameObject.transform.position;
        this.newTarget();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= maxTimer)
        {
            this.newTarget();
            timer = 0;
        }

        gameObject.transform.position += (targPos - gameObject.transform.position) * 0.1f;
        gameObject.GetComponent<Light>().intensity += (targBrightness - gameObject.GetComponent<Light>().intensity) * 0.1f;
    }

    void newTarget()
    {
        targPos.x = stPos.x + Random.Range(-scale, scale);
        targPos.y = stPos.y + Random.Range(-scale, scale);
        targPos.z = stPos.z + Random.Range(-scale, scale);
        targBrightness = Random.Range(.1f, 1);
    }
}
