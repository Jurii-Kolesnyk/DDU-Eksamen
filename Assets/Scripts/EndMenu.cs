using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class EndMenu : NetworkBehaviour
{
    GameObject manager;
    Networker n;
    void Start()
    {
        manager = GameObject.FindWithTag("NetworkManager");
        n = manager.GetComponent<Networker>();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        n.endManager();
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}