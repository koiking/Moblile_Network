using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    // Spaceshipコンポーネント
    Doll doll;

    //// 右移動限界値
    //public float rightMostPos = Screen.width / 5 * 4;
    //// 左移動限界値
    //public float leftMostPos = Screen.width / 5;

    public float repeatTime = 3;

    public int directionMove = 1;

    private bool firstRepeat = false;
    
    IEnumerator Start ()
    {
        // Spaceshipコンポーネントを取得
        doll = GetComponent<Doll>();

        // ローカル座標のY軸のマイナス方向に移動する
        doll.Move(transform.right * directionMove);

        // canShotがfalseの場合、ここでコルーチンを終了させる
        if (doll.canShot == false)
        {
            yield break;
        }

        while(true)
        {
            // 子要素を全て取得する
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);

                // ShotPositionの位置/角度で弾を撃つ
                doll.Shot(shotPosition);
            }

            // shotDelay秒待つ
            yield return new WaitForSeconds(doll.shotDelay);
        }
  
    }

    //// Use this for initialization
    //void Start()
    //{
    //    // Spaceshipコンポーネントを取得
    //    spaceship = GetComponent<Spaceship>();

    //    // ローカル座標のY軸のマイナス方向に移動する
    //    spaceship.Move(transform.up * -1);

    //}
   
    // Update is called once per frame

    float elapsedTime;
    void Update()
    {
        // 更新時間を反復時間に加算
        elapsedTime += Time.deltaTime;

        // 初回の反復時間を半分で行う
        if(firstRepeat == false)
        {
            if(elapsedTime > repeatTime / 2)
            {
                // 移動方向を反転
                directionMove *= -1;

                // ローカル座標のX軸の方向に移動する
                doll.Move(transform.right * directionMove);
                // 反復時間を初期化
                elapsedTime = 0;
                // 初回反復フラグを立てる
                firstRepeat = true;
            }

        }
        // 2回目以降の反復判定
        else if(elapsedTime > repeatTime)
        {
            // 移動方向を反転
            directionMove *= -1;

            // ローカル座標のX軸の方向に移動する
            doll.Move(transform.right * directionMove);
            // 反復時間を初期化
            elapsedTime = 0;
        }

    }

    //----------------------------------------
    // 当たり判定
    void OnTriggerEnter2D (Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName != "Bullet_Player") return;

        // 弾の削除
        Destroy(c.gameObject);

        // 爆発
        doll.Explosion();

        // エネミーの削除
        Destroy(gameObject);

    }
}
