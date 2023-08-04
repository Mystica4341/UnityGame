using System.Data;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewPlayer : MonoBehaviour
{
    private bool levelCompleted = false;
    public int level;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHandler playerHandler = new PlayerHandler();
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            levelCompleted = true;
            playerHandler.statusComplete(level);
            Invoke("CompleteLevel", 0f);
        }
        ItemCollect item = new ItemCollect();
        int fruit = item.returnFruit();
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(1);
    }
}
