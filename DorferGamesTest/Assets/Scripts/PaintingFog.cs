using UnityEngine;

public class PaintingFog : MonoBehaviour
{
    private Color color;
    private void Awake()
    {
        color = gameObject.GetComponent<Renderer>().material.color;
    }

    public void OnTriggerEnter(Collider collider)
    {
        var snake = collider.gameObject.GetComponent<BaseFollow>();
        snake?.SetColor(color);
    }
}
