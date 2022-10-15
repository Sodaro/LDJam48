using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    MagicProjectile parentScript;
	private void Awake()
	{
        parentScript = GetComponentInParent<MagicProjectile>();
	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable;
        if ((interactable = other.GetComponent<Interactable>()) != null)
        {
            interactable.Interact();
            transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 1, other.transform.position.z);
            parentScript.HoldInPosition();
            this.enabled = false;

        }
    }
}
