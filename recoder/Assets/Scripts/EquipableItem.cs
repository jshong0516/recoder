using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class EquipableItem : MonoBehaviour
{

    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && 
        InventorySystem.Instance.isOpen == false && 
        CraftingSystem.Instance.isOpen == false &&
        SelectionManager.Instance.handIsVisible == false)
        {

            GameObject selectedTree = SelectionManager.Instance.selectedTree;

            if(selectedTree != null)
            {
                selectedTree.GetComponent<ChoppableTree>().GetHit();
            }



            animator.SetTrigger("hit");
        }
    }



    public void GetHit()
    {
    
        GameObject selectedTree = SelectionManager.Instance.selectedTree;

        if(selectedTree != null)
        {
            selectedTree.GetComponent<ChoppableTree>().GetHit();
        }
    }
}
