using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class GoToScene : MonoBehaviour
{
    public string sceneName = "New Scene name here";
    public string uuid; // uuid = universal uniqued identifier

    public bool isAutomatic;
    public bool manualEnter;

    [SerializeField] public int enemiesQuantity;
    [SerializeField] public int enemiesDestroyed;

    GameObject[] enemies;
    public TMP_Text enemyCountText;


    private void Start()
    {
        enemiesQuantity = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCountText = GameObject.Find("Left").GetComponent<TMP_Text>();
    }

    public void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCountText.text = "Enemies : " + enemies.Length.ToString();

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
                //Pause.sceneName1 = sceneName;
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
