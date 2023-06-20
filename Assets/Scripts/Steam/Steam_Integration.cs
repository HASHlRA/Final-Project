using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam_Integration : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Steamworks.SteamClient.Init(2476960, true);
        }
        catch(System.Exception e)
        {
            Debug.Log(e);
        }
    }

    private void PrintYourName()
    {
        var mySteamId = Steamworks.SteamClient.SteamId;
        Debug.Log(Steamworks.SteamClient.SteamId);
    }

    void Update()
    {
        Steamworks.SteamClient.RunCallbacks();

        //var playername = Steamworks.SteamClient.Name;
        //var playernameid = Steamworks.SteamClient.SteamId;

        //Steamworks.SteamScreenshots.TriggerScreenshot();
    }

    private void OnApplicationQuit()
    {
        Steamworks.SteamClient.Shutdown();
    }


}
