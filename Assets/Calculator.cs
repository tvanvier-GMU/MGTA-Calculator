using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Calculator : MonoBehaviour {
	public Text mainDisplay; // The unity component that displays our working value
	public Text historyDisplay; // The unity component that displays the previous value

	[Header("Operation")]
	public double historyDisplayValue; // The actual numerical value of our history display
	public MathOperation operation = MathOperation.NULL;
	public double mainDisplayValue; // The actual numerical value of our main display

	[Header("Last Button Hit")]
	public ButtonType lastButtonType = ButtonType.NULL; 

	string tempNumber;

	public enum MathOperation{
		NULL,
		Add,
		Subtract,
		Multiply,
		Divide,
		Modulo,
		Exponent
	}

	public enum ButtonType{
		NULL,
		Equate,
		Number,
		MathFunction
	}

	// Use this for initialization
	void Start () {
		Clear();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NumpadEntry(string digit){
		if(lastButtonType == ButtonType.Equate){
			Clear();
		}

		if(mainDisplay.text == "0"){
			mainDisplay.text = "";
		}

		mainDisplay.text += digit;
		mainDisplayValue = double.Parse(mainDisplay.text);
		lastButtonType = ButtonType.Number;
	}

	public void DecimalEntry(){
		if(lastButtonType == ButtonType.Equate){
			Clear();
		}
		if(mainDisplay.text.Contains(".")){
			return;
		}
		mainDisplay.text += ".";
	}

	public void AdditionButton(){
		if(operation != MathOperation.NULL){
			Equate();
		}
		historyDisplay.text = mainDisplay.text;
		historyDisplayValue = mainDisplayValue;
		operation = MathOperation.Add;

		mainDisplayValue = 0;
		mainDisplay.text = "0";
		historyDisplay.text += " +";
		lastButtonType = ButtonType.MathFunction;
	}

	public void SubtractionButton(){
		if(operation != MathOperation.NULL){
			Equate();
		}
		historyDisplay.text = mainDisplay.text;
		historyDisplayValue = mainDisplayValue;
		operation = MathOperation.Subtract;

		mainDisplayValue = 0;
		mainDisplay.text = "0";
		historyDisplay.text += " -";
		lastButtonType = ButtonType.MathFunction;
	}

	public void MultiplicationButton(){
		if(operation != MathOperation.NULL){
			Equate();
		}
		historyDisplay.text = mainDisplay.text;
		historyDisplayValue = mainDisplayValue;
		operation = MathOperation.Multiply;

		mainDisplayValue = 0;
		mainDisplay.text = "0";
		historyDisplay.text += " *";
		lastButtonType = ButtonType.MathFunction;
	}

	public void DivisionButton(){
		if(operation != MathOperation.NULL){
			Equate();
		}
		historyDisplay.text = mainDisplay.text;
		historyDisplayValue = mainDisplayValue;
		operation = MathOperation.Divide;

		mainDisplayValue = 0;
		mainDisplay.text = "0";
		historyDisplay.text += " /";
		lastButtonType = ButtonType.MathFunction;
	}

	public void ExponentButton(){
		if(operation != MathOperation.NULL){
			Equate();
		}
		historyDisplay.text = mainDisplay.text;
		historyDisplayValue = mainDisplayValue;
		operation = MathOperation.Exponent;

		mainDisplayValue = 0;
		mainDisplay.text = "0";
		historyDisplay.text += " ^";
		lastButtonType = ButtonType.MathFunction;
	}

	public void ModuloButton(){
		if(operation != MathOperation.NULL){
			Equate();
		}
		historyDisplay.text = mainDisplay.text;
		historyDisplayValue = mainDisplayValue;
		operation = MathOperation.Modulo;

		mainDisplayValue = 0;
		mainDisplay.text = "0";
		historyDisplay.text += " % (Mod)";
		lastButtonType = ButtonType.MathFunction;
	}

	public void NegateButton(){
		mainDisplayValue = MathFunctions.Negate(mainDisplayValue);
		mainDisplay.text = mainDisplayValue.ToString();
	}
		
	public void Equate(){
		if(operation == MathOperation.Add){
			double temp = 0;
			temp = MathFunctions.Add(historyDisplayValue, mainDisplayValue);
			mainDisplayValue = temp;
			mainDisplay.text = temp.ToString();
			historyDisplay.text = "";
			historyDisplayValue = 0;
		}
		else if(operation == MathOperation.Subtract){
			double temp = 0;
			temp = MathFunctions.Subtract(historyDisplayValue, mainDisplayValue);
			mainDisplayValue = temp;
			mainDisplay.text = temp.ToString();
			historyDisplay.text = "";
			historyDisplayValue = 0;
		}
		else if(operation == MathOperation.Multiply){
			double temp = 0;
			temp = MathFunctions.Multiply(historyDisplayValue, mainDisplayValue);
			mainDisplayValue = temp;
			mainDisplay.text = temp.ToString();
			historyDisplay.text = "";
			historyDisplayValue = 0;
		}
		else if(operation == MathOperation.Divide){
			double temp = 0;
			temp = MathFunctions.Divide(historyDisplayValue, mainDisplayValue);
			mainDisplayValue = temp;
			mainDisplay.text = temp.ToString();
			historyDisplay.text = "";
			historyDisplayValue = 0;
		}
		else if(operation == MathOperation.Exponent){
			double temp = 0;
			temp = MathFunctions.Exponent(historyDisplayValue, mainDisplayValue);
			mainDisplayValue = temp;
			mainDisplay.text = temp.ToString();
			historyDisplay.text = "";
			historyDisplayValue = 0;
		}
		else if(operation == MathOperation.Modulo){
			double temp = 0;
			temp = MathFunctions.Modulo(historyDisplayValue, mainDisplayValue);
			mainDisplayValue = temp;
			mainDisplay.text = temp.ToString();
			historyDisplay.text = "";
			historyDisplayValue = 0;
		}

		operation = MathOperation.NULL;
		lastButtonType = ButtonType.Equate;
	}

	public void Clear(){
		mainDisplay.text = "0";
		historyDisplay.text = "";
		mainDisplayValue = 0;
		historyDisplayValue = 0;
		lastButtonType = ButtonType.NULL;
		operation = MathOperation.NULL;
	}

}
