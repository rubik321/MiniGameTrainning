using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum TypeCua
{
    Huou,
    Bau,
    Ga,
    Tom,
    Cua,
    Ca
}

public enum TypeKetQuaThangThua
{
    Thang = 0,
    Thua = 1,
}


[System.Serializable]
public class Cua : MonoBehaviour
{
    public DataController dataController;

    public TypeKetQuaThangThua TypeKetQuaThangThua;
    public TypeCua Type;
    public int TienCuoc;
    public int TienThang;
    public TextMeshProUGUI TienThangtxt;

    public TextMeshProUGUI TienUI;
    public GameController gameController;
    public bool isWin;


    private void Start()
    {
        dataController = DataController.instance;
    }

    public void Discount()
    {
        {
            int checkTienCuoc = TienCuoc - dataController.TienCuoc;
            if (checkTienCuoc >= 0)
            {
                TienCuoc -= dataController.TienCuoc;
                dataController.tongCuoc -= dataController.TienCuoc;
                dataController.tongTien += dataController.TienCuoc;
                this.TienUI.text = checkTienCuoc.ToString();
                dataController.tongSoTienCuocTxt.text = dataController.tongCuoc.ToString();
                dataController.UpdateText();

            }


        }
    }

    public void ResetCuoc()
    {
        TienCuoc = 0;
        TienThang = 0;
        this.TienUI.text = this.TienCuoc.ToString();
        isWin = false;


        // TienThangtxt.gameObject.SetActive(false);
        // dataController.tongSoTienNguoiChoiCoTxt.text = dataController.ToString();
        // dataController.tongSoTienCuocTxt.text = dataController.tongCuoc.ToString();

    }


    public void Cuoc()
    {
        if (dataController.TienCuoc <= dataController.tongTien)
        {
            this.TienCuoc += dataController.TienCuoc;
            this.TienUI.text = this.TienCuoc.ToString();
            //int tongTienConLai = dataController.tongTien - TienCuoc;


            dataController.tongCuoc += dataController.TienCuoc;
            dataController.tongTien -= dataController.TienCuoc;

            dataController.UpdateText();
        }
        else
        {

            Debug.Log("Bạn không đủ tiền để cược!");

        }

    }
}
