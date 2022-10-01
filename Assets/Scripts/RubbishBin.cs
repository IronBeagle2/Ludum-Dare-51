using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RubbishBin : MonoBehaviour
{
    public Grab grab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGERED!!!! " + collision);
        if (collision.gameObject.tag == "Item" || collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            Debug.Log("deleted!!!!");
            Grab.isHolding = false;
            Grab.itemHolding.transform.parent = null;
            Grab.itemHolding = null;
            grab = GameObject.FindGameObjectWithTag("Grab").GetComponent<Grab>();
            grab.itemText.text = "";
        }

    }

}
