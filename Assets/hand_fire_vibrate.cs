using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand_fire_vibrate : MonoBehaviour
{

    public bool rtouch;
    public bool ltouch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<marshmellow_roaster>() != null)
        {
            float dist = (other.transform.position - transform.position).magnitude;
            if (rtouch)
                OVRInput.SetControllerVibration(.05f, .5f-dist, OVRInput.Controller.RTouch);
            if (ltouch)
                OVRInput.SetControllerVibration(.05f, .5f-dist, OVRInput.Controller.LTouch);
        }
    }
    private void OnTriggerLeave(Collider other)
    {
        if (other.GetComponent<marshmellow_roaster>() != null)
        {
            if (rtouch)
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            if (ltouch)
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        }
    }
}
