using UnityEngine;

public class movement : MonoBehaviour{
    
    public Rigidbody rb;
    public float forwardForce = 1700f;
    public float sidwaysForce = 5500f;

    void FixedUpdate(){
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); //sync with framerate(Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidwaysForce * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidwaysForce * Time.deltaTime, 0, 0); 
        }  
    }
}
