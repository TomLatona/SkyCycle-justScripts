using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAllCollider : MonoBehaviour {
    
    void OnTriggerEnter (Collider col) { 
        if (col.gameObject.tag == "Obstacle"){
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "road"){
            Destroy(col.gameObject);
        }
    }
}
