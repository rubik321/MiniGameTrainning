using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]


public class ImgWithId
{
    public TypeCua Id;

    public Sprite EnimalImg;
}

public class DataController : MonoBehaviour
{

    public ComputerUi computerUi;

    public TextMeshProUGUI thangthuatxt;



    public int tongTrungThuong;
    public TextMeshProUGUI tongTrungThuongtxt;

    public int resultBot;
    public int resultPlayer;

    public List<ImgWithId> lsSpriteIcon;

    public List<Cua> Cuas;
    public TextMeshProUGUI tongSoTienNguoiChoiCoTxt;
    public int tongTien = 100000;
    public int tongCuoc = 0;

    public int TienThang = 0;


    public TextMeshProUGUI tongSoTienCuocTxt;

    public int TienCuoc;
    public static DataController instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        tongSoTienNguoiChoiCoTxt.text = tongTien.ToString();
        tongSoTienCuocTxt.text = TienCuoc.ToString();
        tongTrungThuongtxt.text = tongTrungThuong.ToString();

    }


    [ContextMenu("ShowKetQua")]
    public void ShowKetQua()
    {
        bool isWin = false;

        for (int i = 0; i < 3; i++)
        {
            Cua cua = this.Cuas[UnityEngine.Random.Range(0, this.Cuas.Count)];
            Debug.Log(cua);
            if (cua.TienCuoc > 0)
            {
                cua.TienThang += cua.TienCuoc;
                cua.isWin = true;
                isWin = true;
            }
            this.computerUi.iconEnimal[i].sprite = lsSpriteIcon[(int)cua.Type].EnimalImg;
        }

        for (int j = 0; j < this.Cuas.Count; j++)
        {
            if (this.Cuas[j].TienThang > 0)
            {
                tongTien += Cuas[j].TienThang;
                tongTien += Cuas[j].TienCuoc;

            }
            if (Cuas[j].isWin)
            {
                Cuas[j].TienThangtxt.text = (Cuas[j].TienThang + Cuas[j].TienCuoc).ToString();
                Cuas[j].TienThangtxt.gameObject.SetActive(true);

            }
            else
            {

                Cuas[j].TienThangtxt.gameObject.SetActive(false);

            }

            Cuas[j].ResetCuoc();

        }

        tongCuoc = 0;
        this.UpdateText();

        thangthuatxt.gameObject.SetActive(true);

        if (isWin)
        {
            thangthuatxt.text = "You Win";
        }
        else
        {
            thangthuatxt.text = "You Lose";
        }
    }

    public void ChonTienCuoc(int tien)
    {
        this.TienCuoc = tien;

    }

    public void UpdateCuoc()
    {

    }
    public void UpdateText()
    {

        tongSoTienNguoiChoiCoTxt.text = this.tongTien.ToString();
        tongSoTienCuocTxt.text = tongCuoc + "";
        thangthuatxt.gameObject.SetActive(false);
    }


}


