using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameTimer : MonoBehaviour
{
    public float timeStart;
    public Text timerText;
    public Text timerEnd;
    
    
    public int min = 0;

    public GameObject menu;
    public GameObject pazl;

    public  Text scoreEnd;
    public  Text score;

   
    
  

    bool timerRun = false;
    
    void Start()
    {
       timerText.text = timeStart.ToString("F0");
    }

    
    void Update()
    {   
        if(timerRun == true)
        {
            timeStart += Time.deltaTime;
            
            if(timeStart >= 60)
            {
                timeStart = 0;
                min++;
                
            }
            if(min >= 60 )
            {
                min = 0;
            }
            if(timeStart > 9.1f)
            {
                timerText.text ="0"+min +":"+ timeStart.ToString("F0");
            }
            else if(min >= 10 && timeStart > 9.1f)
            {
                timerText.text =min +":"+ timeStart.ToString("F0");
            }
            else if(min >= 10)
            {
                timerText.text = min +":"+ timeStart.ToString("F0");
            }
            else
            {
               timerText.text ="0"+min +":0"+ timeStart.ToString("F0"); 
            }
            
            if(CardCollector.endGame){
                timeStart = 0;
                timerRun = !timerRun;
                timerEnd.text = timerText.text;
                timerText.text = "00:00";

                
                
                menu.SetActive(true);
                pazl.SetActive(true);

                scoreEnd.text = score.text;
                score.text = "0";

            }
            
        }
    }
    public void buttonTimer()
    {
        timerRun = !timerRun;
    }


}
