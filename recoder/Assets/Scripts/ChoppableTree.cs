using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class ChoppableTree : MonoBehaviour
{
    public bool playerInRange;
    public bool canBeChopped;

    public float treeMaxHealth;
    public float treeHealth;

    private bool isHitCooldown = false;// not tutorial

    private void Start()
    {
        treeHealth = treeMaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }


    public void GetHit()
    {
        if (isHitCooldown) return;
        StartCoroutine(hit());
    }

    public IEnumerator hit()
    {
        isHitCooldown = true;
        treeHealth -= 1;
        yield return new WaitForSeconds(0.6f);
        isHitCooldown = false;
        
    }


    private void Update()
    {
        if(canBeChopped)
        {
            GlobalState.Instance.resourceHealth = treeHealth;
            GlobalState.Instance.resourceMaxHealth = treeMaxHealth;
        }
    }


}
