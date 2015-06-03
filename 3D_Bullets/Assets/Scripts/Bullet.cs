using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    // 弾の速度
    // 弾の最低速度
    public float minSpeed = 5.0f;
    // 弾の最大速度
    public float maxSpeed = 20.0f;
    // 弾の速度補正（二次関数の定数部分）
    public float speedOfset = 0.05f;
    // 弾の最終速度
    public float reslutSpeed = 5.0f;


    // ゲームオブジェクトの生成から削除するまでの時間
    public float lifeTime = 5.0f;

    // 発射されたかどうかのフラグ
    private bool shotFlg = false;
    //----------------------------------------------
	// Use this for initialization
	void Start () 
    {
        //// 変数の初期化
        //// 速度
        //speed = 5.0f;
        //// 生存時間
        //lifeTime = 5.0f;
        //// 発射フラグ
        //shotFlg = false;

	}
	//-----------------------------------------------
	// Update is called once per frame
	void Update () 
    {
        Debug.Log(reslutSpeed);
	    if(shotFlg == true)
        {
            // ローカル座標のy軸方向に移動する
            GetComponent<Rigidbody>().velocity = transform.up.normalized * reslutSpeed;

            // lifeTime秒後に削除
            Destroy(gameObject, lifeTime);
        }
	}

    public void SetInit(Vector3 pos)
    {
        // 
        transform.position = pos;
    }
    //--------------------------------------------------
    // 拡縮サイズの設定
    public void SetScale(Vector3 Scale)
    {
        // スケールサイズを等倍以下にならないように補正をかける
        Vector3 normal = new Vector3(1.0f, 1.0f, 1.0f);
        // x
        if(Scale.x < normal.x)
        {
            Scale.x = 1.0f;
        }
        // y
        if(Scale.y < normal.y)
        {
            Scale.y = 1.0f;
        }
        // z
        if(Scale.z < normal.y)
        {
            Scale.z = 1.0f;
        }

        // 拡大率をセット
        transform.localScale = Scale;

        float speed = speedOfset * Scale.x * Scale.x;

        if(speed < minSpeed)
        {
            speed = minSpeed;
        }
        else if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        reslutSpeed = speed;

    }
    //-----------------------------------------------
    // 発射されたかのフラグをセット
    public void SetShotFlg(bool flg)
    {
        // フラグをセット
        shotFlg = flg;
    }
}
