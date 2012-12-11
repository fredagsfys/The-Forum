using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

public class SecretNumber
{   
    //Innehåller hemligt tal
    private int _number;
    //Lista för gissningar
    private List<int> _PreviousGuess;
    //Antal gissningar man har på sig
    public const int MaxNumberOfGuesses = 7;
    //Villkor med true & false om man får gissa
    public bool CanMakeGuess
    {
        get
        {
            if (Outcome == Outcome.NoMoreGuesses)
            {
                return false;
            }
            else if (Outcome == Outcome.Correct)
            {
                return false;
            }
            return true;  
        }
    }
    //Räknar antal tidigare gissningar för att kolla om man har fler gissningar kvar
    public int Count
    {
        get { return _PreviousGuess.Count; }
    }
    //villkor för möjlighet till gissning
    public int? Number 
    {
        get
        {
            if (CanMakeGuess != true)
            {
                return _number;
            }
            return null;
        }
    }
    //Mellanhand för enum Outcome
    public Outcome Outcome { get; set; }
    //Skapar en ReadOnly på _PreviousGuess
    public ReadOnlyCollection<int> PreviousGuess
    {
        get
        {
            ReadOnlyCollection<int> previGuess = new ReadOnlyCollection<int>(_PreviousGuess);
            return previGuess;
        }
    }
    public void Initializer()
    {
        //Skapar ett random nummer, sätter hemligt tal
        Random RandNum = new Random();
        _number = RandNum.Next(1, 100);
        //Sätter enum till Indefinite
        Outcome = Outcome.Indefinite;
    }
    public Outcome MakeGuess(int Guess)
    {

        _PreviousGuess.Add(Guess);
        //Villkor för intervall 1 - 100, villkor för olika enum-villkor
        if (Guess > 0 && Guess < 101)
        {

            if (Count >= MaxNumberOfGuesses)
            {
                Outcome = Outcome.NoMoreGuesses;
                return Outcome;
            }

            else if (Guess == _number)
            {
                Outcome = Outcome.Correct;
                return Outcome;
            }
            else if (Guess < _number)
            {
                Outcome = Outcome.Low;
                return Outcome;
            }
            else if (Guess > _number)
            {
                Outcome = Outcome.High;
                return Outcome;
            }
            else if (_PreviousGuess.Contains(Guess))
            {
                Outcome = Outcome.PreviousGuess;
                return Outcome;
            }
            else
            {
                Outcome = Outcome.Indefinite;
                return Outcome;
            }
        }
        else
        {
            throw new ArgumentOutOfRangeException("Gussed number was not in range of 1 - 100");
        }
        
    }

    public SecretNumber()
    {
        //Kör Initializer
        Initializer();
        //skapar List för tidigare gissningar
        _PreviousGuess = new List<int>(7);
    }
}