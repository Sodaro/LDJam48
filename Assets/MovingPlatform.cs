using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : ToggleableObject
{
    //Rigidbody rb;
    [SerializeField] internal Vector3 offsetPosition;
    internal Vector3 startPosition;
    internal Vector3 endPosition;

    [SerializeField] internal float speed;

    internal Vector3 velocity;
    public Vector3 Velocity => velocity;
    // Start is called before the first frame update
    private void Awake()
	{
        //rb = GetComponent<Rigidbody>();
	}
	private void Start()
	{
        startPosition = transform.position;
        endPosition = startPosition + offsetPosition;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = Vector3.zero;
        if (isActive)
        {
            if (Vector3.Distance(transform.position, endPosition) > 0.1f)
            {
                velocity = (endPosition - transform.position).normalized * speed;
                transform.Translate(velocity * Time.fixedDeltaTime);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, startPosition) > 0.1f)
            {
                velocity = (startPosition - transform.position).normalized * speed;
                transform.Translate(velocity * Time.fixedDeltaTime);
            }
        }
    }


}
