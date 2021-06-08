using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        Snake possibleSnake = collider.gameObject.GetComponent<Snake>();
        if (possibleSnake != null)
        {
            possibleSnake.Die(false);
        }
    }
}
