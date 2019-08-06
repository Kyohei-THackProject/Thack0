using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ---------------------------------------
// Playerには次の2つが実装されています．
// 1. EnemyBulletをによる攻撃を受けたときの動作
//    >>> PlayerAttack.cs 
// 2. Player側の攻撃をタッチ入力で呼び出す
//    >>> PlayerDamage.cs
// ---------------------------------------

public class PlayerDamage : MonoBehaviour {
    // EnemyのHPゲージ
    [SerializeField]
    private Slider hpSlider;
    // PlayerのBulletから受けるダメージ
    [SerializeField]
    private float bulletDamage = 5f;
    // PlayerのBulletの爆発エフェクト
    [SerializeField]
    private GameObject explode;
    // GameOver!
    [SerializeField]
    private GameObject Text;

   

    void Start () {
        // "GameOver!"を非表示にしておく
        Text.SetActive (false);
        
    }

    
        

    

    // 衝突時の動作
    Rigidbody rb;
    void OnTriggerEnter (Collider other) {
        rb = other.GetComponent<Rigidbody> ();

        if (other.tag == "EnemyBullet")
        {
            // 衝突エフェクトをつける
            rb.isKinematic = true;
            other.transform.localScale = Vector3.zero;
            //Instantiate (explode, other.transform.position, Quaternion.identity);

            /* Bulletが当たったらEnemyの色を変える
            float r = Random.Range (0.0f, 1.0f);
            float g = Random.Range (0.0f, 1.0f);
            float b = Random.Range (0.0f, 1.0f);
            */

            // HPゲージを減らす
            hpSlider.value -= bulletDamage;
        }
            // HPが0になったら...
            if (hpSlider.value <= 0) {
                // Enemyを消す
                //this.gameObject.SetActive (false);
                // Text(GameOver!)を表示
                Text.SetActive (true);                          
        }
    }
}