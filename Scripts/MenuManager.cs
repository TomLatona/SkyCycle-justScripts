using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour{

    void Update()
    {
       if(Input.GetKey("r")){
           Play();
       }
       if(Input.GetKey("q")){
           Application.Quit();
       } 
    }

    void Play(){
        SceneManager.LoadScene("Level02Moto");
    }
}
