using UnityEngine;
using System.Collections;

public class MouseEvent : MonoBehaviour
{
    // 自機オブジェクト
    GameObject player;

    // マウスのスクリーン座標
    Vector3 mouse_screenPoint;

    // マウスと自機の差
    Vector3 offset;

    // マウスがクリックされているかどうか
    bool mouseButton;

    // 初期化処理
    void Start()
    {
        // 自機オブジェクト
        player = GameObject.Find("Player");

        // マウスがクリックされているかどうか
        mouseButton = false;
    }


    // 更新処理
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            // マウスクリックフラグを立てる
            mouseButton = true;

            // マウスの座標取得
            Vector3 mouse_vec = Input.mousePosition;
            mouse_vec.z = 10f;

            // マウス座標を変換
            mouse_screenPoint = GetComponent<Camera>().ScreenToWorldPoint(mouse_vec);

            // マウスとオブジェクトの差を演算
            offset = player.transform.position - mouse_screenPoint;

        }

        //------------------------------------------------------------------
        // マウスが離されたときの処理
        if(Input.GetMouseButtonUp(0))
        {
            // マウスクリックフラグを降ろす
            mouseButton = false;

        }

        //------------------------------------------------------------------
        // マウスクリックフラグが立っていたときの処理
        if (mouseButton == true)
        {
            // マウスの座標取得
            Vector3 mouse_vec = Input.mousePosition;
            mouse_vec.z = 10f;

            // マウス座標を変換
            mouse_screenPoint = GetComponent<Camera>().ScreenToWorldPoint(mouse_vec);

            //上記にクリックした場所の差を足すことによって、オブジェクトを移動する座標位置を求める
            Vector3 currentPosition = mouse_screenPoint + offset;

            //オブジェクトの位置を変更する
            player.transform.position = currentPosition;
        }
    }
}