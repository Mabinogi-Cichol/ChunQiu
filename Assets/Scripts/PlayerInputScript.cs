using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Doozy.Engine;

public class PlayerInputScript : MonoBehaviour
{
    PlayerInputAction playerInputAction;
    public Bolt.StateMachine playerControllerMachine;
    public PlayerInput playerInput;
    public Vector2 moveVector2;

    public string actionMap;


    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        actionMap = playerInput.currentActionMap.name;
    }

    void Awake()
    {
        playerInputAction = new PlayerInputAction();

        //ActionMap "GamePlay"
        playerInputAction.GamePlay.Move.performed += ctx => moveVector2 = ctx.ReadValue<Vector2>();
        playerInputAction.GamePlay.Move.canceled += ctx => moveVector2 = Vector2.zero;

        playerInputAction.GamePlay.Attack.performed += ctx => playerControllerMachine.TriggerUnityEvent("Attack");
        playerInputAction.GamePlay.Jump.performed += ctx => playerControllerMachine.TriggerUnityEvent("Jump");
        playerInputAction.GamePlay.Defence.started += ctx => playerControllerMachine.TriggerUnityEvent("Defence_started");
        playerInputAction.GamePlay.Defence.canceled += ctx => playerControllerMachine.TriggerUnityEvent("Defence_canceled");
        playerInputAction.GamePlay.Elude.performed += ctx => playerControllerMachine.TriggerUnityEvent("Elude");

        playerInputAction.GamePlay.Menu.performed += ctx => GameEventMessage.SendEvent("Menu");



        //ActionMap "UI"
        playerInputAction.UI.Cancel.performed += ctx => GameEventMessage.SendEvent("Cancel");
        playerInputAction.UI.Menu.performed += ctx => GameEventMessage.SendEvent("Menu");
    }

    void OnEnable()
    {
        //默认唤醒“GamePlay”ActionMap
        playerInputAction.GamePlay.Enable();
    }

    void OnDisable()
    {
        //
        playerInputAction.GamePlay.Disable();
    }


    public void OpenMenu()
    {
        //关闭GamePlay的ActionMap
        playerInputAction.GamePlay.Disable();

        //启用UI的ActionMap
        playerInputAction.UI.Enable();
    }

    public void CloseMenu()
    {
        //关闭UI的ActionMap
        playerInputAction.UI.Disable();

        //启用GamePlay的ActionMap
        playerInputAction.GamePlay.Enable();
    }

}
