using UnityEngine;

public class TasksMinigameSwitch : MonoBehaviour
{
    public bool minigames;
    public GameObject taskPannel;
    public GameObject minigamePannel;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchMode()
    {
        if (minigames)
        {
            minigames=false;
            taskPannel.SetActive(true);
            minigamePannel.SetActive(false);
        }
        else
        {
            minigames=true;
            taskPannel.SetActive(false);
            minigamePannel.SetActive(true);
        }
    }
}
