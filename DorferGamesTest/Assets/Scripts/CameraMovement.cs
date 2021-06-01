using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform toFollow;
    float diffZ;
    // Start is called before the first frame update
    void Start()
    {
        diffZ = transform.position.z - toFollow.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, toFollow.position.z + diffZ);
    }
}
