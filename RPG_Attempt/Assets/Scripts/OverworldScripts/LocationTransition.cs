using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationTransition : MonoBehaviour
{
    [SerializeField]
    int sceneToLoad = 0;
    public void GoToConnectedScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
