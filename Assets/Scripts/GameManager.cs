using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject hazardPrefab;
	void Start () {
		StartCoroutine(SpawnHazards());
	}
	
	private IEnumerator SpawnHazards()
	{
		var hazardToSpam = Random.Range(1, 4);
		for(int i = 0; i< hazardToSpam; i++)
		{
            var x = Random.Range(-7, 7);
            var drag = Random.Range(0f, 2f);
            var hazard = Instantiate(hazardPrefab, new Vector3(x, 11, 0), Quaternion.identity);
            hazard.GetComponent<Rigidbody>().drag = drag;
        }

		var timeToWait = Random.Range(0.5f, 1.5f);

		yield return new WaitForSeconds(timeToWait);

		yield return SpawnHazards();
	}
}
