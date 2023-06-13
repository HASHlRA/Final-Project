using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneStart : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Pause>().StartScene();
    }

}
