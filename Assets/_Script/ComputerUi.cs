using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerUi : MonoBehaviour
{
    public List<Image> iconEnimal;

    public void SetIconEnimal(Sprite spriteEnimal)
    {
        iconEnimal[0].sprite = spriteEnimal;
    }
}
