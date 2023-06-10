using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPosition : MonoBehaviour
{
    private Renderer myRender;
    private Collider2D myCollider;
    private float topCollider;
    
    
    private void Start() 
    {
        myRender = GetComponent<Renderer>();
        myCollider = GetComponent<Collider2D>();
        topCollider = (myCollider.bounds.center.y + myCollider.bounds.extents.y);
        myRender.sortingOrder = Mathf.RoundToInt(topCollider * 100f) * -1;
    }
}
