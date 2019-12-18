using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {
    // Update er kaldet på en gang pr frame
    void Update() {

        //køre en gang når man trykker på escape knappen
        if(Input.GetKeyDown("escape")) {
            SceneManager.LoadSceneAsync(0);
        }

    }
}
