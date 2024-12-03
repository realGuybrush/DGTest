using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    
    [SerializeField]
    private Camera thisCamera;
    
    private float offsetFromTargetZ;
    private readonly Vector3 vertOffsetFromTarget = new Vector3(0f, 0f, 3f);

    private void Start()
    {
        offsetFromTargetZ = transform.position.z - target.position.z;
        if (Screen.orientation != ScreenOrientation.LandscapeLeft)
            thisCamera.fieldOfView += 50;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + offsetFromTargetZ);
        if (Screen.orientation != ScreenOrientation.LandscapeLeft)
        {
            transform.position += vertOffsetFromTarget;
        }
    }
}
