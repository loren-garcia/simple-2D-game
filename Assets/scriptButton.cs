using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptButton : MonoBehaviour {

    public void restartScene() {
        SceneManager.LoadScene("SampleScene");
    }
}
