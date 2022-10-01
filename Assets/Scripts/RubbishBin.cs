using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RubbishBin : MonoBehaviour
{
    public Grab grab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item" || collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            Grab.isHolding = false;
            Grab.itemHolding.transform.parent = null;
            Grab.itemHolding = null;
            grab = GameObject.FindGameObjectWithTag("Grab").GetComponent<Grab>();
            grab.itemText.text = "";
        }

    }

}
