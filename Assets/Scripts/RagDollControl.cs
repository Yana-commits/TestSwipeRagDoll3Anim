using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollControl : MonoBehaviour
{
    [SerializeField] private Rigidbody[] allRigidbodies;

    public void MakeKinematic()
    {
        for (int i = 0; i < allRigidbodies.Length; i++)
        {
            allRigidbodies[i].isKinematic = true;
            allRigidbodies[i].detectCollisions = false;
        }
    }

    public void MakePhysical(Animator animator)
    {
        animator.enabled = false;
        for (int i = 0; i < allRigidbodies.Length; i++)
        {
            allRigidbodies[i].isKinematic = false;
            allRigidbodies[i].detectCollisions = true;
        }
    }
}
