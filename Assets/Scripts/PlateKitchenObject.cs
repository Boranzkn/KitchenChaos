using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjSO kitchenObjectSO;
    }

    [SerializeField] private List<KitchenObjSO> validKitchenObjSOs;

    private List<KitchenObjSO> kitchenObjSOList;

    protected override void Awake()
    {
        base.Awake();
        kitchenObjSOList = new List<KitchenObjSO>();
    }

    public bool TryAddIngredient(KitchenObjSO kitchenObjSO)
    {
        if (!validKitchenObjSOs.Contains(kitchenObjSO))
        {
            return false;
        }

        if (kitchenObjSOList.Contains(kitchenObjSO))
        {
            return false;
        }
        else
        {
            AddIngredientServerRpc(KitchenGameMultiplayer.Instance.GetKitchenObjectSOIndex(kitchenObjSO));

            return true;
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void AddIngredientServerRpc(int kitchenObjectSOIndex)
    {
        AddIngredientClientRpc(kitchenObjectSOIndex);
    }

    [ClientRpc]
    private void AddIngredientClientRpc(int kitchenObjectSOIndex)
    {
        KitchenObjSO kitchenObjSO = KitchenGameMultiplayer.Instance.GetKitchenObjectSOFromIndex(kitchenObjectSOIndex);

        kitchenObjSOList.Add(kitchenObjSO);

        OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs { kitchenObjectSO = kitchenObjSO });
    }

    public List<KitchenObjSO> GetKitchenObjectSOList()
    {
        return kitchenObjSOList;
    }
}