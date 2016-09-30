using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DiceController : MonoBehaviour {
    
    private int diceNumber = 0;
    private int diceAmount = 1;
    [SerializeField] private DiceManager manager;
    [SerializeField] private Text diceAmountText;
    [SerializeField] private int maxAmount = 20;
    [SerializeField] private List<Image> diceButtons = new List<Image>();

    void Start() {
        SetDiceButtons();
    }
    public void SpawnDice() {
        manager.SpawnDice(diceAmount, diceNumber);
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SpawnDice();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            if (diceNumber < 5) {
                diceNumber++;
            }
            else {
                diceNumber = 0;
            }
            SetDiceButtons();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            if (diceNumber > 0) {
                diceNumber--;
            }
            else {
                diceNumber = 5;
            }
            SetDiceButtons();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            if (diceAmount < maxAmount) {
                diceAmount++;
            }
            else {
                diceAmount = 1;
            }
            SetDiceButtons();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            if (diceAmount > 1) {
                diceAmount--;
            }
            else {
                diceAmount = maxAmount;
            }
            SetDiceButtons();
        }
    }
    public void SetDice(int dice) {
        diceNumber = dice;
        SetDiceButtons();
    }
    public void AddDice(bool positive) {
        if(positive) {
            diceAmount++;
            if(diceAmount > maxAmount) {
                diceAmount = 1;
            }
        }
        else {
            diceAmount--;
            if (diceAmount < 1) {
                diceAmount = maxAmount;
            }
        }
        SetDiceButtons();
    }
    void SetDiceButtons() {
        diceAmountText.text = diceAmount.ToString();
        for (int i = 0; i < diceButtons.Count; i++) {
            if(i == diceNumber) {
                diceButtons[diceNumber].color = new Color(1, 1, 1);
            }
            else {
                diceButtons[i].color = new Color(0.8f, 0.8f, 0.8f);
            }
        }
    }
}
