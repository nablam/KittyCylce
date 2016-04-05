using UnityEngine;
using System.Collections;

public class pawplosionscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(doboom());
    }
	
 
    IEnumerator doboom()
    {
         
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
      
    }
}
