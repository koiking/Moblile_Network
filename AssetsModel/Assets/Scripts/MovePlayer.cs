using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
    // 移動速度
    public float X_Speed = 1;
    public float Z_Speed = 1;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 垂直方向入力
        float vertical = Input.GetAxis("Vertical");
        // 水平方向入力
        float horizontal = Input.GetAxis("Horizontal");
        // ↑
        if (Input.GetKey("up"))
        {
            transform.Translate(0, 0, vertical * Z_Speed);
        }
        // ↓
        if (Input.GetKey("down"))
        {
            transform.Translate(0, 0, vertical * Z_Speed);
        }
        // ←
        if (Input.GetKey("left"))
        {
            transform.Translate(horizontal * X_Speed, 0, 0);
        }
        // →
        if (Input.GetKey("right"))
        {
            transform.Translate(horizontal * X_Speed, 0, 0);
        }
    }
}