using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
[System.Serializable]


public class ImgWithId
{
    public TypeCua Id;

    public Sprite EnimalImg;
}

public class DataController : MonoBehaviour
{

    public ComputerUi computerUi;

    public int tongTrungThuong;
    public TextMeshProUGUI tongTrungThuongtxt;

    public int resultBot;
    public int resultPlayer;

    public List<ImgWithId> lsSpriteIcon;

    public List<Cua> Cuas;
    public TextMeshProUGUI tongSoTienNguoiChoiCoTxt;
    public int tongTien = 100000;
    public int tongCuoc = 0;
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
        for (int i = 0; i < 3; i++)
        {
            Cua cua = this.Cuas[UnityEngine.Random.Range(0, this.Cuas.Count)];
            Debug.Log(cua);
            if (cua.TienCuoc > 0)
            {
                tongTien += cua.TienCuoc;
            }
            this.computerUi.iconEnimal[i].sprite = lsSpriteIcon[(int)cua.Type].EnimalImg;
        }
        
        
        //
        this.UpdateText();
    }

    public void ChonTienCuoc(int tien)
    {
        this.TienCuoc = tien;

    }

    public void UpdateText()
    {
        tongSoTienNguoiChoiCoTxt.text = this.tongTien - tongCuoc + "";
        tongSoTienCuocTxt.text = tongCuoc + "";
    }


}


