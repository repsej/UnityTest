using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : Singleton<InputController>
{
    void Start() { }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ScoreboardController.GetInstance().AddScore(10);
        }
    }
}
