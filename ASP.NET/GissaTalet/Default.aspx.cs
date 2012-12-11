using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Kontroll av postback
        if (!IsPostBack)
        {
            //Skapar object och lägger den i sessionen theGuess
            Session["myGuess"] = new SecretNumber();
            //Sparar sessionen i variabel för att kunna anropa objektet
            var theGuess = Session["myGuess"] as SecretNumber;
        }
    }
 
    protected void myGuessButton_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            //Sessionsvariabel
            var myGuess = Session["myGuess"] as SecretNumber;
 
            //Skickar gissning till Outcome output
            Outcome output = myGuess.MakeGuess(int.Parse(inputTextBox.Text));
 
            //Hämtar tidigare gissningar
            var aString = "";
            for (int i = 0; i < myGuess.PreviousGuess.Count; i++)
            {
                aString += string.Format("[{0}]", myGuess.PreviousGuess[i]);
            }
 
            //Resultat från ENUM vid olika gissningar
            if (output == Outcome.Correct)
            {
                PlaceHolderPrevious.Visible = true;
                for (int i = 0; i < myGuess.Count; i++)
                PlaceHolderOutput.Visible = true;
                LiteralOutput.Text = string.Format("Rätt! Hemliga talet är {0}", myGuess.Number);
                inputTextBox.Enabled = false;
                myGuessButton.Enabled = false;
            }
            else if (output == Outcome.High)
            {
                PlaceHolderPrevious.Visible = true;
                LiteralPrevious.Text = aString;
                PlaceHolderOutput.Visible = true;
                LiteralOutput.Text = "Talet är för högt";
               
            }
            else if (output == Outcome.Low)
            {
                PlaceHolderPrevious.Visible = true;
                LiteralPrevious.Text = aString;
                PlaceHolderOutput.Visible = true;
                LiteralOutput.Text = "Talet är för lågt";
               
            }
            else if (output == Outcome.PreviousGuess)
            {
                PlaceHolderPrevious.Visible = true;
                LiteralPrevious.Text = aString;
                PlaceHolderOutput.Visible = true;
                LiteralOutput.Text = "Talet är redan gissat på!";
            }
            else if (output == Outcome.NoMoreGuesses)
            {
                generateNewButton.Visible = true;
                inputTextBox.Enabled = false;
                myGuessButton.Enabled = false;
                LiteralPrevious.Text = aString;
                LiteralOutput.Text = string.Format("Slut på gissningar, hemliga talet är {0}", myGuess.Number);
            }
        }
    }
    protected void generateNewButton_Click(object sender, EventArgs e)
    {
        //Skapar nytt tal och tömmer tidigare gissningar, knappar disabled o enabled
        Session["myGuess"] = new SecretNumber();        
        LiteralPrevious.Text = "";
        inputTextBox.Enabled = true;
        myGuessButton.Enabled = true;
    }
}
