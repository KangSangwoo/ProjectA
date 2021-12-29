using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        for (int i= 0; i < this.transform.childCount; i++)
        {
            Gizmos.color = Color.green; 
            Gizmos.DrawSphere(GetWayPoint(i), 0.1f);        // 점

            Gizmos.color = Color.white;
            int next = GetNextIndex(i);
            Gizmos.DrawLine(GetWayPoint(i), GetWayPoint(next));      //선
        }
    }

    public int GetNextIndex(int index)
    {
        return (index + 1) % this.transform.childCount;
    }

    public Vector3 GetWayPoint(int index)
    {
        return this.transform.GetChild(index).position;

    }

}
