using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance { get => instance;}

    private void Awake()
    {
        if(instance == null) instance = this;
        else
        {
            Debug.LogWarning("Other '" + this.gameObject.name + "' has been deleted");
            Destroy(this.gameObject);
        }            
    }
    #endregion

    [SerializeField] GameObject player;
    public GameObject Player { get => player; }

    [SerializeField] AnimationCtrl animationCtrl;
    public AnimationCtrl AnimationCtrl { get => animationCtrl; }


    private void Start()
    {
        this.player = GameObject.Find("Player");
        this.animationCtrl = GameObject.Find("AnimatorCtrl").GetComponent<AnimationCtrl>();
    }
}
