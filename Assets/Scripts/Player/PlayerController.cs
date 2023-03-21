using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    static PlayerController instance;
    public static PlayerController Instance { get => instance; }

    [SerializeField] PlayerAnimation playerAnimation;
    public PlayerAnimation PlayerAnimation { get => playerAnimation; }

    [SerializeField] PlayerRD playerRD;
    public PlayerRD PlayerRD { get => playerRD; }

    [SerializeField] PlayerCollision playerCollision;
    public PlayerCollision PlayerCollision { get => playerCollision; }

    [SerializeField] PlayerMove playerMove;  
    public PlayerMove PlayerMove { get => playerMove; }

    public StarCtrl starCtrl;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Another PlayerController has been deleted !");
        }
    }

    private void Start()
    {
        this.playerRD = this.transform.Find("ReceiveDamage").GetComponent<PlayerRD>();
    }
}
