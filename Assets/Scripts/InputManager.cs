using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singleton
    static InputManager instance;
    public static InputManager Instance { get => instance;}

    private void Awake()
    {
        if(instance == null) instance = this;
        else
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Other '" + this.gameObject.name + "' has been deleted !");
        }
    }
    #endregion


    [SerializeField] bool pause;
    public bool Pause { get => pause; }

    [SerializeField] bool jump;
    public bool Jump { get => jump; }

    [SerializeField] float movementX;
    public float MovementX { get => movementX; }

    [SerializeField] float movementY;
    public float MovementY { get => movementY; }

    void Update()
    {
        this.InputController();
    }

    void InputController()
    {
       this.pause = Input.GetKeyDown(KeyCode.Escape);
       this.jump = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
       this.movementX = Input.GetAxisRaw("Horizontal");
       this.movementY = Input.GetAxisRaw("Vertical");
    }
}
