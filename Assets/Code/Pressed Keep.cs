    using UnityEngine;
    using TMPro;
    using UnityEngine.SceneManagement;

public class PressedKeep : MonoBehaviour
{
    public float fill;
    public float full;
    private GameObject saveHandler;
    

    void Start()
    {
        fill=0;
        saveHandler=GameObject.Find("Save Handler");
        if(saveHandler.GetComponent<SaveSystem>().gameStatus.level==0)
        {
            saveHandler.GetComponent<SaveSystem>().AddLevel();
        }
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            fill+=Time.deltaTime;
            this.transform.GetComponentInChildren<TextMeshProUGUI>().text = ((int)(fill/full*100)+"%");
        }

        if(fill/full*100>=100)
        {
            saveHandler.GetComponent<SaveSystem>().AddLevel();
            SceneManager.LoadScene("Menu");
        }

    }   
}
