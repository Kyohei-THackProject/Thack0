using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;
    //　銃口
    [SerializeField]
    private Transform muzzle;
    //　弾を飛ばす力
    [SerializeField]
    private float bulletPower = 200f;
    // Start is called before the first frame update

    public void Shot()
    {
        var bulletInstance = GameObject.Instantiate(BulletPrefab, muzzle.position, muzzle.rotation) as GameObject;
        //transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));
        Vector3 direction = GameObject.Find("Enemy").transform.position - bulletInstance.transform.position;
        //bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletPower);
        bulletInstance.GetComponent<Rigidbody>().AddForce(direction * bulletPower);
        Destroy(bulletInstance, 2f);
    }
}
