using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedHammerSlot : MonoBehaviour
{
    [SerializeField]
    private GameObject clickHammerSlot; //������ ��ġ������

    // Start is called before the first frame update
    void Start()
    {
        clickHammerSlot = this.gameObject;        
    }

    public void ClosedSlot()
    {
        clickHammerSlot.SetActive(false);
    }
}
