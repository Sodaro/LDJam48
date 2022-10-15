using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressurePlate : MonoBehaviour
{
    [SerializeField] MovingPlatform targetToActivate;

    AudioSource audioSource;

    bool isActive;
    bool isMoving;

    List<GameObject> collidingObjects = new List<GameObject>();

	private void Awake()
	{
        audioSource = GetComponent<AudioSource>();
        GetComponent<Renderer>().sharedMaterial.DisableKeyword("_EMISSION");
    }
	// Start is called before the first frame update
	void Start()
    {
        //startPosition = targetToMove.transform.position;
        //endPosition = startPosition + offsetPosition;
    }
	private void FixedUpdate()
	{
        int layermask = 1 << 8;
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, layermask);
        if (colliders.Length == 0 && collidingObjects.Count > 0)
		{
            //StopAllCoroutines();
            collidingObjects.Clear();
            targetToActivate.Deactivate();
            GetComponent<Renderer>().sharedMaterial.DisableKeyword("_EMISSION");
            //MoveTowardsStart();
        }
	}

	// Update is called once per frame
	void Update()
    {

    }

	private void OnTriggerEnter(Collider other)
	{
        if (collidingObjects.Count == 0)
		{
            targetToActivate.Activate();
            audioSource.Play();
            GetComponent<Renderer>().sharedMaterial.EnableKeyword("_EMISSION");

        }
        collidingObjects.Add(other.gameObject);
    }
	private void OnTriggerExit(Collider other)
	{
        //StopAllCoroutines();
        collidingObjects.Remove(other.gameObject);
        if (collidingObjects.Count == 0)
        {
            targetToActivate.Deactivate();
            GetComponent<Renderer>().sharedMaterial.DisableKeyword("_EMISSION");
        }

    }
}
