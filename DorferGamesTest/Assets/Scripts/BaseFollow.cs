using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFollow : MonoBehaviour
{
    public float velocityZ;
    public float velocityX;
    internal Vector3 pointToFollow;
    internal Rigidbody body;
    internal bool follow = true;
    static internal bool alive = false;

    void Start()
    {
        Init();
    }

    void FixedUpdate()
    {
        if (alive)
        {
            UpdateActions();
        }
        else
        {
            body.velocity = new Vector3(0f, 0f, 0f);
        }
    }

    internal virtual void Init()
    {
        body = this.GetComponent<Rigidbody>();
    }

    internal virtual void UpdateActions()
    {
        Follow();
    }

    public void SetFollowPoint(Vector3 newFollow)
    {
        pointToFollow = newFollow;
    }

    internal virtual void Follow()
    {
        float diff = transform.position.x - pointToFollow.x;
        if (Mathf.Abs(diff) > 1.0f)
            diff = Mathf.Sign(diff);
        body.velocity = new Vector3( -velocityX*diff, 0.0f, velocityZ);
    }
}
