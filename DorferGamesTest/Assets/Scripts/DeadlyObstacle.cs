using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyObstacle : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Snake potentioalSnake = collision.gameObject.GetComponent<Snake>();
        if (potentioalSnake != null)
        {
            potentioalSnake.Die();
        }
    }
}
