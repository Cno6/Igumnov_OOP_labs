#include <iostream>
#include <math.h>
using namespace std;

class Rational
{
private:
	int nominator;
	int denominator;
	double x;
	double NumDetector(int nom, int denom)
	{
		int del;
		while (denom != 0) 
		{
			del = denom;
			denom = nom % denom;
			nom = del;
		}
		return nom;
	}
public:
	Rational(double a = 1)
		: x(a) 
	{
		int del;
		nominator = 20 * x * x + 13;
		denominator = 10 * x;
		del = NumDetector(nominator, denominator);
		nominator /= del;
		denominator /= del;
	}
	int GetNominator() const
	{
		return nominator;
	}
	int GetDenominator() const
	{
		return denominator;
	}
	friend Rational operator+(Rational a, Rational b)
	{
		int del, nom, denom;
		nom = a.GetNominator() * b.GetDenominator() + b.GetNominator() * a.GetDenominator();
		denom = a.GetDenominator() * b.GetDenominator();
		del = a.NumDetector(nom, denom);
		nom /= del;
		denom /= del;
		cout << nom << "/" << denom << endl;
	}
	friend Rational operator -(Rational a, Rational b)
	{
		int del, nom, denom;
		nom = a.GetNominator() * b.GetDenominator() - b.GetNominator() * a.GetDenominator();
		denom = a.GetDenominator() * b.GetDenominator();
		del = a.NumDetector(nom, denom);
		nom /= del;
		denom /= del;
		cout << nom << "/" << denom << endl;
	}
	friend Rational operator *(Rational a, Rational b)
	{
		int del, nom, denom;
		nom = a.GetNominator() * b.GetNominator();
		denom = a.GetDenominator() * b.GetDenominator();
		del = a.NumDetector(nom, denom);
		nom /= del;
		denom /= del;
		cout << nom << "/" << denom << endl;
	}
	friend Rational operator /(Rational a, Rational b)
	{
		int del, nom, denom;
		nom = a.GetNominator() * b.GetDenominator();
		denom = a.GetDenominator() * b.GetNominator();
		del = a.NumDetector(nom, denom);
		nom /= del;
		denom /= del;
		cout << nom << "/" << denom << endl;
	}
	operator double()
	{
		return (double)nominator / (double)denominator;
	}
	friend ostream& operator << (ostream& stream, Rational &z)
	{
		stream << z.GetNominator() << "/" << z.GetDenominator();
		return stream;
	}
};

int main()
{
	double x;
	cout << "Enter x = ";
	cin >> x;
	cout << "Test:" << endl;
	Rational y1;
	cout << "y1(): Ans. = " << y1 << endl;
	Rational y2(x);
	cout << "y2(x): Ans. = " << y2 << endl;
	Rational y3(2);
	cout << "y3(2): Ans. = " << y3 << endl;
	Rational y4 = 4;
	cout << "y4 = 4: Ans. = " << y4 << endl;
	cout << "y2 + y3: Ans. = "; y2 + y3;
	cout << "y2 - y3: Ans. = "; y2 - y3;
	cout << "y2 * y3: Ans. = "; y2 * y3;
	cout << "y2 / y3: Ans. = "; y2 / y3;
	cout << "cout y2: " << y2 << endl;
	cout << "double()y2: " <<(double)y2;
}