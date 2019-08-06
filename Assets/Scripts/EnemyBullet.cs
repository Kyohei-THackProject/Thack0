using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyBulletのクラスを設計
public class EnemyBullet : MonoBehaviour {
    // EnemyBulletのクラス内パラメータ3つ
    // 1. インスタンス化したオブジェクトをしまうbullet
    [System.NonSerialized]
    public GameObject bullet;
    // 2. ベジェ曲線用の時間パラメータ，着弾時間
    [System.NonSerialized]
    public float bulletTime, flightTime;
    // 3. Enemy，Playerの座標と第2制御点
    [System.NonSerialized]
    public Vector3 p0, p1, controllPoint;

    // EnemyBulletの飛ぶ方向にバラツキをもたせるパラメータ
    public float randomRange = 1f;

    // コンストラクタ
    // クラス内パラメータを初期化する）
    // 注意：コンストラクタは戻り値をもたないのでvoidを入れない．
    public EnemyBullet (GameObject enemyBulletPrefab, float bulletTime, float meanFlightTime, Vector3 p0, Vector3 p1) {
        this.bullet = Instantiate (enemyBulletPrefab, p0, Quaternion.identity) as GameObject;
        this.bulletTime = bulletTime;
        this.flightTime = meanFlightTime + Random.Range (-1f, 1f);
        this.p0 = p0;
        this.p1 = p1 +
            new Vector3 (Random.Range (-randomRange, randomRange), 0, Random.Range (-randomRange, randomRange));
        this.controllPoint = 0.5f * (p0 + p1) +
            new Vector3 (Random.Range (-0.3f, 0.3f), Random.Range (1f, 2f), Random.Range (-0.3f, 0.3f));
    }

    // 2次ベジェ曲線を定義するメソッド
    float oneMinusT;
    public Vector3 GetPosition (float t) {
        t /= flightTime;
        oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * p0 + 2f * t * oneMinusT * controllPoint + t * t * p1;
    }
}