using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Tấn công 
    [Header ("Attack")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    

    //Tầm tấn công
    [Header ("Attack range")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    //Nhận diện người chơi
    [Header ("Player detect")]
    [SerializeField] private LayerMask playerLayer;
    private float CooldownTimer = Mathf.Infinity;

    [Header ("Sound effect")]
    [SerializeField] private AudioClip attackSound;

    private Animator anim;

    private Health playerHealth;

    private EnemyPatrol enemyPatrol;

    private void Awake() {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }


    private void Update()
    {
        CooldownTimer += Time.deltaTime;

        //attack
        if (PlayerInsight())
        {
            if (CooldownTimer >= attackCooldown && playerHealth.currentHealth > 0)
            {
                CooldownTimer = 0;
                anim.SetTrigger("attack");
                SoundManager.instance.PlaySound(attackSound);
            }
        }

        if (enemyPatrol != null){
            enemyPatrol.enabled = !PlayerInsight();
        }
        
    }

    //check nhân vật trong tầm 
    private bool PlayerInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null){
            playerHealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider != null;
    }

    //vẽ khung màu đỏ
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    //gây damage cho nhân vật
    private void DamagePlayer()
    {
        if(PlayerInsight()){
            playerHealth.TakeDamage(damage);
        }
    }
}
