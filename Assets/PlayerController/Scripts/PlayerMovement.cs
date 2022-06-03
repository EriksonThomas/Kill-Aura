using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float dodgeStamina = 5f;
    private Rigidbody2D body;
    Vector2 movement;
    [SerializeField] private float dodgeDistance = 2.0f;
    private Animator anim;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        anim = GetComponent<Animator>();        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GetComponent<PlayerController2D>().currentStamina >= dodgeStamina)
            {
                GetComponent<PlayerController2D>().currentStamina -= dodgeStamina;
                Vector2 temp = movement.normalized * dodgeDistance;
                body.transform.position += new Vector3(temp.x,temp.y,0);
            }
        }  
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
            movement += Vector2.right;
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0f,180f,0f);
            anim.SetTrigger("up_attack_trigger");
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0f,0f,0f);
            anim.SetTrigger("down_attack_trigger");
        }  
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0f,180f,0f);
            anim.SetTrigger("front_attack_trigger");
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0f,0f,0f);
            anim.SetTrigger("front_attack_trigger");
        }


        movement = movement.normalized;
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

