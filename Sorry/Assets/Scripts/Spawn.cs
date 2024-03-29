using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    GameObject[] Pieces; //all pieces in spawn
    public GameObject startPiece; //add before game,set color bedore game and index = -1
    public GameObject Box;
    public void Start()
    {
        //initialize 4 pieces to spawn
        Pieces = new GameObject[4];
        foreach (GameObject p in Pieces)
            add();
    }

    public bool isEmpty()
    {
        return getNumPieces() == 0;
    }
    int getNumPieces()
    {
        int cnt = 0;

        foreach (GameObject p in Pieces)
            if (p != null) 
                cnt++;

        return cnt;
    }

    public void add()
    {
        //adds piece to spawn   
        for (int i = 0; i < Pieces.Length; i++)
        {
            if (Pieces[i] == null)
            {
                Pieces[i] = Instantiate(startPiece, this.transform, worldPositionStays: false);
                switch (i)
                { 
                    case 0: Pieces[i].transform.position = transform.position + new Vector3(.5f, 0, .5f); break;
                    case 1: Pieces[i].transform.position = transform.position + new Vector3(.5f, 0, -.5f); break;
                    case 2: Pieces[i].transform.position = transform.position + new Vector3(-.5f, 0, -.5f); break;
                    case 3: Pieces[i].transform.position = transform.position + new Vector3(-.5f, 0, .5f); break;
                }
                Pieces[i].transform.localScale = new Vector3(.5f, .5f, .5f);
                break;
            }
        }
    }

    public void spawnPiece()
    {
        //spawns (initializes) piece on gameboard at startIndex and removes one from Peices
        for (int i = 0; i < Pieces.Length; i++)
        {
            if (Pieces[i] != null)
            {
                Pieces[i].GetComponent<Piece>().kys();
                Pieces[i] = null;
                GameObject Piece = Instantiate(startPiece, Box.transform.position, Quaternion.identity);
                Piece.GetComponent<Piece>().setSpawn(gameObject);
/*                Piece.transform.position = new Vector3(Piece.transform.position.x, 30, Piece.transform.position.z);
*/                Piece.transform.localScale = new Vector3(1.5f,1.5f, 1.5f);
                Piece.GetComponent<Piece>().setIndex(Box.GetComponent<Box>().getIndex());
                break;
            }
        }
    }

    public void setBox(GameObject b)
    {
        Box = b;
    }
}
