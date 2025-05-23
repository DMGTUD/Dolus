using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    
    public int targetPosition;
    public int currentPosition;
    public bool hidden;
    public bool dead;
    public bool timesUp;
    public bool killed;
    private float timeToDie=1.2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPosition=0;
        currentPosition=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            InteractCam();
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            InteractHide();
        }


        if (!timesUp)
        {
          if (currentPosition==2)
            {
                hidden=true;
            }
            else 
            {
                hidden = false;
            }  
        }

        if(dead)
        {
            currentPosition=3;
            timeToDie-=Time.deltaTime;
            if(timeToDie<=0)
            {
                SceneManager.LoadScene("Menu");
            }
        }
        


        this.GetComponentInChildren<Animator>().SetInteger("Position",currentPosition);
        this.GetComponentInChildren<Animator>().SetBool("Is Dead",dead);
    }

    public void InteractCam()
    {
        if(currentPosition==0)
            {
                currentPosition=1;
            }
            else if(currentPosition==1)
            {
                currentPosition=0;
            }
    }

    public void InteractHide()
    {
        if(currentPosition==0)
            {
                currentPosition=2;
            }
            else if(currentPosition==2)
            {
                currentPosition=0;
            }
    }
}
