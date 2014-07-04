using UnityEngine;
using System.Collections;

public class CoroutineCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//StartCoroutine("CountSeconds");			//works
		StartCoroutine("SayHelloEveryFrame");		//doesn't work
		//StartCoroutine("SpawnShpere5Times");		//works
		//StartCoroutine("SayHello5Times");			//doesn't work
		//StartCoroutine("Countdown");				//works

		//StartCoroutine(CountSeconds());			//works
		//StartCoroutine(SayHelloEveryFrame());		//doesn't work
		//StartCoroutine(SpawnShpere5Times());		//works
		//StartCoroutine(SayHello5Times());			//doesn't work
		//StartCoroutine(Countdown());				//works
	}

	//I THOUGHT MAKING MOVE MIGHT HAVE A SIDE-EFFECT OF CORRECTING PROBLEMS WHERE COROUTINES AREN'T WORKING CORRECTLY.
	void Update(){
		transform.position += new Vector3(0, 0, .1f);
	}

	IEnumerator Countdown(){
		for (float timer = 3; timer >=0; timer -= Time.deltaTime)
		     yield return 0;
		Debug.Log ( "This message appears after 3 seconds!" );
	}

	//DOES WORK.
	IEnumerator SayHelloFiveTimes(){
		yield return 0;
		Debug.Log ("Hello");

		yield return 0;
		Debug.Log ("Hello");

		yield return 0;
		Debug.Log ("Hello");

		yield return 0;
		Debug.Log ("Hello");

		yield return 0;
		Debug.Log ("Hello");
	}

	//DOESN'T WORK.
	IEnumerator SayHello5Times(){
		for (int i = 0; i < 5; i++){

			//instructions: comment out other block

			yield return 0;
			Debug.Log("Hello");			//prints once
			//Debug.Log("Hello " + i);	//prints 5 times

//			Debug.Log("Hello");			//prints twice
//			yield return 0;

		}

	}


	//DOES WORK.
	IEnumerator SpawnShpere5Times(){
		for (int i = 0; i < 5; i++){
 			yield return 0;
			GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);	//creates 5 times
			go.transform.position = new Vector3(0,0,0);
 		}
		
	}


	//DOESN'T WORK.
	IEnumerator SayHelloEveryFrame(){
		while(true){

			//1. Say "hello"
			Debug.Log("Hello.");	//prints twice

			//2.Wait until next frame
			yield return 0;

		}// 3. This is a forever -loop, go to 1.

	}


	//DOES WORK.
	IEnumerator CountSeconds()
	{
		int seconds = 0;
		
		while (true)
		{
			for (float timer = 0; timer < 1; timer += Time.deltaTime)
				yield return 0;
			
			seconds++;
			Debug.Log(seconds + " seconds have passed since the Coroutine started.");
			if (seconds == 5) StopCoroutine("CountSeconds");
		}
	}



}
