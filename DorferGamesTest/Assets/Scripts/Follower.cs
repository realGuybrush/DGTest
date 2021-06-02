using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public float velocityZ;
    public float velocityX;
    internal Vector2 pointToFollow;
    internal Rigidbody body;
    internal bool follow = true;
    public Follower tail;

    void Start()
    {
        Init();
    }

    void Update()
    {
        UpdateActions();
    }

    internal virtual void Init()
    {
        body = this.GetComponent<Rigidbody>();
    }

    internal virtual void UpdateActions()
    {
        Follow();
    }

    public void SetFollowPoint(Vector2 newFollow)
    {
        pointToFollow = newFollow;
    }

    internal void Follow()
    {
        float diff = transform.position.x - pointToFollow.x;
        if (Mathf.Abs(diff) > 1.0f)
            diff = Mathf.Sign(diff);
        body.velocity = new Vector3( -velocityX*diff, 0.0f, velocityZ);
        tail?.SetFollowPoint(transform.position);
    }
}
