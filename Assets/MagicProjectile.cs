using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    Rigidbody rb;

    bool isFrozen = false;

    AudioSource audioSource;

    [SerializeField] float shootSpeed = 750f;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] SphereCollider sphereTrigger;
    [SerializeField] SphereCollider sphereCollider;
    [SerializeField] GameObject sphereObject;
    [SerializeField] GameObject cubeObject;
    [SerializeField] GameObject particles;

    public bool IsFrozen => isFrozen;
	private void Awake()
	{
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        //boxCollider = GetComponent<BoxCollider>();
	}
	// Start is called before the first frame update
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyBall()
	{
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
	}

    public void HoldInPosition()
	{
        isFrozen = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        //audio.Pause();
        audioSource.Stop();
        //boxCollider.enabled = true;
        //sphereCollider.enabled = false;
        //sphereObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
        sphereObject.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        // cubeObject.SetActive(true);
        //sphereObject.SetActive(false);
    }

    public void Release()
	{
        isFrozen = false;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(transform.forward * shootSpeed);
        //audio.UnPause();
        audioSource.Play();
        //boxCollider.enabled = false;
        sphereCollider.enabled = true;
        sphereObject.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        //sphereObject.GetComponent<MeshRenderer>().material.em= Color.cyan;
        //sphereObject.SetActive(true);
        //cubeObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable;
        if ((interactable = other.GetComponent<Interactable>()) != null)
        {
            interactable.Interact();
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            //transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 1, other.transform.position.z);
            //HoldInPosition();
            //this.enabled = false;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        foreach (ContactPoint contact in collision.contacts)
        {
            var colName = contact.thisCollider.name;
            if (colName == "BallCollider")
			{
                //Debug.Log("collision detected");
                Instantiate(particles, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {

        foreach (ContactPoint contact in collision.contacts)
        {
            var colName = contact.thisCollider.name;
            if (colName == "BallCollider")
            {
                //Debug.Log("collision detected");
                Instantiate(particles, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

}
