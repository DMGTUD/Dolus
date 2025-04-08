using UnityEngine;
using TMPro;

public class NightUIUpdate : MonoBehaviour
{
    public SaveSystem saveFile;
    private int currentNightText;
    public MenuSelectionHilight MSH;


    void Start()
    {
        MSH=GameObject.Find("Test Level").GetComponent<MenuSelectionHilight>();
    }

    void Update()
    {
        if(saveFile.gameStatus.level!=currentNightText);
        {
            if(saveFile.gameStatus.level==0)
            {
                currentNightText=1;
                string temporaryText="Resume:Night "+currentNightText;
                MSH.UpdateOriginalText(temporaryText);
                
            }
            else
            {
                currentNightText=saveFile.gameStatus.level;
                string temporaryText="Resume:Night "+currentNightText;
                MSH.UpdateOriginalText(temporaryText);
            }
            
            
        }

        

    }
    
    
}
