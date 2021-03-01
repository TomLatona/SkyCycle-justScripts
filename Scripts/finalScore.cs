using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalScore : MonoBehaviour
{
    public Text finSco;
    public float scoreNumber;

    void Start(){
        finSco.text = scoreNumber.ToString("0");
    }  
} 
