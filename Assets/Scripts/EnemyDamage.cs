using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour {
    // PlayerのBulletの爆発エフェクト
    // [SerializeField]
    // private GameObject explode;
    // EnemyのHPゲージ
    [SerializeField]
    private Slider hpSlider;
    // PlayerのBulletから受けるダメージ
    [SerializeField]
    private float bulletDamage = 10f;
    // クリア後のCongratulations!
    [SerializeField]
    private GameObject Text;

    // "Congratulations!"を非表示にしておく
    void Start () {
        Text.SetActive (false);
    }

    // 衝突時の動作1~4
    Rigidbody rb;
    void OnTriggerEnter (Collider other) {
        rb = other.GetComponent<Rigidbody> ();

        if (other.tag == "PlayerBullet") {
            // 1. 爆発エフェクトを発動
            rb.isKinematic = true;
            other.transform.localScale = Vector3.zero;
            // Instantiate (explode, other.transform.position, Quaternion.identity);

            // 2. Bulletが当たったらEnemyの色を変える
            //float r = Random.Range (0.0f, 1.0f);
            //float g = Random.Range (0.0f, 1.0f);
            //float b = Random.Range (0.0f, 1.0f);
            //this.gameObject.GetComponent<Renderer> ().material.color = new Color (r, g, b);

            // 3. HPゲージを減らす
            hpSlider.value -= bulletDamage;

            // 4. HPが0になったらEnemyを消し，Text(Congratulations!)を表示
            if (hpSlider.value <= 0) {
                this.gameObject.SetActive (false);
                Text.SetActive (true);
            }
        }
    }

}