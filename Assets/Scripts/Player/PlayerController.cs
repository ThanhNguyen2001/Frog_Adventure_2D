using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    static PlayerController instance;
    public static PlayerController Instance { get => instance; }

    [SerializeField] AnimationCtrl animationCtrl;
    public AnimationCtrl AnimationCtrl { get => animationCtrl; }

    [SerializeField] Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] AnimationCtrl.AnimationState stateAnim = AnimationCtrl.AnimationState.Idle;
    public AnimationCtrl.AnimationState StateAnim { get => stateAnim; }

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

        //SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }

    private void Start()
    {
        this.animationCtrl = GameObject.Find("AnimatorCtrl").GetComponent<AnimationCtrl>();
        this.playerRD = this.transform.Find("ReceiveDamage").GetComponent<PlayerRD>();
        //this.animator = GameObject.Find("Model").GetComponent<Animator>();
    }

    private void Update()
    {
        animationCtrl.GetAnimation(stateAnim, animator);
    }

    public void setStateAnim(AnimationCtrl.AnimationState stateAnim)
    {
        this.stateAnim = stateAnim;
    }

}
