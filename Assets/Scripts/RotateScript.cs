using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    left,
    right
}

public class RotateScript : MonoBehaviour {

    [Range(0, 100)]
    public int speed;

    public Direction dir;

    private bool isRotating;

    public GameObject Base;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isRotating && dir == Direction.left)
        {
            Base.GetComponent<Transform>().Rotate(Vector3.forward);
            Debug.Log("Muter");
        }

        if (isRotating && dir == Direction.right)
        {
            Base.GetComponent<Transform>().Rotate(Vector3.back);
        }
	}

    public void DoRotate(bool val)
    {
        if (val)
        {
            isRotating = true;
        }
        else
        {
            isRotating = false;
        }
    }

    void OnMouseDown()
    {
        DoRotate(true);
    }

    void OnMouseUp()
    {
        DoRotate(false);
    }
}
