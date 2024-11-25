    using UnityEngine;
    using TMPro;
    using UnityEngine.SceneManagement;

public class PressedKeep : MonoBehaviour
{
    public float fill;
    public float full;
    

    void Start()
    {
        fill=0;
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
            SceneManager.LoadScene("Win");
        }

    }   
}
