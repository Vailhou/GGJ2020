using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    Animation
        idleAnim,
        walkAnim;

    private float _speed = 2f;
    private float _horizontalMove;
    private float _verticalMove;

    private KeyCode
       _up = KeyCode.UpArrow,
       _down = KeyCode.DownArrow,
       _left = KeyCode.LeftArrow,
       _right = KeyCode.RightArrow;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 vector = Vector3.zero;

        _horizontalMove = -Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");

        vector.x = _horizontalMove;
        vector.y = _verticalMove;

        animator.SetFloat("speed", Mathf.Abs(_horizontalMove) + Mathf.Abs(_verticalMove));

        if (vector.magnitude == 0) return;

        Vector3 dir = new Vector3(0, 0, vector.x * 90f);
        var angle = Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle + 180);

        transform.Translate(0, Time.deltaTime * -_speed, 0);


    }
}
