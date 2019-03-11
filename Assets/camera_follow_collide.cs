using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow_collide : MonoBehaviour
{
    public GameObject cam;
    public GameObject rig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);
        rig.transform.position = new Vector3(rig.transform.position.x, transform.position.y, rig.transform.position.z);
    }
}
