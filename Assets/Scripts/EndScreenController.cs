using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Return)) Application.Quit();
    }
}
