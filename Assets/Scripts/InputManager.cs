using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    static InputManager instance;
    public static InputManager Instance { get => instance;}

    [SerializeField] bool jump;
    public bool Jump { get => jump; }

    [SerializeField] float movementX;
    public float MovementX { get => movementX; }

    [SerializeField] float movementY;
    public float MovementY { get => movementY; }

    private void Awake()
    {
        if(instance == null) instance = this;
        else
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Another '" + this.gameObject.name + "' has been deleted !");
        }
    }

    void Update()
    {
        this.InputController();
    }

    void InputController()
    {
       this.jump = Input.GetKeyDown(KeyCode.Space);
       this.movementX = Input.GetAxisRaw("Horizontal");
       this.movementY = Input.GetAxisRaw("Vertical");
    }
}
