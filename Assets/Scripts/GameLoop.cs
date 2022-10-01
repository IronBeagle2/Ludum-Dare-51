using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    public static int score = 0;
    public static int ordersDone = 0;
    public static int lives = 4;

    public TMP_Text timeLeftTxt;
    public TMP_Text ingredientsTxt;
    public TMP_Text scoreTxt;
    public TMP_Text livesTxt;
    public List<string> ingredients = new List<string> { "Carrot", "Tomato", "Lettuce", "Onion", "Meat", "Oil" };
    public static List<string> finalOrder = new List<string>();
    public List<string> names1 = new List<string>();
    public List<string> names2 = new List<string>();
    public string finalName;
    int second = 0;
    public static bool wasIncorrect;
    public static bool didDeliver = false;

    public void StartGameLoop()
    {
        StartCoroutine(TheLoop());
    }

    IEnumerator TheLoop()
    {
        if(second <= 0)
        {
            //check if correct
            checkIfCorrect(finalOrder.Count);
            //generate new order
            ingredientsTxt.text = "";

            //difficulty increase
            if (ordersDone <= 5)
            {
                Debug.Log("diff 1");
                generateOrder(1, 3);
            }
            else if (ordersDone > 5 && ordersDone <= 10)
            {
                Debug.Log("diff 2");
                generateOrder(2, 4);
            }
            else if (ordersDone > 10 && ordersDone <= 15)
            {
                Debug.Log("diff 3");
                generateOrder(3, 5);
            }
            else if (ordersDone > 15 && ordersDone <= 20)
            {
                Debug.Log("diff 4");
                generateOrder(4, 6);
            }
            else if (ordersDone > 20)
            {
                Debug.Log("diff 5");
                generateOrder(5, 6);
            }
            second = 10;
            didDeliver = false;
        }
        yield return new WaitForSeconds(1);
        second--;
        timeLeftTxt.text = "Time left: " + second;
        StartCoroutine(TheLoop());
    }

    void generateOrder(int min, int max)
    {
        finalOrder.Clear();
        int current = min;
        int ingrCount = Random.Range(min, max);

        while (current <= ingrCount)
        {
            int rand = Random.Range(0, ingredients.Count);
            finalOrder.Add(ingredients[rand]);
            ingredientsTxt.text += ingredients[rand] + "\n";
            current++;
        }
    }
    void generateName()
    {

    }

    void checkIfCorrect(int ingrCount)
    {
        if (wasIncorrect == true || didDeliver == false)
        {
            //add strike
            lives--;
            livesTxt.text = "Lives: " + lives;

            //if 3 strikes game over "You're FIRED!!!!!!!!!"
            if(lives < 0)
            {
                lives = 3;
                if(Grab.isHolding)
                {
                    Grab.isHolding = false;
                    Grab.itemHolding.transform.parent = null;
                    Grab.itemHolding = null;
                }
                /*Grab grab = GameObject.FindGameObjectWithTag("Grab").GetComponent<Grab>();
                grab.itemText.text = "";*/
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            //add score
            int addScore = ingrCount * 10;
            score += addScore;
            scoreTxt.text = "Score: " + score;
            ordersDone++;
        }
        wasIncorrect = false;
    }



    public static void checkIfDelievered(List<string> listToCheck)
    {
        didDeliver = true;
        Debug.Log("DELIEVERED FOOD AND CALLED GAMELOOP!!!!");
        Debug.Log("ListToCheck: " + listToCheck.Count);
        if (listToCheck.Count == 0)
        {
            wasIncorrect = true;
        }
        else
        {
            int i = 0;
            foreach (var delItem in listToCheck)
            {
                if (i <= finalOrder.Count)
                {
                    if (finalOrder[i] == listToCheck[i])
                    {
                        Debug.Log($"Correct =)");
                        i++;
                    }
                    else
                    {
                        Debug.Log($"INCORRECT!");
                        wasIncorrect = true;
                        i = 99;
                    }
                }
            }
        }
    }
}
