using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    // オブジェクトを表示・非表示するクラス
        public GameObject[] Targets; // 対象のオブジェクト群（エディタでセットできたと思います）
        //[SerializeField]
        //private Sprite[] inventories;

        public void SwitchTo(GameObject go)
        {
            foreach (var t in Targets)//foreach(型名　変数名　in コレクション（配列やリストなど）)
            {
                t.gameObject.SetActive(false);
            }          
                go.gameObject.SetActive(true);
        }
    //    public void Translucent(Sprite trans)
    //{
    //    foreach(var e in inventories)
    //    {
    //        //Color color = inventories.GetComponent<Renderer>().material.color;
    //        //color.a = 0.6f;
    //    }
    //}


}
