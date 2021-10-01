using UnityEngine;

public class playerCollision : MonoBehaviour {

	public movement mov;
	public float delay = 0.5f;
	public GameObject playa;
	public float powerUpTime = 0.5f;

	void OnCollisionEnter (Collision collisionInfo) { 
		if (collisionInfo.collider.tag == "Obstacle"){ 
			Debug.Log("collision occured");
			//remove constraints on player rigidbody y axis when collision with car
			playa.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			
			mov.enabled = false;
			float playerFinalPosition = playa.transform.position.z/10;

			FindObjectOfType<AudioManager>().Play("PlayerDeath");
			FindObjectOfType<AudioManager>().Stop("Music");
			FindObjectOfType<AudioManager>().Stop("Engine");

			Invoke("removePlayer", delay);
			FindObjectOfType<GameManager>().CompleteLevel(playerFinalPosition);
			FindObjectOfType<highScore>().setNewHS(playerFinalPosition);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "SpeedPowerUp"){
			//mov.forwardForce=5000;
			//WaitForSeconds(powerUpTime);
			mov.forwardForce=1600;
		} 
	}

	void removePlayer(){
		playa.SetActive(false);
	}

	void FixedUpdate()
	{ 	//checks if player falls off side of road
		if(playa.transform.position.x < -15 || playa.transform.position.x > 16 || playa.transform.position.y > 10)
		{	//removes position constraints if player falls off the side of road
			playa.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			Debug.Log("offroad");

			mov.enabled = false;
			float playerFinalPosition = playa.transform.position.z/10;

			FindObjectOfType<AudioManager>().Play("HighOrLow");
			FindObjectOfType<AudioManager>().Stop("Music");
			FindObjectOfType<AudioManager>().Stop("Engine");

			Invoke("removePlayer", delay);
			FindObjectOfType<GameManager>().CompleteLevel(playerFinalPosition);
		}
		
	}
}