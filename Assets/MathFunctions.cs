using UnityEngine;
using System.Collections;
using System;

static public class MathFunctions {

	static public double Add(double x, double y){
		return x + y;
	}

	static public double Subtract(double x, double y){
		return x - y;
	}

	static public double Multiply(double x, double y){
		return x * y;
	}

	static public double Divide(double x, double y){
		return x / y;
	}

	static public double Negate(double input){
		return input * -1;
	}

	static public double Exponent(double x, double power){
		return System.Math.Pow(x, power);
	}

	static public double Modulo(double x, double divisor){
		return x % divisor;
	}

	static public double SquareRoot(double x){
		return Math.Sqrt(x);
	}
}
