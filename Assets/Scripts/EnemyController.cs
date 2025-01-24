using UnityEngine;


public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    Rigidbody2D rigidbody2d;
    public float changeTime = 3.0f;
    public float changeDir = 5.0f;
    float timer2;
    float timer;
    int direction = 1;
    Animator animator;
    bool broken = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        timer2 = changeDir;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!broken)
        { 
            return;
        }

        timer -= Time.deltaTime;
        if (timer <0)
            {
                direction = -direction;
                timer = changeTime;
            }
        timer2 -= Time.deltaTime;
        if (timer2 <0)
            {
                vertical = !vertical;
                timer2 = changeDir;
            }

    }

    void FixedUpdate()
    {

        Vector2 position = rigidbody2d.position;
        
        if (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        rigidbody2d.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
            {
                player.ChangeHealth(-1);
            }
    }

    public void Fix()
    {
        broken = false;
        rigidbody2d.simulated = false;
    }
}
