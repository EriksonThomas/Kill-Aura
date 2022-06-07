using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private const float dazeTime = 0.4f;
    public float dazeCounter;
    private float randomCount;
    private SpriteRenderer my_sprite_renderer;
    private Material white_mat;
    private Material default_mat;
    public GameObject[] gemPrefab;
    public GameObject[] expPrefab;
    public int expDropped;
    private int randomNumber;
    public float attackDamage;

    void Start()
    {
        my_sprite_renderer = GetComponent<SpriteRenderer>();
        white_mat = Resources.Load("damaged_material", typeof(Material)) as Material;
        default_mat = my_sprite_renderer.material;
    }
    void FixedUpdate()
    {       
        if (dazeCounter > 0)
        {
            gameObject.GetComponent<EnemyMovement>().moveSpeed = 0.0f;
            dazeCounter -= Time.fixedDeltaTime;            
        }
        else
        {
            gameObject.GetComponent<EnemyMovement>().moveSpeed = gameObject.GetComponent<EnemyMovement>().moveSpeedStart;
        }
    }
    public void DoDamage(float damage)
    {
        
        currentHealth -= damage;  
        //Debug.Log(gameObject.ToString() +" TOOK " + damage + " DAMAGE ");
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            spawn_loot();
            if(gameObject.GetComponent<CreateSnailTrail>() != null)
            {
                for (int i = 0; i < gameObject.GetComponent<CreateSnailTrail>().trailList.Length; i++)
                {
                    Destroy(gameObject.GetComponent<CreateSnailTrail>().trailList[i]);
                }
            }
        }
        dazeCounter = dazeTime;
        flash_white_mat();
    }
    
    private void flash_white_mat()
    {
        my_sprite_renderer.material = white_mat;
        Invoke("reset_material", dazeTime/2);
    }
    private void reset_material()
    {
        my_sprite_renderer.material = default_mat;
    }
    private void spawn_loot()
    {
        //for (float i = 0; i <= Random.Range(0, gemPrefab.Length); i++)
        //{
        //    // Take a random number in Gem Prefab array and cast it to the spawn it in on death
        //    randomNumber = Random.Range(0, gemPrefab.Length);
        //    gameObject.transform.position = gameObject.transform.position + (Random.insideUnitSphere * .3f);
        //    GameObject gem = Instantiate(gemPrefab[randomNumber], gameObject.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        //}

        for (float i = 0; i <= Random.Range(0, 6.0f); i++)
        {
            // Take a random number in EXP Prefab array and cast it to the spawn it in on death
            gameObject.transform.position = gameObject.transform.position + (Random.insideUnitSphere * .3f);
            GameObject exp = Instantiate(expPrefab[expDropped], gameObject.transform.position, Quaternion.identity);
        }
    }
}
