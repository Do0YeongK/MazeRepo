using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedHammerSlot : MonoBehaviour
{
    [SerializeField]
    private GameObject clickHammerSlot; //선택한 망치아이템

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
