using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour {
    // Enemyの弾のゲームオブジェクト
    [SerializeField]
    private GameObject enemyBulletPrefab;
    // 敵の攻撃の間隔
    [SerializeField]
    private float interval = 3f;
    // 着弾までの平均時間
    [SerializeField]
    private float meanFlightTime = 5f;
    // 1度に出す球の個数
    [SerializeField]
    private int bulletCount = 5;
    // 攻撃の及ぶ範囲
    [SerializeField]
    private float enemyAttackRange = 10f; 

    // 敵の弾丸を格納するための連想配列を作る
    Dictionary<int, EnemyBullet> bullets = new Dictionary<int, EnemyBullet> ();
    // EnemyBulletの番号
    int number = 0;
    // Enemy，Playerの座標を入れる箱を準備
    Vector3 p0, p1;
    GameObject playerManager;

    void Start () {
        // p0，playerManagerを所得
        p0 = this.transform.position;
        playerManager = GameObject.Find ("PlayerManager");
    }

    // 時間更新のためのパラメータ
    float currentTime = 0f;

    void FixedUpdate () {
        currentTime += Time.deltaTime;
        foreach (int Key in bullets.Keys) {
            var b = bullets[Key];
            b.bulletTime += Time.deltaTime;
            var bt = b.bulletTime;
            var ft = b.flightTime;
            b.bullet.transform.position = b.GetPosition (bt);

            // 着弾時間を過ぎても着弾しなかった場合，bulletを消す
            if (bt > ft) {
                b.bullet.SetActive (false);
            }
            
        }
        // interval秒ごとにEnemyBulletを発射
        if (currentTime > interval) {
            // PlayerManagerの座標を取得
            p1 = playerManager.transform.position;
            if (Vector3.Distance (p0, p1) < enemyAttackRange) {
                // EnemyBulletクラスのbulletをbulletCount個インスタンス化し，リスト(bullets)に追加
                int i;
                for (i = 0; i < bulletCount; i++) {
                    EnemyBullet bullet = new EnemyBullet (enemyBulletPrefab, 0f, meanFlightTime, p0, p1);
                    bullets.Add (number, bullet);
                    //Bulletに付与する番号を更新
                    number += 1;
                }
            }
            // 時間パラメータを更新
            currentTime = 0f;
        }
        
    }
}