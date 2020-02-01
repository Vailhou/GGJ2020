using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 200f;

    private KeyCode
       _up = KeyCode.UpArrow,
       _down = KeyCode.DownArrow,
       _left = KeyCode.LeftArrow,
       _right = KeyCode.RightArrow;


    void Update()
    {

        if (Input.GetKey(_up))
        {
            transform.Translate(0, Time.deltaTime * -_speed, 0);
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
        }

        if (Input.GetKey(_down))
        {
            transform.Translate(0, Time.deltaTime * -_speed, 0);
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
        if (Input.GetKey(_left))
        {
            transform.Translate(0, Time.deltaTime * -_speed, 0);
            transform.eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
        }
        if (Input.GetKey(_right))
        {
            transform.Translate(0, Time.deltaTime * -_speed, 0);
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
        }
    }
}
