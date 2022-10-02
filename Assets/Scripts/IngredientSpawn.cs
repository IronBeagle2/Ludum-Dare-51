using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawn : MonoBehaviour
{
    public bool isFull = false;
    public Transform spawnerTransform;
    public GameObject spawnGameObject;

    private void Update()
    {
        if (isFull == false)
        {
            GameObject obj = Instantiate(spawnGameObject, spawnerTransform.position, Quaternion.identity);
            obj.name = spawnGameObject.name;

            GameObject obj2 = Instantiate(spawnGameObject, spawnerTransform.position, Quaternion.identity);
            obj2.name = spawnGameObject.name;
            isFull = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == spawnGameObject.name)
        {
            isFull = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == spawnGameObject.name)
        {
            isFull = true;
        }
    }
}
