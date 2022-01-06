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
                m_GridSquares[m_GridSquares.Count -1].transform.SetParent(this.transform);
            }
        }
    }

    private void SetGridSquaresPosition()
    {
        
    }

   
}
