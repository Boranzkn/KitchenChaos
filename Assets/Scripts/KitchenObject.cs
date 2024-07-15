using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjSO kitchenObjSO;

    public KitchenObjSO GetKitchenObjSO() 
    {
        return kitchenObjSO;
    }
}
