using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public float velocity;
    public LayerMask land;
    public Camera mainCamera;
    internal Vector2 pointToFollow;
    Rigidbody body;
    bool follow = false;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckClicked();
        CheckTouch();
        Follow();
    }
    public void SetFollowPoint(Vector2 newFollow)
    {
        pointToFollow = newFollow;
    }
    void CheckTouch()
    {
        if (Input.touchCount > 0)
        {
            follow = true;
        }
        if (Input.touchCount == 0)
        {
            follow = false;
        }
    }
    public void CheckClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            follow = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            follow = false;
        }
    }

    void Follow()
    {
        //CastRayToTouchPoint();
        CastRayToClickPoint();
        float diff = transform.position.x - pointToFollow.x;
        if (Mathf.Abs(diff) > 1.0f)
            diff = Mathf.Sign(diff);
        body.velocity = new Vector3( -velocity*diff, 0.0f, velocity);
    }

    void CastRayToClickPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        RaycastHit[] hit = Physics.RaycastAll(ray, 100f, land);
        if (hit.Length > 0)
            SetFollowPoint(hit[0].point);
    }

    void CastRayToTouchPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0f));
        RaycastHit[] hit = Physics.RaycastAll(ray, 100f, land);
        if (hit.Length > 0)
            SetFollowPoint(hit[0].point);
    }
}
