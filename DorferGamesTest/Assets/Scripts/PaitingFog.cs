using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaitingFog : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<BaseFollow>()!=null)
        {
            Renderer rend = collider.gameObject.GetComponent<Renderer>();
            if(rend!=null)
                rend.material = this.gameObject.GetComponent<Renderer>().material;
        }
    }
}
