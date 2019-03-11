using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hands_portal: MonoBehaviour
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
        if (other.GetComponent<MeshFilter>() == null)
        {
            return;
        }

        float dist = (other.transform.position - transform.position).magnitude;
        if (rtouch)
            OVRInput.SetControllerVibration(1f, 0.5f - dist, OVRInput.Controller.RTouch);
        if (ltouch)
            OVRInput.SetControllerVibration(1f, 0.5f - dist, OVRInput.Controller.LTouch);
        if (dist < .1)
        {
          SceneManager.LoadScene("Scene2");
        }
    }
    private void OnTriggerLeave(Collider other)
    {
        if (rtouch)
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        if (ltouch)
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }
}
