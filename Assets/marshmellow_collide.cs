using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marshmellow_collide : MonoBehaviour
{
    public int marshCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (marshCount >= 4)
        {
            return;
        }
        TypeComponent comp = collision.gameObject.GetComponent<TypeComponent>();
        if (comp == null || comp.type != "marsh")
        {
            return;
        }
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 pointRel = gameObject.transform.InverseTransformPoint(contact.point);
            if (pointRel.y > 1.2 && comp.status != "onstick")
            {
                marshCount++;
                comp.status = "onstick";
                comp.parent = gameObject;
                //New marshmellow
                Vector3 marshRel = new Vector3(-0.04977f, 1.05f + marshCount * 0.05f, 0.441275f);
                comp.slide = gameObject.transform.InverseTransformPoint(collision.rigidbody.transform.position);

                comp.slide_target = marshRel;
                collision.gameObject.transform.position = gameObject.transform.TransformPoint(comp.slide);
                collision.gameObject.transform.SetParent(transform);
                collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                collision.gameObject.GetComponent<MeshCollider>().isTrigger = true;
            }

        }
    }
}
