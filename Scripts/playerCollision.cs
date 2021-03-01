using UnityEngine;

public class playerCollision : MonoBehaviour {

	public movement mov;
	public float delay = 0.5f;
	public GameObject playa;
	public float powerUpTime = 0.5f;

	void OnCollisionEnter (Collision collisionInfo) { 
		if (collisionInfo.collider.tag == "Obstacle"){ 
			mov.enabled = false;
			float playerFinalPosition = playa.transform.position.z/10;

			FindObjectOfType<AudioManager>().Play("PlayerDeath");
			FindObjectOfType<AudioManager>().Stop("Music");
			FindObjectOfType<AudioManager>().Stop("Engine");

			Invoke("removePlayer", delay);
			FindObjectOfType<GameManager>().CompleteLevel(playerFinalPosition);
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

	void FixedUpdate(){ //checks player position on y, end game if too high or low
		if(playa.transform.position.y < -1 || playa.transform.position.y > 10){
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