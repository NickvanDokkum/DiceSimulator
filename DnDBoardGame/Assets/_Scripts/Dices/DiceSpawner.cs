using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiceSpawner : MonoBehaviour {

    private List<GameObject> currentDices = new List<GameObject>();
    [SerializeField] private List<GameObject> dices = new List<GameObject>();

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnDice(1, 0);
        }
	}
    void SpawnDice(int amount, int dice) {
        while (currentDices.Count > 0) {
            Destroy(currentDices[0]);
            currentDices.RemoveAt(0);
        }
        for (int i = 0; i < amount; i++) {
            currentDices.Add(Instantiate(dices[dice], transform.position, new Quaternion(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f)) as GameObject);
            currentDices[i].GetComponent<Rigidbody>().AddForce(new Vector2(Random.value - 0.5f, Random.value - 0.5f));
            //Debug.Log(currentDices[dice].GetComponent<Collider>().material.bounciness);
        }
    }
}
