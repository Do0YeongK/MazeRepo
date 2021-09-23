using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int width = 5;
    public int height = 5;

    public Cell cellPrefab;

    private Cell[,] cellMap;    //x인덱스,y인덱스
    private List<Cell> cellHistoryList;

    // Start is called before the first frame update
    void Start()
    {
        BatchCells();   //방 여러개 붙여서 생성(길 생성 전 미로)
        MakeMaze(cellMap[0, 0]); //map중 제일 먼저 생성된 값(기준 cell)
        cellMap[0, 0].isLeftWall = false;    //제일 왼쪽 하단의 셀
        cellMap[width - 1, height - 1].isRightWall = false; //제일 오른쪽 상단의 셀
        //벽의 active 다시 셋팅해 줌
        cellMap[0, 0].ShowWalls();
        cellMap[width - 1, height - 1].ShowWalls();
    }

    private void BatchCells()
    {
        cellMap = new Cell[width, height];
        cellHistoryList = new List<Cell>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell _cell = Instantiate<Cell>(cellPrefab, this.transform); //Cell 생성
                _cell.index = new Vector2Int(x, y);
                _cell.name = "cell_" + x + "_" + y;
                _cell.transform.localPosition = new Vector3(x * 5, 0, y * 5);   //생성 위치

                cellMap[x, y] = _cell;
            }
        }
    }
    private void MakeMaze(Cell startCell)
    {
        Cell[] neighbors = GetNeighborCells(startCell); //주변의 cell 배열에 넣
        if (neighbors.Length > 0)    //이웃한 셀 중 한개 이상의 온전한 셀이 있을 때
        {
            Cell nextCell = neighbors[Random.Range(0, neighbors.Length)];
            ConnectCells(startCell, nextCell);  //벽을 없애는 함수 사용
            cellHistoryList.Add(nextCell);
            MakeMaze(nextCell);
        }
        else    //온전한 셀이 없을 경우
        {
            if (cellHistoryList.Count > 0)
            {
                Cell lastCell = cellHistoryList[cellHistoryList.Count - 1];
                cellHistoryList.Remove(lastCell);   //마지막으로 검색한 셀 삭제
                MakeMaze(lastCell);
            }
        }
    }
    private Cell[] GetNeighborCells(Cell cell)  //기준이 될 셀
    {
        List<Cell> retCellList = new List<Cell>();
        Vector2Int index = cell.index;  //인덱스 저장 변수
        //forward
        if (index.y + 1 < height)   //index값이 height 범위내에 있을 때
        {
            Cell neighbor = cellMap[index.x, index.y + 1];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }
        //back
        if (index.y - 1 >= 0)   //index값이 height 범위내에 있을 때
        {
            Cell neighbor = cellMap[index.x, index.y - 1];
            if (neighbor.CheckAllWall())    //Cell에 CheckAllWall()함수 추가해줌
            {
                retCellList.Add(neighbor);
            }
        }
        //left
        if (index.x - 1 >= 0)   //index값이 height 범위내에 있을 때
        {
            Cell neighbor = cellMap[index.x - 1, index.y];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }
        //right
        if (index.x + 1 < width)   //index값이 height 범위내에 있을 때
        {
            Cell neighbor = cellMap[index.x + 1, index.y];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }
        return retCellList.ToArray();
    }

    //벽을 뚫는 함수
    private void ConnectCells(Cell c0, Cell c1)
    {
        Vector2Int dir = c0.index - c1.index;
        //forward
        if (dir.y <= -1)    //딱 떨어지는거(==) 보다 더 좋다고 하심(개인적 의견)
        {
            c0.isForwardWall = false;
            c1.isBackWall = false;
        }
        //back
        else if (dir.y >= 1)    //딱 떨어지는거(==) 보다 더 좋다고 하심(개인적 의견)
        {
            c0.isBackWall = false;
            c1.isForwardWall = false;
        }
        //left
        else if (dir.x >= 1)    //딱 떨어지는거(==) 보다 더 좋다고 하심(개인적 의견)
        {
            c0.isLeftWall = false;
            c1.isRightWall = false;
        }
        //right
        if (dir.x <= -1)    //딱 떨어지는거(==) 보다 더 좋다고 하심(개인적 의견)
        {
            c0.isRightWall = false;
            c1.isLeftWall = false;
        }
        //해야 각각 bool값에 맞게 cube들 활성화 시킴
        c0.ShowWalls();
        c1.ShowWalls();
    }
}
