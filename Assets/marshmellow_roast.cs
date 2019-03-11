using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class marshmellow_roast : MonoBehaviour
{

    float roastedness = 0;
    public bool previouslyRoasted = false;
    public bool previouslyBurned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        marshmellow_roaster comp = collider.gameObject.GetComponent<marshmellow_roaster>();
        if (comp == null)
        {
            return;
        }
        float dist = (collider.gameObject.transform.position - gameObject.transform.position).magnitude;
        float scale = .33f;
        if (dist < .5) roastedness += Time.deltaTime * scale;
        if (dist < .4) roastedness += Time.deltaTime * scale;
        if (dist < .3) roastedness += Time.deltaTime*2 * scale;
        if (dist < .2) roastedness += Time.deltaTime * 3 * scale;
        if (dist < .1) roastedness += Time.deltaTime * 10 * scale;

        float roastPer = Mathf.Min(roastedness / 20.0f, 1);
        float burntPer = 0;
        if (roastedness > 20)
        {
            burntPer = Mathf.Min((roastedness - 20) / 20, 1);
        }
        if (burntPer > 0)
        {
            Vector3 black = new Vector3(0,0,0);
            Vector3 brown = new Vector3(150/255f, 75/255f, 0);
            Vector3 lerp = brown * (1 - burntPer) + black * burntPer;
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(lerp.x, lerp.y, lerp.z);

            if (burntPer > .5f && !previouslyBurned)
            {
                previouslyBurned = true;
                UnityWebRequest www = UnityWebRequest.Get("http://192.168.1.13/burn");
                www.SendWebRequest();
            }

        }
        else
        {

            if (roastPer > .5f && !previouslyRoasted)
            {
                previouslyRoasted = true;
                UnityWebRequest www = UnityWebRequest.Get("http://192.168.1.13/golden");
                www.SendWebRequest();
            }
            Vector3 white = new Vector3(255/255f, 255/255f, 255/255f);
            Vector3 brown = new Vector3(150/255f, 75/255f, 0);
            Vector3 lerp = white * (1 - roastPer) + brown * roastPer;
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(lerp.x, lerp.y, lerp.z);
        }

    }
}
