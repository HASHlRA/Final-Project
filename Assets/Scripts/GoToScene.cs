using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string sceneName = "New Scene name here";
    public string uuid; // uuid = universal uniqued identifier

    public bool isAutomatic;
    private bool manualEnter;
    private void Update()
    {
        if (!isAutomatic && manualEnter)
        {
            manualEnter = Input.GetButtonDown("Door");
        }
    }

    // Teleport automático
    private void OnTriggerEnter2D(Collider2D other)
    {
        Teleport(other.name);
    }

    // Teleport manual
    private void OnTriggerStay2D(Collider2D other)
    {
        Teleport(other.name);
    }

    private void Teleport(string objName)
    {
        if (objName == "Player")
        {
            if (isAutomatic || (!isAutomatic && manualEnter))
            {
                FindObjectOfType<PlayerMovement>().nextUuid = uuid;
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
