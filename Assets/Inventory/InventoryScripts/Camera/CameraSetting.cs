using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [Header("设置Cinemachine相机")]
    public Cinemachine.CinemachineVirtualCamera mainCamera;
    public Cinemachine.CinemachineVirtualCamera menuCamera;

    [Header("设置CheckMenu")]
    public GameObject checkMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SwitchMenuCamera()
    {
        menuCamera.gameObject.SetActive(true);
        //mainCamera.gameObject.SetActive(false);
    }

    public void SwitchMainCamera()
    {
        //mainCamera.gameObject.SetActive(true);
        menuCamera.gameObject.SetActive(false);
    }
}
