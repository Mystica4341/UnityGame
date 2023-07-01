using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    //giới hạn của vòng tuần tra
    [Header ("Input")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform enemy;

    //tốc độ
    [Header ("Movement speed")]
    [SerializeField] private float speed;

    //hướng nhân vật
    private Vector3 initScale;
    private bool movingLeft;

    //thời gian kẻ thù đứng yên
    [Header ("Idle duration")]
    [SerializeField] private float idleDuration;
    private float idleTimer;
    
    [Header ("Animate input")]
    [SerializeField] private Animator anim;

    private void Awake() {
        initScale = enemy.localScale;
    }

    private void Update() {
        if (movingLeft){
            if ((enemy.position.x) >= (leftEdge.position.x))
                MoveInDirection(-1);
            else
                changeDirection();
        }
        else
        {
            if ((enemy.position.x) <= (rightEdge.position.x))
                MoveInDirection(1);
            else
                changeDirection();
        } 
    }

    //thay đổi hướng
    private void changeDirection(){
        anim.SetBool("moving",false);

        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration){
            movingLeft = !movingLeft;
        }
    }

    private void OnDisable() {
        anim.SetBool("moving", false);
    }

    private void MoveInDirection(int direction){
        idleTimer = 0;
        anim.SetBool("moving",true);
        //Enemy xoay mặt
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);

        //Enemy di chuyển
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, 
        enemy.position.y, enemy.position.z);
    }
}
