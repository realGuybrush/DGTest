using UnityEngine;

public class BaseFollow : MonoBehaviour
{
    
    [SerializeField]
    protected Rigidbody body;

    [SerializeField]
    private Renderer myRenderer;
    
    [SerializeField]
    protected float velocityX, velocityZ;
    
    protected Vector3 pointToFollow;
    protected bool follow = true;
    protected static bool alive = false;

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

    protected virtual void Init()
    {
    }

    protected virtual void UpdateActions()
    {
        Follow();
    }

    protected void SetFollowPoint(Vector3 newFollow)
    {
        pointToFollow = newFollow;
    }

    protected virtual void Follow()
    {
        float diff = transform.position.x - pointToFollow.x;
        if (Mathf.Abs(diff) > 1.0f)
            diff = Mathf.Sign(diff);
        body.velocity = new Vector3( -velocityX*diff, 0.0f, velocityZ);
    }

    public void SetColor(Color newColor)
    {
        myRenderer.material.color = newColor;
    }

    public Color Color => myRenderer.material.color;
}
