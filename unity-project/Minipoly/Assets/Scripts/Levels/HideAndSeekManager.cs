using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class HideAndSeekManager : NetworkBehaviour
{
    public GameObject[] players = new GameObject[2];
    public int seekersNum = 0;
    public override void OnStartClient()
    {
        base.OnStartClient();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayer(GameObject player)
    {
        if (players[0])
        {
            players[1] = player;
        } else
        {
            players[0] = player;
        }
    }

    void DecideRoles()
    {
        for (int i = 0; i < seekersNum; i++)
        {
            int seekerIndex = Random.Range(0, players.Length);
        }
    }
}
