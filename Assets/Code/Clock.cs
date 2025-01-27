using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public float timer;
    public bool uploadBegun;
    public GameObject Player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(timer==0)
        {
            print("Please select time");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(uploadBegun)
        {
            CountDown();
        }
        TimeText();
        if(timer<0)
        {
            Player.GetComponent<CameraMovement>().timesUp = true;
        }
    }

    public void CountDown()
    {
        timer-=Time.deltaTime;
        
    }

    public void beginUpload()
    {
        uploadBegun = true;
    }

    public void TimeText()
    {
        int minutes = (int) timer / 60 ;
        int seconds = (int) timer - 60 * minutes;
        int milliseconds = (int) (1000 * (timer - minutes * 60 - seconds));
        string millisecondsFix;
        if(milliseconds<10)
        {
            millisecondsFix=("000");
        }
        else if(milliseconds<100)
        {
            millisecondsFix=("0"+milliseconds);
        }
        else
        {
            millisecondsFix=(milliseconds.ToString());
        }

        string secondsFix;
        
        if (seconds<1)
        {
            secondsFix=("00");
        }
        
        else if(seconds<10)
        {
            secondsFix=("0"+seconds);
        }
        else
        {
            secondsFix=(seconds.ToString());
        }   

        string minutesFix;
        if(minutes<1)
        {
            minutesFix=("00");
        }
        else if(minutes<10)
        {
            minutesFix=("0"+minutes);
        }
        else
        {
            minutesFix=(minutes.ToString());
        }


        this.GetComponent<TextMeshProUGUI>().text = this.GetComponent<TextMeshProUGUI>().text = (minutesFix+":"+secondsFix+":"+millisecondsFix.Substring(0,millisecondsFix.Length-1));
    }
}
