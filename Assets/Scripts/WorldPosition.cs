using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPosition : MonoBehaviour
{
    /*[SerializeField] private Collider2D myCollider;
    private float myColliderHeight;*/

    private Renderer myRender;
    private Collider2D myCollider;
    private float topCollider;
    
    private void Start() 
    {
        myRender = GetComponent<Renderer>();
        myCollider = GetComponent<Collider2D>();
    }

    /*void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 6)
        {
            myColliderHeight = myCollider.bounds.center.y;
            float otherHeight = other.gameObject.GetComponent<Collider2D>().bounds.center.y;
            Renderer otherRenderer = other.gameObject.GetComponent<Renderer>();

            if(otherHeight > myColliderHeight)
            {
                myRender.sortingOrder = 5;
            }

            else 
            {
                myRender.sortingOrder = -5;
            }
        }
    }*/

    private void Update() 
    {
        topCollider = (myCollider.bounds.center.y + myCollider.bounds.extents.y);
        myRender.sortingOrder = Mathf.RoundToInt(topCollider * 100f) * -1;
    }
}
