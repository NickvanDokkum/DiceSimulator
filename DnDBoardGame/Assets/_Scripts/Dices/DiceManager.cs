using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour {

    private List<GameObject> currentDices = new List<GameObject>();
    [SerializeField] private List<GameObject> dices = new List<GameObject>();
    private int rollingDice;
    private int totalAmount;
    [SerializeField] private Text roles;
    [SerializeField] private Text lastRollTotals;
    private List<int> diceNumbers = new List<int>();

    [SerializeField] private List<Transform> walls = new List<Transform>();
    [SerializeField] private List<Vector3> wallsPos = new List<Vector3>();

    public void SpawnDice(List<int> diceAmount) {
        CancelInvoke("SetTexts");
        walls[0].position = wallsPos[0];
        walls[1].position = wallsPos[2];
        walls[2].position = wallsPos[4];
        walls[3].position = wallsPos[6];
        diceNumbers.Clear();
        totalAmount = 0;
        while (currentDices.Count > 0) {
            Destroy(currentDices[0]);
            currentDices.RemoveAt(0);
        }
        if (diceAmount.Count <= dices.Count) {
            for (int d = 0; d < 6; d++) {
                GameObject dice = dices[d];
                for (int i = 0; i < diceAmount[d]; i++) {
                    GameObject currentDice = Instantiate(dice, transform.position, new Quaternion(Random.value * 2 - 1, Random.value * 2 - 1, Random.value - 0.5f, Random.value * 2 - 1)) as GameObject;
                    currentDices.Add(currentDice);
                    currentDice.GetComponent<Rigidbody>().AddForce(new Vector2(Random.value * 4 + 2, Random.value * 8 - 4));
                    currentDice.GetComponent<Rigidbody>().AddTorque(new Vector2(Random.value * 8 + 2, Random.value * 16 - 8));
                    currentDice.GetComponent<DiceCheck>().Manager = this;
                    rollingDice++;
                }
            }
        }
    }
    public void Ready() {
        rollingDice--;
        Debug.Log(rollingDice);
        if(rollingDice == 0) {
            walls[0].position = wallsPos[1];
            walls[1].position = wallsPos[3];
            walls[2].position = wallsPos[5];
            walls[3].position = wallsPos[7];
            for(int i = 0; i < currentDices.Count; i++) {
                currentDices[i].GetComponent<Rigidbody>().AddForce(new Vector3(0, -1, 0));
            }
            Invoke("SetTexts", 1);
        }
    }
    void SetTexts() {
        for (int i = 0; i < currentDices.Count; i++) {
            int temp = currentDices[i].GetComponent<DiceCheck>().DiceSide();
            diceNumbers.Add(temp);
            totalAmount += temp;
        }
        string lastrolls;
        if (isCrit(diceNumbers[0], currentDices[0].GetComponent<DiceCheck>().DiceNumber)) {
            lastrolls = "<color=#00ff00ff>" + diceNumbers[0].ToString() + "</color>";
        }
        else if (diceNumbers[0] == 1) {
            lastrolls = ", <color=#ff0000ff>" + diceNumbers[0].ToString() + "</color>";
        }
        else {
            lastrolls = diceNumbers[0].ToString();
        }
        for (int i = 1; i < diceNumbers.Count; i++) {
            if (diceNumbers[i] == 1) {
                lastrolls += ", <color=#ff0000ff>" + diceNumbers[i].ToString() + "</color>";
            }
            else if (isCrit(diceNumbers[i], currentDices[i].GetComponent<DiceCheck>().DiceNumber)) {
                lastrolls += ", <color=#00ff00ff>" + diceNumbers[i].ToString() + "</color>";
            }
            else {
                lastrolls += ", " + diceNumbers[i].ToString();
            }
        }
        lastRollTotals.text = lastrolls;
        roles.text = totalAmount + " \n " + roles.text;
    }
    private bool isCrit(int diceRoll, int diceKind) {
        Debug.Log(diceRoll + " " + diceKind);
        if ((diceKind == 0 && diceRoll == 4) || (diceKind == 1 && diceRoll == 6) || (diceKind == 2 && diceRoll == 8) || (diceKind ==3 && diceRoll == 10) || (diceKind == 4 && diceRoll == 12) || (diceKind == 5 && diceRoll == 20)) {
            return (true);
        }
        return (false);
    }
}
