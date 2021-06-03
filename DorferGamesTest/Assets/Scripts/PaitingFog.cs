using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaitingFog : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<BaseFollow>()!=null)
        {
            collider.gameObject.GetComponent<Renderer>().material = this.gameObject.GetComponent<Renderer>().material;
        }
    }
}
