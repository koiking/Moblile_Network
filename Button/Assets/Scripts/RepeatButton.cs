using UnityEngine;
using System.Collections;

public class RepeatButton : MonoBehaviour
{
    bool push = false; // ボタンが押されているか？

    public void StartPush()
    {
        push = true;

        //ここにやらせたい処理を書きます
        Debug.Log("押した！");
    }

    public void StopPush()
    {
        push = false;
        //ここにやらせたい処理を書きます
        Debug.Log("離されました！");
    }

    void Update()
    {
        if (push)
        {
            //ここにやらせたい処理を書きます
            Debug.Log("押されてます！");
        }
    }
}
