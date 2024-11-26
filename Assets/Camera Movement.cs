using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    
    public int targetPosition;
    public int currentPosition;
    public bool hidden;
    public bool dead;
    public bool timesUp;

    public GameObject OfficeHubA;
    public GameObject OfficeHubB;
    public GameObject CamHud;
    public GameObject HideHud;
    
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
        

        this.GetComponentInChildren<Animator>().SetInteger("Position",currentPosition);
        this.GetComponentInChildren<Animator>().SetBool("Is Dead",dead);
    }

    public void InteractCam()
    {
        if(currentPosition==0)
            {
                currentPosition=1;
                CamHud.SetActive(true);
                OfficeHubA.SetActive(false);
                OfficeHubB.SetActive(false);
            }
        else if(currentPosition==1)
            {
                currentPosition=0;
                CamHud.SetActive(false);
                OfficeHubA.SetActive(true);
                OfficeHubB.SetActive(true);
            }
    }

    public void InteractHide()
    {
        if(currentPosition==0)
            {
                currentPosition=2;
                HideHud.SetActive(true);
                OfficeHubA.SetActive(false);
                OfficeHubB.SetActive(false);
            }
        else if(currentPosition==2)
            {
                currentPosition=0;
                HideHud.SetActive(false);
                OfficeHubA.SetActive(true);
                OfficeHubB.SetActive(true);
            }
    }
}
