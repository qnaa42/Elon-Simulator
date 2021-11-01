using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListenIn : MonoBehaviour
{

    AudioClip microphoneInput;
    bool microphoneInitialized;
    public float sensitivity;
    public bool doIt;
    public Text myText; 
    public float level;

    void Awake()
    {
        //init microphone input
        if (Microphone.devices.Length>0){
            microphoneInput = Microphone.Start(Microphone.devices[0],true,999,44100);
            microphoneInitialized = true;
	    }
    }

    // Start is called before the first frame update
  
        // Get list of Microphone devices and print the names to the log
    void Start()
    {
        level = 0.0f;
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

         
    

    // Update is called once per frame
    void Update()
        {




            //get mic volume
        int dec = 128;
        float[] waveData = new float[dec];
        int micPosition = Microphone.GetPosition(null)-(dec+1); // null means the first microphone
        microphoneInput.GetData(waveData, micPosition);
        
        // Getting a peak on the last 128 samples
        float levelMax = 0;
            for (int i = 0; i < dec; i++) {
                float wavePeak = waveData[i] * waveData[i];
                if (levelMax < wavePeak) {
                    levelMax = wavePeak;
                }
            }
         level = Mathf.Sqrt(Mathf.Sqrt(levelMax));
        //For Debugging
       // Debug.Log(level);
       
       // Blocked out for the time being
        /*
            if (level>sensitivity && !doIt){
                DoIt ();
                doIt = true;
            }
            if (level<sensitivity && doIt)
            {

                doIt = false;
            }

         */
        // Show the input level on screen
          myText.text = level.ToString();
        }


    void DoIt(){

        
    }

    
}



