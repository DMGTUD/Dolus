using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class CameraSwitch : MonoBehaviour
{
    
    public int activeCam;
    public GameObject videoFeed;
    public bool hasChanged;
    public List<Material> cameras = new List<Material>();

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeCam=1;
    }

    // Update is called once per frame
    void Update()
    {
        string camText;
        if (activeCam<10)
        {
            camText = ("0"+activeCam);
        }
        else if (activeCam==0)
        {   
            camText = ("00");
        }
        else
        {
            camText=(activeCam.ToString());
        }
        this.GetComponent<TextMeshProUGUI>().text=("CAM "+ camText);
        
        if(hasChanged)
        {
            videoFeed.GetComponent<UnityEngine.UI.Image>().material = cameras[activeCam-1];
            hasChanged=false;
            //Debug.Log("Yousa");
        }
        
        

        

    }

    public void switchLeft()
    {
        activeCam--;
        if (activeCam==0)
        {
            activeCam=3;
        }
        hasChanged=true;

    }

    public void switchRight()
    {
        activeCam++;
        if(activeCam==4)
        {
            activeCam=1;
        }
        hasChanged=true;
    }
}
