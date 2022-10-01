    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Grab grab;
    public List<string> ingredients = new List<string>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        grab = GameObject.FindGameObjectWithTag("Grab").GetComponent<Grab>();
        if (collision.gameObject.tag == "Food" && grab.holdsPlate == false)
        {
            ingredients.Add(collision.gameObject.name);
            Destroy(collision.gameObject);
            Grab.isHolding = false;
            Grab.itemHolding.transform.parent = null;
            Grab.itemHolding = null;
            grab.itemText.text = "";
        }
    }
}
