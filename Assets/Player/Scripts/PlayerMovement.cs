using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float dodgeStamina = 5f;
    private Rigidbody2D body;
    Vector2 movement;
    [SerializeField] private float dodgeDistance = 2.0f;
    public GameObject playerBasicAttack;
    private Animator anim;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
        body.freezeRotation = true;
    }
    void Update()
    {
         
    }
    void FixedUpdate()
    {
        movement = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //anim.SetTrigger("right_walk_trigger");
            movement += Vector2.right;
            
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("got space");
            if (GetComponent<PlayerController2D>().currentStamina >= dodgeStamina)
            {
                //TODO:
                //SET IS INVONERABLE
                //MATERIAL SET SLIGHTLY TRANSPARENT
                gameObject.GetComponent<PlayerController2D>().currentStamina -= dodgeStamina;
                // Vector2 temp = movement.normalized * dodgeDistance;
                movement = movement.normalized;
                body.MovePosition(body.position + movement * moveSpeed * 100 * Time.fixedDeltaTime);
                //body.transform.position += new Vector3(temp.x,temp.y,0);
                this.gameObject.GetComponent<Animator>().SetTrigger("dodge");
            }
        } 

        movement = movement.normalized;
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

