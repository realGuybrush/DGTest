using UnityEngine;


public class Consumable : MonoBehaviour
{
    [SerializeField]
    private ConsumableType type;

    [SerializeField]
    private Collider myCollider;

    [SerializeField]
    private Renderer myRenderer;
    
    private Color color;
    
    private readonly Vector3 shrinkSize = new Vector3(0.2f, 0.2f, 0.2f);
    private bool gettingEaten;

    private void Awake()
    {
        color = myRenderer.material.color;
    }

    void Update()
    {
        if (gettingEaten)
        {
            transform.localScale -= shrinkSize;
            if (transform.localScale.x <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void GetEaten()
    {
        myCollider.enabled = false;
        if(type != ConsumableType.Finish)
        {
            gettingEaten = true;
            EdibleCounter.Instance.Increase(type);
        }
    }

    public bool IsCrystal => type == ConsumableType.Crystal;

    public bool IsFinish => type == ConsumableType.Finish;

    public Color Color => color;

}
