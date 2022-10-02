using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedFood : MonoBehaviour
{
    public Grab grab;
    public GameObject gameLoop;
    public Transform plateObj;
    public Plate plate;
    bool isFirstTime = true;
    public SpriteRenderer sr;
    bool canPickFood = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFirstTime == true && collision.gameObject.tag == "Item")
        {
            isFirstTime = false;
            grab = GameObject.FindGameObjectWithTag("Grab").GetComponent<Grab>();
            grab.itemText.text = "";

            Destroy(collision.gameObject);
            Grab.isHolding = false;
            Grab.itemHolding.transform.parent = null;
            Grab.itemHolding = null;

            GameLoop gl = gameLoop.GetComponent<GameLoop>();
            gl.StartGameLoop();
        }
        else
        {
            if (collision.gameObject.tag == "Item" && canPickFood == true)
            {
                grab = GameObject.FindGameObjectWithTag("Grab").GetComponent<Grab>();
                grab.itemText.text = "";
                plateObj = grab.gameObject.transform.GetChild(0);
                plate = plateObj.GetComponent<Plate>();

                Destroy(collision.gameObject);
                Grab.isHolding = false;
                Grab.itemHolding.transform.parent = null;
                Grab.itemHolding = null;
                checkIfCorrect(plate.ingredients);
                disableEnable("disable");
            }
        }
    }

    public void checkIfCorrect(List<string> list)
    {
        GameLoop.checkIfDelievered(list);
    }

    public void disableEnable(string mode)
    {
        Color col;
        if(mode == "disable")
        {
            Debug.Log("FINISH FOOD DISABLE");
            if (ColorUtility.TryParseHtmlString("#44003E", out col))
            {
                sr.color = col;
            }
            canPickFood = false;
        }
        else if (mode == "enable")
        {
            Debug.Log("FINISH FOOD ENABLE");
            if (ColorUtility.TryParseHtmlString("#FF00E9", out col))
            {
                sr.color = col;
            }
            canPickFood = true;
        }
    }

    public void EnableObject()
    {

    }
}
