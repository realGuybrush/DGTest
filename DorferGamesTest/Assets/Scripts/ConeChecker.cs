using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeChecker : MonoBehaviour
{
    public List<Collider> coneHits = new List<Collider>();
    public void OnTriggerEnter(Collider collider)
    {
        coneHits.Add(collider);
    }
    public void OnTriggerExit(Collider collider)
    {
        coneHits.Remove(collider);
    }
}
