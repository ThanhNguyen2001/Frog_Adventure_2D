using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance;}

    [SerializeField] GameObject player;
    public GameObject Player { get => player; }

    private void Awake()
    {
        if(instance == null) instance = this;
        else
        {
            Debug.LogWarning("Another '" + this.gameObject.name + "' has been deleted");
            Destroy(this.gameObject);
        }            
    }

    private void Start()
    {
        this.player = GameObject.Find("Player");
    }
}
