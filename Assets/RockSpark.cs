using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RockSpark : MonoBehaviour
{

    public AudioClip clip;
    public ParticleSystem sparks;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<RockSpark>() == null)
        {
            return;
        }

        if (!collision.gameObject.GetComponent<OVRGrabbable>().isGrabbed)
        {
            return;
        }

        OVRInput.SetControllerVibration(.05f, 1, OVRInput.Controller.RTouch);
        OVRInput.SetControllerVibration(.05f, 1, OVRInput.Controller.LTouch);
        Task.Delay(100).ContinueWith((task) => {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        });
        AudioSource.PlayClipAtPoint(clip, collision.transform.position, 0.01f);
        Vector3 pt = (collision.gameObject.transform.position + gameObject.transform.position) / 2;
        for (var i = 0; i < 5; i++)
        {
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = Color.white;
            emitParams.startSize = 0.005f;
            emitParams.position = pt;
            emitParams.velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * .3f;
            emitParams.startLifetime = .2f;
            sparks.Emit(emitParams, 1);
        }
    }
}
