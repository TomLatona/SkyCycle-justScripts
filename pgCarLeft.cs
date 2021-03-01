using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pgCarLeft : MonoBehaviour{

    public GameObject car2Prefab;
    public movement move;
    public float respawnTime = 0.025f;

    void Start(){
        StartCoroutine(carSpawns());
    }

    private void spawnCar(float z){ 
        GameObject tmp = 
        Instantiate(car2Prefab, new Vector3(Random.Range(-12,0), 0, z+Random.Range(1,20)), 
        Quaternion.Euler(0,180,0)); //makes car face player
    }

    IEnumerator carSpawns(){
        float z = 115; //first spawn, sets distance at start
        while(z<30000){
            yield return new WaitForSeconds(respawnTime);
            spawnCar(z);
            z+=50; //minimum distance apart on z
            
            if(move.enabled==false){
                z=30000; //on playerCollision stop pg
            } 
        }
    }
}
