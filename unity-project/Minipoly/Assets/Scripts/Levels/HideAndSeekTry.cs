using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class HideAndSeekTry : NetworkBehaviour
{
    public GameObject body;
    public Color endColor;
    public Transform playerCamera;

    public LayerMask playerMask;
    public float maxDistance = 2;

    private float role;
    public GameObject HideManager;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            HideManager.GetComponent<HideAndSeekManager>().AddPlayer(gameObject);
            print("conect");
        }
        else
        {
            GetComponent<HideAndSeekTry>().enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxDistance, playerMask))
            {
                HuntServer(hit.transform.gameObject, endColor);
            }
        }
    }

    [ServerRpc]
    public void HuntServer(GameObject player, Color color)
    {
        Hunt(player, color);
    }

    [ObserversRpc]
    public void Hunt(GameObject player, Color color)
    {
        player.GetComponent<Renderer>().material.color = color;
    }
}
