using UnityEngine;

public class HalberdAttack : MonoBehaviour
{
    public GameObject playerBasicAttack;
    private Animator anim;
    private bool right = true;

    
    void Start()
    {
        anim = GetComponent<Animator>();        
    }
    void FixedUpdate()
    {
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
        Instantiate(playerBasicAttack, gameObject.transform.position + new Vector3(0.0f, 0.35f), Quaternion.Euler(0f, 0f, 60f));
    }    
    void spawn_front_attack()
    {
        if (right){
            Debug.Log("right");
            Instantiate(playerBasicAttack, gameObject.transform.position + new Vector3(0.25f, 0.0f), Quaternion.identity);
        }else{
            Debug.Log("left");
            Instantiate(playerBasicAttack, gameObject.transform.position + new Vector3(-0.25f, 0.0f), Quaternion.Euler(0f,180f,0f));
        }
    }
    void spawn_down_attack()
    {
        Debug.Log("down");
        Instantiate(playerBasicAttack, gameObject.transform.position + new Vector3(0.0f, -0.45f), Quaternion.Euler(0f, 0f, 270f));
        
    }
}

