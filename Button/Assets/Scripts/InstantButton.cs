using UnityEngine;
using System.Collections;

public class InstantButton : MonoBehaviour
{
    bool push = false; // ボタンが押されているか？

    public void StartPush()
    {
        push = true;

        //ここにやらせたい処理を書きます
        Debug.Log("瞬間！");
    }
}