using UnityEngine;

public class AnimationUpdate : MonoBehaviour
{
    public GameObject upload;
    public float glitch;
    public bool scan;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*glitch=upload.GetComponent<PressedKeep>().fill/upload.GetComponent<PressedKeep>().full;
        GetComponent<Animator>().SetLayerWeight(1,glitch);
        GetComponent<Animator>().SetFloat("Glitch",1);*/


    }

    public void Activate()
    {
        GetComponent<Animator>().SetBool("Wake",true);
    }
}
