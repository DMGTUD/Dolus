using UnityEngine;

public class UIStates : MonoBehaviour
{
    [Header("States")]
    public int position;
    //0=office, 1=Computer, 2=hide

    [Header("UI Objects")]
    public GameObject computerOpen;
    public GameObject computerClose;
    public GameObject hide;
    public GameObject unHide;


    void Start()
    {
        position=this.GetComponent<CameraMovement>().currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        position=this.GetComponent<CameraMovement>().currentPosition;

        if (position==0)
        {
            computerOpen.SetActive(true);
            computerClose.SetActive(false);
            hide.SetActive(true);
            unHide.SetActive(false);
        }
        else if (position==1)
        {
            computerOpen.SetActive(false);
            computerClose.SetActive(true);
            hide.SetActive(false);
            unHide.SetActive(false);
        }
        else if (position==2)
        {
            computerOpen.SetActive(false);
            computerClose.SetActive(false);
            hide.SetActive(false);
            unHide.SetActive(true);
        }
    }
}
