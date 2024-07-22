using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjSO kitchenObjSO;

    public override void Interact(PlayerController player)
    {
        if (!player.HasKitchenObject())
        {
            Transform kitchenObjTransform = Instantiate(kitchenObjSO.prefab);
            kitchenObjTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
