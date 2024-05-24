using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamSphere : MonoBehaviour
{
    public float Radius = 10.0f;
    
    public void Cast()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, Radius, Vector2.one, float.PositiveInfinity);
        Debug.Log(hits.Length);
        foreach (RaycastHit hit in hits)
        {

            if (hit.collider.TryGetComponent(out HearingEnemy hearingEnemy))
            {
                hearingEnemy.NoticePlayer();
                /*Debug.Log('+');*/
            }
        }
    }
}
