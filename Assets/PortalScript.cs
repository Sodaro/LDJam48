using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
	[SerializeField] FadeToBlack fadeToBlack;

	private void Awake()
	{
		fadeToBlack = Camera.main.GetComponent<FadeToBlack>();
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.GetComponent<FirstPersonController>().enabled = false;
			other.gameObject.GetComponent<PlayerInteraction>().enabled = false;
			other.gameObject.GetComponent<CharacterController>().enabled = false;
			fadeToBlack.ActivateFade();
		}
	}
}
