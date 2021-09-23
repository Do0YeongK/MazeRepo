using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int index;

    public bool isForwardWall = true;
    public bool isBackWall = true;
    public bool isLeftWall = true;
    public bool isRightWall = true;

    public GameObject fowardWall;
    public GameObject backWall;
    public GameObject leftWall;
    public GameObject rightWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowWalls()
    {
        fowardWall.SetActive(isForwardWall);
        backWall.SetActive(isBackWall);
        leftWall.SetActive(isLeftWall);
        rightWall.SetActive(isRightWall);
    }

    public bool CheckAllWall()
    {
        return isForwardWall && isBackWall && isLeftWall && isRightWall;    //다 true = 모든 면이 존재
    }

    public void RemoveFowardDoubleLayer()
    {
        fowardWall.SetActive(false);
    }
    public void RemoveBackDoubleLayer()
    {
        backWall.SetActive(false);
    }
    public void RemoveLeftDoubleLayer()
    {
        leftWall.SetActive(false);
    }
    public void RemoveRightDoubleLayer()
    {
        rightWall.SetActive(false);
    }
}
