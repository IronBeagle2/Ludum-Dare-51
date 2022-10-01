using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameLoop : MonoBehaviour
{
    public static int score = 0;
    public static int ordersDone = 0;
    public static int lives = 4;

    public TMP_Text timeLeftTxt;
    public TMP_Text ingredientsTxt;
    public TMP_Text scoreTxt;
    public TMP_Text livesTxt;
    public TMP_Text nameTxt;

    public List<string> ingredients = new List<string> { "Carrot", "Tomato", "Lettuce", "Onion", "Meat", "Oil" };
    public static List<string> finalOrder = new List<string>();
    public List<string> nameAdjectives = new List<string>(); //pø jm
    public List<string> nameNouns = new List<string>(); //pod jm
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
            if (ordersDone <= 4)
            {
                Debug.Log("diff 1");
                generateOrder(1, 3);
            }
            else if (ordersDone > 4 && ordersDone <= 9)
            {
                Debug.Log("diff 2");
                generateOrder(2, 3);
            }
            else if (ordersDone > 9 && ordersDone <= 14)
            {
                Debug.Log("diff 3");
                generateOrder(2, 4);
            }
            else if (ordersDone > 14)
            {
                Debug.Log("diff 4");
                generateOrder(3, 4);
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
        System.Random r = new System.Random();
        int ingrCount = r.Next(min, max);
        Debug.Log($"min: {min}, max: {max}, count: {ingrCount}");

        for (int i = 1; i <= ingrCount; i++)
        {
            System.Random r2 = new System.Random();
            int rand = r.Next(0, ingredients.Count);
            finalOrder.Add(ingredients[rand]);
            ingredientsTxt.text += $"{i}) {ingredients[rand]}\n";
        }
        generateName();
    }
    void generateName()
    {
        nameAdjectives.Clear();
        nameNouns.Clear();
        foreach(var item in finalOrder)
        {
            if (item == "Carrot")
            {
                nameAdjectives.Add("Orange");
                nameAdjectives.Add("Wild");
                nameAdjectives.Add("Shredded");
                nameAdjectives.Add("Sliced");
                nameNouns.Add("Carrots");
            }
            else if (item == "Tomato")
            {
                nameAdjectives.Add("Red");
                nameAdjectives.Add("Cherry");
                nameAdjectives.Add("Organic");
                nameAdjectives.Add("Stuffed");
                nameNouns.Add("Tomatoes");
            }
            else if (item == "Lettuce")
            {
                nameAdjectives.Add("Green");
                nameAdjectives.Add("Crispy");
                nameAdjectives.Add("Wilted");
                nameAdjectives.Add("Iceberg");
                nameNouns.Add("Lettuce");
            }
            else if (item == "Onion")
            {
                nameAdjectives.Add("Yellow");
                nameAdjectives.Add("Sweet");
                nameAdjectives.Add("Minced");
                nameAdjectives.Add("French");
                nameNouns.Add("Onions");
            }
            else if (item == "Meat")
            {
                nameAdjectives.Add("Raw");
                nameAdjectives.Add("Meaty");
                nameAdjectives.Add("Grilled");
                nameAdjectives.Add("Dried");
                nameNouns.Add("Meat");
            }
            else if (item == "Oil")
            {
                nameAdjectives.Add("Oily");
                nameAdjectives.Add("Tropical");
                nameAdjectives.Add("Aromatic");
                nameAdjectives.Add("Flavored");
                nameNouns.Add("Oil");
            }
            //Adjective
            System.Random rAdjec = new System.Random();
            int randAdjec = rAdjec.Next(0, nameAdjectives.Count);
            finalName += nameAdjectives[randAdjec];

            finalName += " ";
            //Noun
            System.Random rNoun = new System.Random();
            int randNoun = rNoun.Next(0, nameNouns.Count);
            finalName += nameNouns[randNoun];

            nameTxt.text = finalName;
            finalName = "";
        }
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

                SceneManager.LoadScene("GameOver");
                ordersDone = 0;
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
        //Debug.Log("DELIEVERED FOOD AND CALLED GAMELOOP!!!!");
        //Debug.Log("ListToCheck: " + listToCheck.Count);
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
                        //Debug.Log($"Correct =)");
                        i++;
                    }
                    else
                    {
                        //Debug.Log($"INCORRECT!");
                        wasIncorrect = true;
                        i = 99;
                    }
                }
            }
        }
    }
}
