using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header ("Components")]
    [SerializeField] private Behaviour[] components;

    [Header ("Sound effect")]
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip deathSound;

    private bool Invunerable;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(int _damage)
    {
        if (Invunerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if (!dead)
            {
                

                // //Người chơi
                // if (GetComponent<PlayerMovement>() != null){
                //     GetComponent<PlayerMovement>().enabled = false;
                // }

                // //Enemy
                // if (GetComponentInParent<EnemyPatrol>()!= null){
                //     GetComponentInParent<EnemyPatrol>().enabled = false;
                // }
                // if (GetComponent<Enemy>() != null){
                //     GetComponent<Enemy>().enabled = false;
                // }
                
                //vô hiệu hóa người chơi hoặc kẻ thù khi họ chết
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                anim.SetBool("grounded", true);
                anim.SetTrigger("die");

                dead = true;
                SoundManager.instance.PlaySound(deathSound);
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
        StartCoroutine(Invunerability());

        foreach (Behaviour component in components)
            component.enabled = true;
    }
    private IEnumerator Invunerability()
    {
        Invunerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        Invunerable = false;
    }

    //vô hiệu hóa
    private void Deactivate(){
        gameObject.SetActive(false);
    }
}