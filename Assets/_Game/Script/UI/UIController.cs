using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField] GameObject joyStick;
    [SerializeField] GameObject mainMenu;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DisableAll();
        mainMenu.SetActive(true);
    }

    public void ShowJoyStick()
    {
        DisableAll();
        joyStick.SetActive(true);
    }

    public void DisableAll()
    {
        joyStick.SetActive(false);
        mainMenu.SetActive(false);
    }
}
