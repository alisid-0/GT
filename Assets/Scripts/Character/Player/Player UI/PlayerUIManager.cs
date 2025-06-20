using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager instance;

    [Header("NETWORK JOIN")]
    [SerializeField] bool startGameAsClient;

    [HideInInspector] public PlayerUIHudManager playerUIHudManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerUIHudManager = GetComponentInChildren<PlayerUIHudManager>();
    }
    private void Update()
    {
        if (startGameAsClient)
        {
            startGameAsClient = false;
            // Must first shutdown network as host to start as client
            NetworkManager.Singleton.Shutdown();
            // we then start the network as client
            NetworkManager.Singleton.StartClient();
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
