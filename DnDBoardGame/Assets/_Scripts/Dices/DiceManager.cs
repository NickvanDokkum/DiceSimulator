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
    
    public void SpawnDice(int diceAmount, int dice) {
        diceNumbers.Clear();
        rollingDice = diceAmount;
        totalAmount = 0;
        while (currentDices.Count > 0) {
            Destroy(currentDices[0]);
            currentDices.RemoveAt(0);
        }
        if (dice < dices.Count) {
            for (int i = 0; i < diceAmount; i++) {
                currentDices.Add(Instantiate(dices[dice], transform.position, new Quaternion(Random.value * 2 - 1, Random.value * 2 - 1, Random.value - 0.5f, Random.value * 2 - 1)) as GameObject);
                currentDices[i].GetComponent<Rigidbody>().AddForce(new Vector2(Random.value * 4 + 2, Random.value * 8 - 4));
                currentDices[i].GetComponent<Rigidbody>().AddTorque(new Vector2(Random.value * 8 + 2, Random.value * 16 - 8));
                currentDices[i].GetComponent<DiceCheck>().Manager = this;
            }
        }
        else {
            Debug.LogError("Dice not found");
        }
    }
    void AddNumber(int diceAmount) {

    }
    public void Ready() {
        rollingDice--;
        if(rollingDice == 0) {
            SetTexts();
        }
    }
    void SetTexts() {
        for (int i = 0; i < currentDices.Count; i++) {
            int temp = currentDices[i].GetComponent<DiceCheck>().DiceSide();
            diceNumbers.Add(temp);
            totalAmount += temp;
        }
        diceNumbers.Sort();
        diceNumbers.Reverse();
        string lastrolls = diceNumbers[0].ToString();
        for (int i = 1; i < diceNumbers.Count; i++) {
            lastrolls += ", " + diceNumbers[i].ToString();
        }
        lastRollTotals.text = lastrolls;
        Debug.Log("total: " + totalAmount);
        roles.text = totalAmount + " \n " + roles.text;
    }
}
