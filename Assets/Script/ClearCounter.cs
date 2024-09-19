using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IkitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform CounterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool Testing;
    private KitchenObject kitchenObject;


    private void Update()
    {
        if (Testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetKitchenObjectParent(secondClearCounter);
                Debug.Log("KitchenObject moved to second clear counter.");
            }
            else
            {
                Debug.Log("No kitchenObject to move.");
            }
        }
    }


    public void Interact(Player player)
    {


        if (kitchenObject == null)
        {
            // Jika kitchenObject belum ada, instantiate baru
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, CounterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
            Debug.Log("KitchenObject placed on counter.");
        }
        else
        {
            //Give the object to Player
            kitchenObject.SetKitchenObjectParent(player);

        }
    }


    public Transform GetKitchenObjectFollowTransform()
    {
        return CounterTopPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }


}
