using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;

public class EndGame : MonoBehaviour
{
    private int numsfruit = 0;
    [SerializeField] private Text textFruit;
    void Start()
    {
        ShowFruit();
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowFruit()
    {
        PlayerHandler playerHandler = new PlayerHandler();
        numsfruit = playerHandler.findFruit();
        textFruit.text = "Fruits: " + numsfruit;
    }
}