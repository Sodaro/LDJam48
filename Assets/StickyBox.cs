using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  //      foreach (Transform child in transform)
		//{
  //          child.position = transform.position;
		//}
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
            //transform.parent.GetComponent<MovingPlatform>().player = other.gameObject;
            //Debug.Log("player in sticky zone");
            //other.transform.SetParent(transform.parent, true);
		}
	}

    void OnTriggerExit(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            //transform.parent.GetComponent<MovingPlatform>().player = null;
        }
    }
}
