using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    public int[] indexOpen;

    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 0);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (indexOpen[i] > levelAt)
                lvlButtons[i].interactable = false;
        }
    }

}
