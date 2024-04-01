using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public DataController dataController;

    public void ResetTongCuoc()
    {
        foreach (Cua cua in dataController.Cuas)
        {
            cua.ResetCuoc();
        }
        dataController.tongCuoc = 0;
        dataController.tongTien = 100000;

        dataController.tongSoTienNguoiChoiCoTxt.text = dataController.tongTien.ToString();
        dataController.tongSoTienCuocTxt.text = dataController.tongCuoc.ToString();
    }
}


/*

thang = tong cuoc + tong tien

thua = tong tien - tong cuoc

*/
