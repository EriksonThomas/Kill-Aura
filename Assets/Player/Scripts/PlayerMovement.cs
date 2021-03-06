using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float dodgeStamina = 5f;
    [SerializeField] private Effect_Dodge dodgeData; 
    private Rigidbody2D body;
    Vector2 movement;
    public GameObject playerBasicAttack;
    private Animator anim;
    private PlayerStats playerStats;
    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
        body.freezeRotation = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerStats.currentStamina >= dodgeStamina && GameHandler.instance.globalTimer.GetComponent<GlobalTimer>().requestAbility("dodgeCD"))
            {
                playerStats.currentStamina -= dodgeStamina;
                GameHandler.instance.player.GetComponent<Animator>().SetFloat("movementX", movement.x);
                GameHandler.instance.player.GetComponent<Animator>().Play("dodge");
                GameHandler.instance.player.GetComponent<EffectableObject>().ApplyEffect(dodgeData);
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
        body.MovePosition(body.position + movement * GameHandler.instance.player.GetComponent<PlayerStats>().moveSpeed * Time.fixedDeltaTime);
    }
}
