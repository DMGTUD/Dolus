using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    
    public int difficulty;
    private float cooldown;
    public int position;
    private GameObject playerObject;
    public bool attackMode;
    public bool die;
    public bool jump;

    void Start()
    {
        cooldown = 3;
        playerObject = GameObject.Find("Player Code");
    }

    void Update()
    {
        if (attackMode)
        {
            Move();
        }

        if (jump)
        {
            playerObject.GetComponent<CameraMovement>().dead=true;
        }
        
        
        if (die)
        {
            SceneManager.LoadScene("Loose");
        }
    }

    void Move()
    {
        cooldown-=Time.deltaTime;
        if (cooldown<=0)
        {
            int casino = Random.Range(1,31);
            if(casino<=difficulty)
            {
                position ++;
                print(casino);
                print("Enemy " + this.name + " has moved.");
            }

            if (position == 5)
            {
                position =2;
            }


            cooldown=3;
            
        }


        this.GetComponent<Animator>().SetInteger("Position",position);
        this.GetComponent<Animator>().SetBool("Is Defending",playerObject.GetComponent<CameraMovement>().hidden);
        
        
    }

    public void ActivateEnemy()
    {
        attackMode = true;
    }
    
}
