using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour 
{

	public Text hs; //displays high score on screen

    void Start()
    {
        hs.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("0");
    }

    public void setNewHS(float finalScore) 
    { 	//update high score if final score is greater than current high score
    	if(finalScore > PlayerPrefs.GetFloat("HighScore", 0)) 
    	{
    		PlayerPrefs.SetFloat("HighScore", finalScore);
    		hs.text = finalScore.ToString("0");
    	}
    }

    public void Reset()
    {	//called from game over screen if player presses "G"
    	PlayerPrefs.DeleteKey("HighScore");
    }
}
