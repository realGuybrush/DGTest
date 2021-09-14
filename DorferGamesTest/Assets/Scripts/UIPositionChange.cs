using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPositionChange : MonoBehaviour
{
    Vector3 landscapePos;
    public Vector3 portraitPosShift;
    // Start is called before the first frame update
    void Start()
    {
        landscapePos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Adjust(bool landscape)
    {
        if (landscape)
            this.gameObject.transform.position = landscapePos;
        else
            this.gameObject.transform.position += portraitPosShift;
    }
}
