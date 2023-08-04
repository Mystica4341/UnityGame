using System.Data;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ViewPlayer : MonoBehaviour
{
    private bool levelCompleted = false;
    public Text fruitText;
    public int level;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemCollect item = new ItemCollect();
        PlayerHandler playerHandler = new PlayerHandler();
        string collectedFruit = fruitText.text;
        string[] collectedFruitarray = collectedFruit.Split(' ');
        int fruit = Convert.ToInt32(collectedFruitarray[1]);
        if (level == 4)
        {
            if (collision.gameObject.name == "Player" && !levelCompleted)
            {
                levelCompleted = true;
                playerHandler.statusComplete(level);
                Invoke("CompleteGame", 0f);
                playerHandler.insertFruit(fruit);
            }
        }
        else
        {
            if (collision.gameObject.name == "Player" && !levelCompleted)
            {
                levelCompleted = true;
                playerHandler.statusComplete(level);
                Invoke("CompleteLevel", 0f);
                playerHandler.insertFruit(fruit);
            }
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(1);
    }
    private void CompleteGame()
    {
        SceneManager.LoadScene(6);
    }
}
