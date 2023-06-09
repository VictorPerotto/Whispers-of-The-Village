using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPosition : MonoBehaviour
{
    [SerializeField] private Renderer myRender;
    [SerializeField] private Collider2D myCollider;
    private float myColliderHeight;

    void OnTriggerStay2D(Collider2D other)
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
    }
}
