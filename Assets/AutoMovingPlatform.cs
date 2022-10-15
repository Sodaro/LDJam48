using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovingPlatform : MovingPlatform
{
    [SerializeField] bool movingTowardsTarget;

    [SerializeField] float moveDelay = 3f;
    float moveTimer = 0f;

    bool CanMove => moveTimer <= 0;

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
            //Debug.Log(moveTimer);
            if (!CanMove)
			{
                
                moveTimer -= Time.deltaTime;
                return;
            }
            if (movingTowardsTarget)
			{
                if (Vector3.Distance(transform.position, endPosition) > 0.1f)
                {
                    velocity = (endPosition - transform.position).normalized * speed;
                    transform.Translate(velocity * Time.fixedDeltaTime);
                }
                else
                {
                    //transform.position = endPosition;
                    movingTowardsTarget = false;
                    moveTimer = moveDelay;
                }
            }
            else
			{
                if (Vector3.Distance(transform.position, startPosition) > 0.1f)
                {
                    velocity = (startPosition - transform.position).normalized * speed;
                    transform.Translate(velocity * Time.fixedDeltaTime);
                }
                else
                {
                    //transform.position = startPosition;
                    movingTowardsTarget = true;
                    moveTimer = moveDelay;
                }
            }

        }
    }


}
