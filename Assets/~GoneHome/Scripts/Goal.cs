using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public UnityEvent onGoal;
    void OnTriggerEnter(Collider other)
    {
        if(onGoal != null)
        {
            onGoal.Invoke();
        }
    }
	
}
