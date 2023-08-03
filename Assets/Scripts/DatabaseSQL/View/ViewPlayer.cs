using System.Data;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewPlayer : MonoBehaviour
{
    private bool levelCompleted = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHandler playerHandler = new PlayerHandler();
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            playerHandler.Complete(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
