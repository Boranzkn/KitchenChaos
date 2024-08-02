using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
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
            kitchenObjSOList.Add(kitchenObjSO);

            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs { kitchenObjectSO = kitchenObjSO});

            return true;
        }
    }

    public List<KitchenObjSO> GetKitchenObjectSOList()
    {
        return kitchenObjSOList;
    }
}