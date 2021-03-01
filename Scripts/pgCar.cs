using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pgCar : MonoBehaviour{

    public GameObject carPrefab;
    public movement move;
    public float respawnTime = 0.025f;

    void Start(){
        StartCoroutine(carSpawns());
    }

    private void spawnCar(float z){ 
        GameObject tmp = 
        Instantiate(carPrefab, new Vector3(Random.Range(1,13), 0, z+Random.Range(1,20)), 
        Quaternion.identity);
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
