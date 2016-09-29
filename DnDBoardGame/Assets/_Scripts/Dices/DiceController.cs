using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiceController : MonoBehaviour {
    
    private int diceNumber = 0;
    private int diceAmount = 1;
    [SerializeField] private DiceManager manager;
    [SerializeField] private Text diceInfo;
    [SerializeField] private int maxAmount = 20;

    void Start() {
        SetDiceText();
    }
    void Update() {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            manager.SpawnDice(diceAmount, diceNumber);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            if (diceNumber < 5) {
                diceNumber++;
            }
            else {
                diceNumber = 0;
            }
            SetDiceText();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            if (diceNumber > 0) {
                diceNumber--;
            }
            else {
                diceNumber = 5;
            }
            SetDiceText();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            if (diceAmount < maxAmount) {
                diceAmount++;
            }
            else {
                diceAmount = 1;
            }
            SetDiceText();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            if (diceAmount > 1) {
                diceAmount--;
            }
            else {
                diceAmount = maxAmount;
            }
            SetDiceText();
        }
    }
    void SetDiceText() {
        if(diceNumber == 0) {
            diceInfo.text = "D4 * " + diceAmount;
        }
        else if (diceNumber == 1) {
            diceInfo.text = "D6 * " + diceAmount;
        }
        else if (diceNumber == 2) {
            diceInfo.text = "D8 * " + diceAmount;
        }
        else if (diceNumber == 3) {
            diceInfo.text = "D10 * " + diceAmount;
        }
        else if (diceNumber == 4) {
            diceInfo.text = "D12 * " + diceAmount;
        }
        else if (diceNumber == 5) {
            diceInfo.text = "D20 * " + diceAmount;
        }
        else if (diceNumber == 6) {
            diceInfo.text = "D100 * " + diceAmount;
        }
    }
}
