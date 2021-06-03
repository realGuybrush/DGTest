using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumableType { Human, Crystal }

public class Consumable : MonoBehaviour
{
    public ConsumableType type;
    bool gettingEaten;

    private void Start()
    {
        gettingEaten = false;
    }

    void Update()
    {
        if (gettingEaten)
        {
            this.transform.localScale = this.transform.localScale - new Vector3(0.2f, 0.2f, 0.2f);
        }
        if (this.transform.localScale.x <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void GetEaten()
    {
        gettingEaten = true;
        this.GetComponent<Collider>().enabled = false;
    }

}
