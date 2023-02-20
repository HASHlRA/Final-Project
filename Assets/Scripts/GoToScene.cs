using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string sceneName = "New Scene name here";
    public string uuid; // uuid = universal uniqued identifier

    public bool isAutomatic;
    public bool manualEnter;

    [SerializeField] private int enemiesQuantity;
    [SerializeField] private int enemiesDestroyed;

    private void Start()
    {
        enemiesQuantity = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    private void Update()
    {
        manualEnter = false;

        if (!isAutomatic && Input.GetButtonDown("Door"))
        {
            manualEnter = true;
        }
    }

    // Teleport automático
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && enemiesDestroyed == enemiesQuantity)
        {
            Teleport(other.gameObject.name);
        }
    }

    // Teleport manual
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && enemiesDestroyed == enemiesQuantity)
        {
            Teleport(other.gameObject.name);
        }
    }

    public void EnemyDestroyed()
    {
        enemiesDestroyed += 1;
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
