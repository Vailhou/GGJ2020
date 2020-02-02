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
        Vector3 vector = Vector3.zero;

        vector.x = -Input.GetAxis("Horizontal");
        vector.y = Input.GetAxis("Vertical");

        if (vector.magnitude == 0) return;

        Vector3 dir = new Vector3(0, 0, vector.x * 90f);
        var angle = Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle + 180);

        transform.Translate(0, Time.deltaTime * -_speed, 0);
    }
}
