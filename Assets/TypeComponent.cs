using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TypeComponent : MonoBehaviour
{
    public string type;
    public string status;

    public Vector3 slide;
    public Vector3 slide_target;
    public GameObject parent;
    public GameObject mouth;
    public AudioClip chew;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((mouth.transform.position - transform.position).magnitude < .2)
        {

            if (status == "onstick")
            {
                parent.GetComponent<marshmellow_collide>().marshCount--;
            }
            if (!GetComponent<marshmellow_roast>().previouslyBurned)
            {
                UnityWebRequest www = UnityWebRequest.Get("http://192.168.1.13/crush");
                www.SendWebRequest();
            }

            AudioSource.PlayClipAtPoint(chew, transform.position);
            GameObject.Destroy(gameObject);

        }
        else
        {
            if (GetComponent<OVRGrabbable>().isGrabbed && status == "onstick")
            {
                GetComponent<MeshCollider>().isTrigger = false;
                status = "";
                parent.GetComponent<marshmellow_collide>().marshCount--;
                parent = null;
            }
            if (status == "onstick")
            {
                if ((slide_target - slide).magnitude > .02)
                {
                    slide += (slide_target - slide).normalized * .01f;
                    gameObject.transform.position = transform.parent.TransformPoint(slide);
                }
            }
        }
    }
}
