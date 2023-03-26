using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] string sortingLayer;
    void Start()
    {
        this.GetComponent<MeshRenderer>().sortingLayerName = sortingLayer; 
    }


    private void OnDrawGizmos()
    {
        this.GetComponent<MeshRenderer>().sortingLayerName = sortingLayer;
    }
}
