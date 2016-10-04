using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiceCheck : MonoBehaviour {

    private DiceManager manager;
    public DiceManager Manager {
        get { return manager; }
        set {
            manager = value;
        }
    }

    private bool stopped = false;
    public int DiceNumber {
        get { return diceNumber; }
    }
    [SerializeField] private int diceNumber;
    private Rigidbody body;
    private Vector3 lastPos;
    [SerializeField] private List<Transform> sides = new List<Transform>();

    [SerializeField] private int sidenumber;
	
    void Start() {
        body = GetComponent<Rigidbody>();
    }

	void FixedUpdate () {
        if (lastPos == transform.position && !stopped && body.velocity == Vector3.zero && body.angularVelocity == Vector3.zero) {
            manager.Ready();
            stopped = true;
        }
        else {
            lastPos = transform.position;
        }
	}
    public int DiceSide() {
        float y = -99999;
        int side = -1;
        for (int i = 0; i < sides.Count; i++) {
            if (sides[i].position.y > y) {
                side = i + 1;
                y = sides[i].position.y;
            }
        }
        return side;
    }
}
