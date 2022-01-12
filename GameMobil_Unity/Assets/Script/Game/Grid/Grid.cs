using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    //colonne
    [SerializeField]
    private int m_Columns = 0;

    //Lignes
    [SerializeField]
    private int m_Rows = 0;

    //écart carré
    [SerializeField]
    private float m_SquaresGap = 0.1f;

    //grille de jeu
    [SerializeField]
    private GameObject m_GridSquare;

    //point de depart
    [SerializeField]
    private Vector2 m_StartPostion = new Vector2(0.0f,0.0f);

    //taille du carré
    [SerializeField]
    private float m_SquareScale = 0.5f;

    //decalage de carré
    [SerializeField]
    private float m_EverySquareOffset = 0.0f;

    //décalage
    private Vector2 m_Offset = new Vector2(0.0f, 0.0f);

    //liste de carré de la grille
    private List<GameObject> m_GridSquares = new List<GameObject>();
    void Start()
    {
        CreateGrid();
    }

   
   private void CreateGrid()
   {
        //pour positioner tout les carrer
        SpawnGridSquares();

        //position de carrer de la grille
        SetGridSquaresPosition();
   }

    private void SpawnGridSquares()
    {
        //ordre de generation de carrer, start a 0,1,2,3
        //continue l'index a 5,6,7,8,9

        int l_SquareIndex = 0;

        for(var l_Row = 0; l_Row < m_Rows; ++l_Row)
        {
            for (var l_Column = 0; l_Column < m_Columns; ++l_Column)
            {
                m_GridSquares.Add(Instantiate(m_GridSquare) as GameObject);
                //on force le nouveau carre de la grille créer a être un enfant de l'objet qui a le script
                m_GridSquares[m_GridSquares.Count -1].transform.SetParent(this.transform);

                m_GridSquares[m_GridSquares.Count - 1].transform.localScale = new Vector3(m_SquareScale, m_SquareScale, m_SquareScale);

                m_GridSquares[m_GridSquares.Count - 1].GetComponent<GridSquare>().SetImage(l_SquareIndex % 2 == 0);

                l_SquareIndex++;
            }
        }
    }


    //fonction positionne tout les carré créer dans SpawnGridSquares()
    private void SetGridSquaresPosition()
    {
        int l_ColumNumber = 0;
        int l_RowNumber = 0;
        Vector2 l_SquareGapNumber = new Vector2(0.0f, 0.0f);
        bool l_RowMouved = false;

        //var = ici gameObject
        var l_SquareRect = m_GridSquares[0].GetComponent<RectTransform>();

        //optenir la largeur de la texture fois le scale du carré en x + chaque carré de l'offset
        m_Offset.x = l_SquareRect.rect.width * l_SquareRect.transform.localScale.x + m_EverySquareOffset;

        //hauteur du carré
        m_Offset.y = l_SquareRect.rect.height * l_SquareRect.transform.localScale.y + m_EverySquareOffset;

        foreach(GameObject l_Square in m_GridSquares)
        {
            //si chque numero de colone + 1 est plus grand que les colones
            if(l_ColumNumber +1 >m_Columns)
            {
                //on passe alors a la colone suivante afin que le nombre d'espacement carré a x =0
                l_SquareGapNumber.x = 0;

                //on passe ici a la colone suivante
                l_ColumNumber = 0;
                l_RowNumber++;
                l_RowMouved = false;

            }

            //var = float ici
            var l_posXOffest = m_Offset.x * l_ColumNumber + (l_SquareGapNumber.x * m_SquaresGap);
            var l_posYOffest = m_Offset.y * l_RowNumber + (l_SquareGapNumber.y * m_SquaresGap);

            //si le numero de la colone est superieur a 0 et si il est diviser par 3 egale 0
            if(l_ColumNumber > 0 && l_ColumNumber % 3 == 0)
            {
                //si c'est le cas, on veut obtenir le numero d'ecart des carré a x plus 1
                l_SquareGapNumber.x++;

                l_posXOffest += m_SquaresGap;
            }

            //si le numero de la ligne est sup a 0...pareil que l'autre if
            if(l_RowNumber > 0 && l_RowNumber %3 ==0 && l_RowMouved ==false)
            {
                //nous somme donc toujours sur la meme ligne, on met la ligne deplace donc a true
                l_RowMouved = true;
                l_SquareGapNumber.y++;

                //la position y de l'offset augement de 1  l'espace du carré
                l_posYOffest += m_SquaresGap;
            }

            l_Square.GetComponent<RectTransform>().anchoredPosition = new Vector2(m_StartPostion.x + l_posXOffest,
                m_StartPostion.y + l_posYOffest);
        }
    }

   
}
