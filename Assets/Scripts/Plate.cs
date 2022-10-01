using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Grab grab;
    public List<string> ingredients = new List<string>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGERED!!!! " + collision);
        if (collision.gameObject.tag == "Food")
        {
            ingredients.Add(collision.gameObject.name);
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
