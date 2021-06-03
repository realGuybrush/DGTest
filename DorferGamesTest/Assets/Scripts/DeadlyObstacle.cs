using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyObstacle : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Snake potentialSnake = collision.gameObject.GetComponent<Snake>();
        if (potentialSnake != null)
        {
            potentialSnake.Die();
        }
    }
}
