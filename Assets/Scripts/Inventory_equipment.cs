using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory_equipment : MonoBehaviour
{
    public Image[] equipments = new Image[2];
    public GameObject[] equips = new GameObject[2];
    // Use this for initialization
    public void Start()
    {
        int i;
    //    for (i = 1; i < 3; i++) equipments[i].enabled = false; 
        for (i = 1; i < 2; i++) equips[i].SetActive(false);
    }
    //public void equip(int i)
    //{
    //    //if (equipments[i].enabled == true)
    //    //{
    //        if (equips[i].activeSelf == true)
    //        {
    //            equips[i].SetActive(false);                
    //    }
    //    else equips[i].SetActive(true);
    //    //}
    //}   
}