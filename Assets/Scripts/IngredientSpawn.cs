using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawn : MonoBehaviour
{
    public bool isFull = false;
    public Transform spawnerTransform;
    public GameObject spawnGameObject;

    GameObject obj;

    private void Start()
    {
        obj = Instantiate(spawnGameObject, spawnerTransform.position, Quaternion.identity);
        obj.name = spawnGameObject.name;
    }
    private void Update()
    {
        Collider2D col = spawnerTransform.GetComponent<Collider2D>();
        col.enabled = false;
        col.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name + " called ontrigger enter");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.name + " called ontrigger exit");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name + " called ontrigger stay");
    }
}
