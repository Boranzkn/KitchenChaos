using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjSO plateKitchenObjSO;

    private float spawnPlateTimer;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawnAmount;
    private int platesSpawnAmountMax = 4;

    private void Update()
    {
        if (!IsServer)
        {
            return;
        }

        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;

            if (GameManager.Instance.IsGamePlaying() && platesSpawnAmount < platesSpawnAmountMax)
            {
                SpawnPlateServerRpc();
            }
        }
    }

    [ServerRpc]
    private void SpawnPlateServerRpc()
    {
        SpawnPlateClientRpc();
    }

    [ClientRpc]
    private void SpawnPlateClientRpc()
    {
        platesSpawnAmount++;

        OnPlateSpawned?.Invoke(this, EventArgs.Empty);
    }

    public override void Interact(PlayerController player)
    {
        if (!player.HasKitchenObject())
        {
            if (platesSpawnAmount > 0)
            {
                KitchenObject.SpawnKitchenObject(plateKitchenObjSO, player);

                InteractLogicServerRpc();
            }
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void InteractLogicServerRpc()
    {
        InteractLogicClientRpc();
    }

    [ClientRpc]
    private void InteractLogicClientRpc()
    {
        platesSpawnAmount--;

        OnPlateRemoved?.Invoke(this, EventArgs.Empty);
    }
}
