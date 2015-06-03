using UnityEngine;
using System.Collections;

// Rigidbodyコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody))]
public class Doll : MonoBehaviour {


    // 移動スピード
    public float speed;

    // 弾を撃つ間隔
    public float shotDelay;

    // 弾のPrefab
    public Bullet bullet;
    private Bullet l_bullet;

    // 弾を撃つかどうか
    public bool canShot;

    // 爆発のPrefab
    public GameObject explosion;

    //---------------------------------------------
    // 関数
    // 爆発の作成
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }


    // 弾の発射
    public void Shot(Transform origin)
    {
        // 弾の生成
        l_bullet = Instantiate(bullet);
        // 弾の座標を自機に合わせる
        l_bullet.SetInit(origin.position);
        l_bullet.SetScale(new Vector3(10, 10, 10));
        //l_bullet.collider.transform.localScale
    }

    // 機体の移動
    public void Move(Vector3 direction)
    {
        GetComponent<Rigidbody>().velocity = direction * speed;
    }

    //---------------------------
    // 初期化
	// Use this for initialization
	void Start () {
	
	}
	
    //------------------
    // 更新
	// Update is called once per frame
	void Update () {
	
	}

}
