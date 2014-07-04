using UnityEngine;
using System.Collections;

public class CoroutineLearning : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("someMethod");
		Debug.Log ( "after the thing") ;
	}

	IEnumerator someMethod(){
		int i; int x=0; int max = 1000000000; //this many zeros (9) takes a few seconds to load on my 5yo laptop. (7) is instant.
		for (i= 0; i < max; i++){
			x+=i; 
		}
		Debug.Log ( i );
		yield return null;
	}

}
