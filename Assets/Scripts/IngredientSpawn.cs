using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawn : MonoBehaviour
{
    public Transform spawnerTransform;
    public GameObject spawnGameObject;

    void Start()
    {
        GameObject obj = Instantiate(spawnGameObject, spawnerTransform.position, Quaternion.identity);
        obj.name = spawnGameObject.name;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Item" || collision.tag == "Food")
        {
            GameObject obj = Instantiate(spawnGameObject, spawnerTransform.position, Quaternion.identity);
            obj.name = spawnGameObject.name;
        }
    }
}
