using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjSO kitchenObjSO;
    [SerializeField] private Transform counterTopPoint;

    public void Interact()
    {
        print("Interacted!");
        Transform kitchenObjTransform = Instantiate(kitchenObjSO.prefab, counterTopPoint);
        kitchenObjTransform.localPosition = Vector3.zero;
    }
}
