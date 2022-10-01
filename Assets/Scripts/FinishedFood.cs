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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFirstTime == true && collision.gameObject.tag == "Item")
        {
            isFirstTime = false;
            grab = GameObject.FindGameObjectWithTag("Grab").GetComponent<Grab>();
            grab.itemText.text = "";

            Destroy(collision.gameObject);
            Debug.Log("deleted!!!!");
            Grab.isHolding = false;
            Grab.itemHolding.transform.parent = null;
            Grab.itemHolding = null;

            GameLoop gl = gameLoop.GetComponent<GameLoop>();
            gl.StartGameLoop();
        }
        else
        {
            //Debug.Log("TRIGGERED!!!! " + collision);
            if (collision.gameObject.tag == "Item")
            {
                grab = GameObject.FindGameObjectWithTag("Grab").GetComponent<Grab>();
                grab.itemText.text = "";
                plateObj = grab.gameObject.transform.GetChild(0);
                plate = plateObj.GetComponent<Plate>();

                Destroy(collision.gameObject);
                Debug.Log("deleted!!!!");
                Grab.isHolding = false;
                Grab.itemHolding.transform.parent = null;
                Grab.itemHolding = null;
                checkIfCorrect(plate.ingredients);
            }
        }
    }

    public void checkIfCorrect(List<string> list)
    {
        GameLoop.checkIfDelievered(list);
    }
}
