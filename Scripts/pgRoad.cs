using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pgRoad : MonoBehaviour{

    public GameObject roadPrefab;
    public movement movem;
    public float respawnTime = 0.1f;

    void Start(){
        StartCoroutine(roadSpawns());  
    }

    private void spawnRoad(float z){ 
        GameObject tmp = 
        Instantiate(roadPrefab, new Vector3(0, 0, z+90), 
        Quaternion.Euler(-90,90,0));
    }

    IEnumerator roadSpawns(){
        float z = 35;
        while(z<30000){
            yield return new WaitForSeconds(respawnTime);
            spawnRoad(z);
            z+=90;
            if(movem.enabled==false){ //stop spawning if player crashes
                z=30000;
            }
        }
    }
}
