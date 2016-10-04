using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DiceController : MonoBehaviour {
    
    [SerializeField] private DiceManager manager;
    [SerializeField] private List<Text> diceAmountText = new List<Text>();
    [SerializeField] private Text maxAmountText;
    [SerializeField] private int maxAmount = 21;
    private List<int> dices = new List<int>(1);
    private int diceAmount;


    void Start() {
        for (int i = 0; i < 6; i++) {
            dices.Add(0);
        }
        SetDiceButtons();
    }
    private string diceText(int number) {
        if (number == 0) {
            return ("d4");
        }
        else if (number == 1) {
            return ("d6");
        }
        else if (number == 2) {
            return ("d8");
        }
        else if (number == 3) {
            return ("d10");
        }
        else if (number == 4) {
            return ("d12");
        }
        else if (number == 5) {
            return ("d20");
        }
        return ("Error");
    }
    public void SpawnDice() {
        manager.SpawnDice(dices);
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SpawnDice();
        }
    }
    public void AddDice(int dice) {
        if (diceAmount < maxAmount) {
            diceAmount++;
            dices[dice]++;
            SetDiceButtons();
        }
    }
    public void RemoveDice(int dice) {
        if (diceAmount > 0) {
            diceAmount--;
            dices[dice]--;
            SetDiceButtons();
        }
    }
    void SetDiceButtons() {
        maxAmountText.text = diceAmount.ToString() + "/" + maxAmount.ToString();
        for (int i = 0; i < diceAmountText.Count; i++) {
            diceAmountText[i].text = dices[i].ToString() + "\n" + diceText(i).ToString();
        }
    }
}
