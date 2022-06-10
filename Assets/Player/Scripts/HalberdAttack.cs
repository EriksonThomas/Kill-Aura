using UnityEngine;

public class HalberdAttack : MonoBehaviour
{
    public GameObject playerBasicAttack;
    private Animator anim;
    public AudioSource audioSource;
    public AudioClip Attack;
    public float volume = 5f;
    private bool right = true;
    private bool set = false;
    private int dir = -1;
    void Start()
    {
        anim = GetComponent<Animator>();        
    }
    void Update()
    {   set = false;
        dir = 4;
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = 0;
            set = true;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = 1;
            set = true;
        }  
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = 2;
            set = true;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = 3;
            set = true;
        }
        if (!set)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                dir = 0;
            }

            if(Input.GetKey(KeyCode.DownArrow))
            {
                dir = 1;
            }  
            
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                dir = 2;
            }

            if(Input.GetKey(KeyCode.RightArrow))
            {
                dir = 3;
            }
        }
        if(!anim.GetBool("attacking")){
            switch(dir)
            {
                case 0:
                anim.SetTrigger("up_attack_trigger");
                break;

                case 1:
                anim.SetTrigger("down_attack_trigger");
                break;

                case 2:
                right = false;
                transform.rotation = Quaternion.Euler(0f,180f,0f);
                anim.SetTrigger("front_attack_trigger");
                break;

                case 3:
                right = true;
                transform.rotation = Quaternion.Euler(0f,0f,0f);
                anim.SetTrigger("front_attack_trigger");
                break;

                case 4:
                break;
            }
        }
    }

    void spawn_up_attack()
    {
        AudioSource.PlayClipAtPoint(Attack, transform.position);
        Instantiate(playerBasicAttack, gameObject.transform.position + new Vector3(0.0f, 0.35f), Quaternion.Euler(0f, 0f, 60f));
    }    
    void spawn_front_attack()
    {
        if (right)
        {
            AudioSource.PlayClipAtPoint(Attack, transform.position);
            Instantiate(playerBasicAttack, gameObject.transform.position + new Vector3(0.35f, 0.0f), Quaternion.identity);
        }
        else
        {
            AudioSource.PlayClipAtPoint(Attack, transform.position);
            Instantiate(playerBasicAttack, gameObject.transform.position + new Vector3(-0.35f, 0.0f), Quaternion.Euler(0f,180f,0f));
        }
    }
    void spawn_down_attack()
    {
        AudioSource.PlayClipAtPoint(Attack, transform.position);
        Instantiate(playerBasicAttack, gameObject.transform.position + new Vector3(0.0f, -0.45f), Quaternion.Euler(0f, 0f, 270f));
    }
}

