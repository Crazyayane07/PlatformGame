using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    private Vector3 positionA;
    private Vector3 positionB;
    private Vector3 nextPosition;

    [SerializeField]
    public float platformSpeed;
    [SerializeField]
    private Transform childrenTransform;
    [SerializeField]
    public Transform transformB;

    void Start ()
    {
        positionA = childrenTransform.localPosition;
        positionB = transformB.localPosition;
        nextPosition = positionB;
	}
	
	void Update ()
    {
        Move();
	}
    private void Move()
    {
        childrenTransform.localPosition = Vector3.MoveTowards(childrenTransform.localPosition, nextPosition, platformSpeed * Time.deltaTime);
        if(Vector3.Distance(childrenTransform.localPosition, nextPosition) <= 0.1)
        {
            ChangeDestination();
        }
    }
    private void ChangeDestination()
    {
        if(nextPosition == positionA)
        {
            nextPosition = positionB;
        }
        else
        {
            nextPosition = positionA;
        }
    }
}
