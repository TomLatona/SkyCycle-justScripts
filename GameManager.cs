using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float restartDelay = 1f;
    public GameObject gameOverUI;
    public GameObject fs;
    bool gameOv=false;

    void Restart(){
        //restart current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel(float playerFinalPosition){ //activates on collision
        Invoke("gameOverUIcont", restartDelay); //delay after collision before gameover screen
        fs.GetComponent<finalScore>().scoreNumber = playerFinalPosition;
    }

    void gameOverUIcont(){
        //enable game over ui, sets gameOv bool to true
        gameOverUI.SetActive(true);
        gameOv = true;
    }

    public void FixedUpdate(){
        if(gameOv==true){
            if (Input.GetKey("r")){
                Restart();
            }
            if(Input.GetKey("q")){
                SceneManager.LoadScene("MenuLevel");
            }
        }
    }
}
