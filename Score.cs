using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        float pos = player.position.z/10;
        scoreText.text = pos.ToString("0");
    }
}
