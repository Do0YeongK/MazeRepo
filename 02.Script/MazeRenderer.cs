using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField, Range(1, 50)]
    private int width = 10;

    [SerializeField, Range(1, 50)]
    private int height = 10;

    [SerializeField]
    private float size = 3f;    //��ũ��

    [SerializeField]
    private int gap = 3; //������� �̷��� �ʺ�(=��ũ��� ���ƾ���)

    [SerializeField]
    private Transform wallPrefab = null;    //prefab�� �� �ֱ�

    [SerializeField]
    private GameObject mazePos; //maze������ ��ġ

    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate(width, height);   //MazeGenerator�� �ִ� Generate�Լ� ���
        Draw(maze); //maze ��Ÿ����(������ �Ⱥ���)
    }

    private void Draw(WallState[,] maze)    //WallState : MazeGenerator�� �ִ� enum �Լ�
    {
        for (int i = 0; i < width; ++i) //width : maze�� ���� ����
        {
            for (int j = 0; j < height; ++j)    //height : maze�� ���� ����
            {
                var cell = maze[i, j];  //width,height index�� ���� cell �������
                var position = mazePos.transform.position + new Vector3(-width / 2 + i * gap , 0, -height / 2 + j * gap);  //�� ũ�Ⱑ Ŀ���� �������� ���ݵ� �ٲ����
                
                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }
                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }
    }
}
