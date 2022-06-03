using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float dodgeStamina = 5f;
    private Rigidbody2D body;
    Vector2 movement;
    [SerializeField] private float dodgeDistance = 2.0f;
    public GameObject playerBasicAttack;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
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

        movement = movement.normalized;
        body.MovePosition(body.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

