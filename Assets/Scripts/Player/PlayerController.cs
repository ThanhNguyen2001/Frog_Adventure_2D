using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    static PlayerController instance;
    public static PlayerController Instance { get => instance; }

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Other " + this.gameObject.name +" has been deleted !");
        }
    }
    #endregion

    [SerializeField] PlayerAnimation playerAnimation;
    public PlayerAnimation PlayerAnimation { get => playerAnimation; }

    [SerializeField] PlayerRD playerRD;
    public PlayerRD PlayerRD { get => playerRD; }

    [SerializeField] PlayerCollision playerCollision;
    public PlayerCollision PlayerCollision { get => playerCollision; }

    [SerializeField] PlayerMove playerMove;
    public PlayerMove PlayerMove { get => playerMove; }

    public StarCtrl starCtrl;

    private void Start()
    {
        this.playerRD = this.transform.Find("ReceiveDamage").GetComponent<PlayerRD>();
    }
}
