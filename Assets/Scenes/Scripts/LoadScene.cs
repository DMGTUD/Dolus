using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string levelToLoad;

    public void LoadButton()
    {
        SceneManager.LoadScene(levelToLoad);
    } 
}
