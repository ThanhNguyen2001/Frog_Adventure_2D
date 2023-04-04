using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    [SerializeField] int maxFruit, fruitCount;
    public int MaxFruit { get => maxFruit; }
    public int FruitCount { get => fruitCount; }

    private void Start()
    {
        this.maxFruit = this.transform.childCount;
    }

    public void SetFruitCount()
    {
        fruitCount++;
    }
}
