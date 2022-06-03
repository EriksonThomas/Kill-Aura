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
    private bool right = true;

    
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
            reset_triggers();
            anim.SetTrigger("up_attack_trigger");
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            reset_triggers();
            anim.SetTrigger("down_attack_trigger");
        }  
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            right = false;
            transform.rotation = Quaternion.Euler(0f,180f,0f);
            reset_triggers();
            anim.SetTrigger("front_attack_trigger");
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            right = true;
            transform.rotation = Quaternion.Euler(0f,0f,0f);
            reset_triggers();
            anim.SetTrigger("front_attack_trigger");
        }

        movement = movement.normalized;
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void reset_triggers()
    {
        anim.ResetTrigger("up_attack_trigger");
        anim.ResetTrigger("front_attack_trigger");
        anim.ResetTrigger("down_attack_trigger");        
    }

    void spawn_up_attack()
    {
        Debug.Log("up");
        Instantiate(playerBasicAttack, body.transform.position + new Vector3(0.0f, 0.35f), Quaternion.Euler(0f, 0f, 60f));
    }    
    void spawn_front_attack()
    {
        if (right){
            Debug.Log("right");
            Instantiate(playerBasicAttack, body.transform.position + new Vector3(0.25f, 0.0f), Quaternion.identity);
        }else{
            Debug.Log("left");
            Instantiate(playerBasicAttack, body.transform.position + new Vector3(-0.25f, 0.0f), Quaternion.Euler(0f,180f,0f));
        }
    }
    void spawn_down_attack()
    {
        Debug.Log("down");
        Instantiate(playerBasicAttack, body.transform.position + new Vector3(0.0f, -0.45f), Quaternion.Euler(0f, 0f, 270f));
        
    }
}

