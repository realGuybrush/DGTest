using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform toFollow;
    float diffZ, vertZ;
    float baseX, vertX;
    float fow;
    Camera main;

    // Start is called before the first frame update
    void Start()
    {
        diffZ = transform.position.z - toFollow.position.z;
        baseX = transform.position.x;
        vertX = 0f;
        vertZ = 3f;
        main = this.gameObject.GetComponent<Camera>();
        fow = main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Screen.orientation == ScreenOrientation.LandscapeLeft) || (Screen.orientation == ScreenOrientation.LandscapeLeft))
        {
            transform.position = new Vector3(baseX, transform.position.y, toFollow.position.z + diffZ);
            main.fieldOfView = fow;
        }
        else
        {
            transform.position = new Vector3(vertX, transform.position.y, toFollow.position.z + diffZ + vertZ);
            main.fieldOfView = fow + 50;
        }
    }
}
