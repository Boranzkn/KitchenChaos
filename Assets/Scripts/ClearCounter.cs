using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjSO kitchenObjSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public void Interact(PlayerController player)
    {
        if (kitchenObject == null)
        {
            Transform kitchenObjTransform = Instantiate(kitchenObjSO.prefab, counterTopPoint);
            kitchenObjTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            kitchenObject.SetKitchenObjectParent(player);
        }
    }

    public Transform GetKitchenObjFollowTransform() {  return counterTopPoint;  }

    public void SetKitchenObject(KitchenObject kitchenObject) {  this.kitchenObject = kitchenObject;  }

    public KitchenObject GetKitchenObject() {  return kitchenObject;  }

    public void ClearKitchenObject() {  kitchenObject = null;  }

    public bool HasKitchenObject() {  return kitchenObject != null; }
}
