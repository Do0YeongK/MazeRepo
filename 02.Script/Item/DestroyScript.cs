using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject parentItem;  //item들이 생성 될 상위폴더

    // Start is called before the first frame update
    void Awake()
    {
        if (parentItem == null)
        {
            parentItem = GameObject.FindWithTag("ItemBank");
            //parentItem = this.gameObject.transform.parent.gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall" || other.gameObject.layer == 6)
        {
            this.gameObject.transform.position = new Vector3(Random.Range(-50f, 50f), 1.5f, Random.Range(-50f, 50f));
        }
    }
}
