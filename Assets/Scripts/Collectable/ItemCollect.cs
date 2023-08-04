using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{

    private int fruit = 0;

    [SerializeField] private Text fruitText;
    [SerializeField] private AudioClip collecttionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruits"))
        {
            SoundManager.instance.PlaySound(collecttionSoundEffect);
            Destroy(collision.gameObject);
            fruit++;
            fruitText.text = "Fruits: " + fruit;
        }
    }
    public int returnFruit()
    {
        return fruit;
    }
}