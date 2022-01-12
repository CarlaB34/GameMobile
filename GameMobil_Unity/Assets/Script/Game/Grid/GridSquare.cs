using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour
{
    [SerializeField]
    private Image m_NormalImage;

    [SerializeField]
    private List<Sprite> m_NormalSpriteImages;


    public void SetImage(bool p_SetFirstImage)
    {
        //15.37 de la video 3 (pas tous compris)
        //comme un if avec hubert
        //savoir si l'image qu'on a est egale a l'index, donner par le paramettre
        //fonction appeler dans grid
        m_NormalImage.GetComponent<Image>().sprite = p_SetFirstImage ? m_NormalSpriteImages[1] : m_NormalSpriteImages[0];
    }

}
