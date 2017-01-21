using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashRepro
    : MonoBehaviour
{
	void Start()
    {
        StartCoroutine("DoCrashTest");		
        StartCoroutine("DoCrashTest");		
        StartCoroutine("DoCrashTest");		
        StartCoroutine("DoCrashTest");		
        StartCoroutine("DoCrashTest");		
	}

    IEnumerator DoCrashTest()
    {
        var src = GameObject.Find("ItemBullet");

        while (true)
        {
            var bullet = GameObject.Instantiate(src);

            var bulletCollider = bullet.GetComponent<Collider>();
            var bullet_rb = bullet.GetComponent<Rigidbody>(); 
            bullet_rb.isKinematic = true; 
            
            yield return null;

            if (bullet == null)
                yield break;

            bullet_rb.isKinematic = false;

            yield return new WaitForSeconds(Random.Range(0.0f, 0.2f));
        }
    }
}
