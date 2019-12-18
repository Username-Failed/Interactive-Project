using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    
    //LoadGame er kaldet når der trykkes på play knappen
    public void LoadGame() {
        //Loader game scenen som har tallet '1'
        SceneManager.LoadSceneAsync(1);
    }
}
