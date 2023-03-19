using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    [SerializeField] int maxFruit, fruitsRemaining, fruitCount;

    public int MaxFruit { get => maxFruit; }

    private void Start()
    {
        this.maxFruit = this.transform.childCount;
        fruitsRemaining = maxFruit;
    }

    private void Update()
    {      
        foreach (Transform item in this.transform)
        {
            if (!item.gameObject.activeSelf)
            {
                fruitCount++;
            }
        }
        fruitsRemaining = maxFruit - fruitCount;
        fruitCount = 0;
    }
}
