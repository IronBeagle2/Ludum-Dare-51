using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Grab : MonoBehaviour
{
    public Transform grabCheck;
    public static bool isHolding = false;
    public bool isColliding = false;
    public static Collider2D itemHolding;
    public static string itemHoldingMode;
    Collider2D itemColliding;

    public TMP_Text itemText;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!isHolding && isColliding)
            {
                holdItem();
            }
            else if(isHolding)
            {
                dropItem();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Food")
        {
            isColliding = true;
            itemColliding = other;
            itemHoldingMode = "food";
        }
        else if (other.tag == "Item")
        {
            isColliding = true;
            itemColliding = other;
            itemHoldingMode = "plate";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Item" || other.tag == "Food")
        {
            isColliding = false;
            itemColliding = null;
            itemHoldingMode = null;
        }
    }

    public void holdItem()
    {
        isHolding = true;
        itemHolding = itemColliding;
        if (itemHoldingMode == "food")
        {
            itemText.text = itemHolding.name;
        }
        else if (itemHoldingMode == "plate")
        {
            Plate plate = itemHolding.GetComponent<Plate>();
            if(plate.ingredients.Count == 0)
            {
                itemText.text += $"Plate (empty)";
            }
            else
            {
                itemText.text += $"Plate:\n";
                foreach (var ingr in plate.ingredients)
                {
                    itemText.text += $"{ingr}\n";
                }
            }
        }
        itemHolding.transform.parent = grabCheck;
        itemHolding.transform.localPosition = grabCheck.transform.localPosition;
    }

    public void dropItem()
    {
        itemText.text = "";
        itemHolding.transform.parent = null;
        itemHolding = null;
        isHolding = false;
    }
}
