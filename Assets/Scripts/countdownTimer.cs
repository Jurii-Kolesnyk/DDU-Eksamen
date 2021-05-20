using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


public class countdownTimer : NetworkBehaviour
{
    [SyncVar]
    public float currentTime = 0f;
    public float startingTime = 3f;
    public Text countdownText;
    GameObject manager;
    Networker n;
    void Start()
    {
        currentTime = startingTime;
        manager = GameObject.FindWithTag("NetworkManager");
        n = manager.GetComponent<Networker>();
    }

    void Update()
    {
        startTimer();
    }
    public void startTimer()
    {
        if (n.hasEntered == false)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                gameObject.SetActive(false);
                if (currentTime == 0)
                {
                    n.indZero = true;
                }
            }
        }
    }
}
