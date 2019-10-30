using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gameplay : MonoBehaviour {

	//variable of the UI
	public Text _text; //btnPressed
	public Text _spell; //showing the generated Spell
	public Text _score;
	public Image _spellImage;


	//variables of the backend
	public string userInput;
	string[] Alphabet = new string[3] {"Q", "W", "E"};
	Sprite[] mySpells;
	string generated;

	int score = 0;
	private string _tempSpellCreated, _tempSpellPressed;

	void Start(){
		_score.text = score.ToString();
		mySpells =  Resources.LoadAll<Sprite> ("Images/spells");
		generateSpell ();
		Debug.Log (_tempSpellCreated);
	}

	// this is creating a random spell
	private void generateSpell(){	
		for (int i = 0; i < Alphabet.Length; i++){
			generated = generated + Alphabet[Random.Range(0, Alphabet.Length)];
		}
		changeImage (generated);
		_spell.text = generated;
		_tempSpellCreated = NormalizeSpell(generated);

	}

	//changing the image
	private void changeImage(string gereratedSpell){
		if ((gereratedSpell == "QWE") || (gereratedSpell == "QEW") || (gereratedSpell == "WQE") || (gereratedSpell == "WEQ") || (gereratedSpell == "EWQ") || (gereratedSpell == "EQW")) {
			_spellImage.sprite = mySpells [3] as Sprite;
		} else if (gereratedSpell == "QQQ") {
			_spellImage.sprite = mySpells [2] as Sprite;
		} else if (gereratedSpell == "WWW") {
			_spellImage.sprite = mySpells [5] as Sprite;
		} else if (gereratedSpell == "EEE") {
			_spellImage.sprite = mySpells [11] as Sprite;
		} else if ((gereratedSpell == "QQW") || (gereratedSpell == "QWQ") || (gereratedSpell == "WQQ")){
			_spellImage.sprite = mySpells [7] as Sprite;
		} else if ((gereratedSpell == "QQE") || (gereratedSpell == "QEQ") || (gereratedSpell == "EQQ")){
			_spellImage.sprite = mySpells [8] as Sprite;
		} else if ((gereratedSpell == "WWQ") || (gereratedSpell == "WQW") || (gereratedSpell == "QWW")) {
			_spellImage.sprite = mySpells [12] as Sprite;
		} else if ((gereratedSpell == "WWE") || (gereratedSpell == "WEW") || (gereratedSpell == "EWW")) {
			_spellImage.sprite = mySpells [0] as Sprite;
		} else if ((gereratedSpell == "EEW") || (gereratedSpell == "EWE") || (gereratedSpell == "WEE")) {
			_spellImage.sprite = mySpells [1] as Sprite;
		} else if ((gereratedSpell == "EEQ") || (gereratedSpell == "EQE") || (gereratedSpell == "QEE")) {
			_spellImage.sprite = mySpells [6] as Sprite;
		}
	}

	//returning a normalized spell key
	private string NormalizeSpell(string generatedSpell){
		if ((generatedSpell == "QWE") || (generatedSpell == "QEW") || (generatedSpell == "WQE") || (generatedSpell == "WEQ") || (generatedSpell == "EWQ") || (generatedSpell == "EQW")) {
			generatedSpell = "QWE";
		} else if ((generatedSpell == "QQW") || (generatedSpell == "QWQ") || (generatedSpell == "WQQ")){
			generatedSpell = "QQW";
		} else if ((generatedSpell == "QQE") || (generatedSpell == "QEQ") || (generatedSpell == "EQQ")){
			generatedSpell = "QQE";
		} else if ((generatedSpell == "WWQ") || (generatedSpell == "WQW") || (generatedSpell == "QWW")) {
			generatedSpell = "WWQ";
		} else if ((generatedSpell == "WWE") || (generatedSpell == "WEW") || (generatedSpell == "EWW")) {
			generatedSpell = "WWE";
		} else if ((generatedSpell == "EEW") || (generatedSpell == "EWE") || (generatedSpell == "WEE")) {
			generatedSpell = "EEW";
		} else if ((generatedSpell == "EEQ") || (generatedSpell == "EQE") || (generatedSpell == "QEE")) {
			generatedSpell = "EEQ";
		}
		return generatedSpell;
	}

//	public enum Spell
//	{
////		QQQ,
////		QQW, QWQ, WQQ
////		QQE, QEQ, EQQ
////		WWW,
////		WWQ, WQW, QWW
////		WWE, WEW, EWW
////		EEE,
////		EEW, EWE, WEE
////		EEQ, EQE, QEE
////		QWE, QEW, WQE, WEQ, EWQ, EQW
//
//	}

	public void ButtonPressed(string buttonValue){
		

		//This code does not add the value to the string variable if the input is "R"
		if (buttonValue != "R") {
			userInput = userInput + buttonValue;
			//Resetting the spell for new one
			//generated = "";
		}

		_spell.text = generated;

		// To do: check the last 3 inputs only if the user has entered more than 3 characters
		if (userInput.Length > 3){
			userInput = userInput.Substring (userInput.Length - 3);
		}


		//Calling the invoke button and showing the last 3 digits
		if (buttonValue == "R") {
			//normalizing the spell before checking
			_tempSpellPressed = NormalizeSpell (userInput);
			//Check the key combination with randomly generated spell
			if (_tempSpellPressed == _tempSpellCreated) {
				Debug.Log ("yay");
				score++;
				_score.text = score.ToString ();
				generated = "";
				generateSpell ();
			}
			//_text.text = "resett";
		}
		else
			_text.text = userInput;


		//_text.text = generated;
	}
}