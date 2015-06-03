using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    // 移動速度
    public float X_Speed = 1;
    public float Y_Speed = 1;
    public float Z_Speed = 1;

    // 弾のPrefab
    public Bullet bullet;
    private Bullet l_bullet;

    // dollコンポーネント
    Doll doll;

    // 弾のフラグ
    bool bulletFlg = false;

    // Startメソッドをコルーチンとして呼び出す
    IEnumerator Start()
    {
        // dollコンポーネントを取得
        doll = GetComponent<Doll>();

        //while (true)
        //{

        //    // 弾をプレイヤーと同じ位置/角度で作成
        //    doll.Shot(transform);

        //    // shotDelay秒待つ
            yield return new WaitForSeconds(doll.shotDelay);
        //}


    }
	
    //----------------------------------------------------------
	// Update is called once per frame
	void Update ()
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

        // 弾の発射
        Shoot();
   	}

    //-----------------------------------------------
    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D c)
    {
        //// レイヤー名の取得
        //string layerName = LayerMask.LayerToName(c.gameObject.layer);

        //// レイヤー名がBullet (Enemy)の時は弾を削除
        //if(layerName == "Bullet_Enemy")
        //{
        //    // 弾の削除
        //    Destroy(c.gameObject);
        //}
        
        //// レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
        //if(layerName == "Bullet_Enemy" || layerName == "Enemy")
        //{
        //    // 爆発する
        //    doll.Explosion();

        //    // プレイヤーの削除
        //    Destroy(gameObject);
        //}
    }

    // 弾のチャージ時間
    float chargeTime = 0;

    // 弾を撃つ関数
    void Shoot()
    {
        // マウスがクリックされたら弾チャージフラグを立てる
        if (Input.GetMouseButtonDown(0))
        {
            // 弾の生成
            l_bullet = Instantiate(bullet);
            // 弾の座標を自機に合わせる
            l_bullet.SetInit(transform.position);
            // 弾フラグを立てる
            bulletFlg = true;
        }
        // 弾フラグが立っているとき
        else if (bulletFlg == true)
        {
            // 弾の座標を自機に合わせる
            l_bullet.SetInit(new Vector3(
                             transform.position.x,
                             transform.position.y + 3.0f,
                             transform.position.z + 9.0f));
            // 弾を拡大させる
            float bulletScale = 2.0f;
            l_bullet.SetScale(new Vector3(chargeTime * bulletScale, chargeTime * bulletScale, 10));

            // チャージ時間を加算
            chargeTime += Time.deltaTime;
            // クリックが離されたとき
            if (Input.GetMouseButtonUp(0))
            {
                l_bullet.SetShotFlg(true);
                // 弾をプレイヤーと同じ位置/角度で作成
//              doll.Shot(transform);
                // 弾フラグを下ろす
                bulletFlg = false;
                // 弾のチャージ時間をリセット
                chargeTime = 0;
            }
        }
    }
}
