using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int width = 5;
    public int height = 5;

    public Cell cellPrefab;

    private Cell[,] cellMap;    //x�ε���,y�ε���
    private List<Cell> cellHistoryList;

    // Start is called before the first frame update
    void Start()
    {
        BatchCells();   //�� ������ �ٿ��� ����(�� ���� �� �̷�)
        MakeMaze(cellMap[0, 0]); //map�� ���� ���� ������ ��(���� cell)
        cellMap[0, 0].isLeftWall = false;    //���� ���� �ϴ��� ��
        cellMap[width - 1, height - 1].isRightWall = false; //���� ������ ����� ��
        //���� active �ٽ� ������ ��
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
                Cell _cell = Instantiate<Cell>(cellPrefab, this.transform); //Cell ����
                _cell.index = new Vector2Int(x, y);
                _cell.name = "cell_" + x + "_" + y;
                _cell.transform.localPosition = new Vector3(x * 5, 0, y * 5);   //���� ��ġ

                cellMap[x, y] = _cell;
            }
        }
    }
    private void MakeMaze(Cell startCell)
    {
        Cell[] neighbors = GetNeighborCells(startCell); //�ֺ��� cell �迭�� ��
        if (neighbors.Length > 0)    //�̿��� �� �� �Ѱ� �̻��� ������ ���� ���� ��
        {
            Cell nextCell = neighbors[Random.Range(0, neighbors.Length)];
            ConnectCells(startCell, nextCell);  //���� ���ִ� �Լ� ���
            cellHistoryList.Add(nextCell);
            MakeMaze(nextCell);
        }
        else    //������ ���� ���� ���
        {
            if (cellHistoryList.Count > 0)
            {
                Cell lastCell = cellHistoryList[cellHistoryList.Count - 1];
                cellHistoryList.Remove(lastCell);   //���������� �˻��� �� ����
                MakeMaze(lastCell);
            }
        }
    }
    private Cell[] GetNeighborCells(Cell cell)  //������ �� ��
    {
        List<Cell> retCellList = new List<Cell>();
        Vector2Int index = cell.index;  //�ε��� ���� ����
        //forward
        if (index.y + 1 < height)   //index���� height �������� ���� ��
        {
            Cell neighbor = cellMap[index.x, index.y + 1];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }
        //back
        if (index.y - 1 >= 0)   //index���� height �������� ���� ��
        {
            Cell neighbor = cellMap[index.x, index.y - 1];
            if (neighbor.CheckAllWall())    //Cell�� CheckAllWall()�Լ� �߰�����
            {
                retCellList.Add(neighbor);
            }
        }
        //left
        if (index.x - 1 >= 0)   //index���� height �������� ���� ��
        {
            Cell neighbor = cellMap[index.x - 1, index.y];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }
        //right
        if (index.x + 1 < width)   //index���� height �������� ���� ��
        {
            Cell neighbor = cellMap[index.x + 1, index.y];
            if (neighbor.CheckAllWall())
            {
                retCellList.Add(neighbor);
            }
        }
        return retCellList.ToArray();
    }

    //���� �մ� �Լ�
    private void ConnectCells(Cell c0, Cell c1)
    {
        Vector2Int dir = c0.index - c1.index;
        //forward
        if (dir.y <= -1)    //�� �������°�(==) ���� �� ���ٰ� �Ͻ�(������ �ǰ�)
        {
            c0.isForwardWall = false;
            c1.isBackWall = false;
        }
        //back
        else if (dir.y >= 1)    //�� �������°�(==) ���� �� ���ٰ� �Ͻ�(������ �ǰ�)
        {
            c0.isBackWall = false;
            c1.isForwardWall = false;
        }
        //left
        else if (dir.x >= 1)    //�� �������°�(==) ���� �� ���ٰ� �Ͻ�(������ �ǰ�)
        {
            c0.isLeftWall = false;
            c1.isRightWall = false;
        }
        //right
        if (dir.x <= -1)    //�� �������°�(==) ���� �� ���ٰ� �Ͻ�(������ �ǰ�)
        {
            c0.isRightWall = false;
            c1.isLeftWall = false;
        }
        //�ؾ� ���� bool���� �°� cube�� Ȱ��ȭ ��Ŵ
        c0.ShowWalls();
        c1.ShowWalls();
    }
}
