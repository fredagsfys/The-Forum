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

    }
    protected void convertButton_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {

            //Hämtar input från textbox's
            int startTemp = int.Parse(startTempTextBox.Text);
            int endTemp = int.Parse(endTempTextBox.Text);
            int levelTemp = int.Parse(levelTempTextBox.Text);

                //Hämtar inputs från textboxarna och lägger dom yttligare i en variabel
                var startTempRun = (int.Parse(startTempTextBox.Text));
                var endTempRun = (int.Parse(endTempTextBox.Text));
                var levelTempRun = (int.Parse(levelTempTextBox.Text));
                //Do-while som repeterar förfarande tills startTempRun är = endTempRun
                do
                {
                    TableRow tRow = new TableRow();

                    TableCell cell1 = new TableCell();
                    cell1.Text = startTempRun.ToString();
                    TableCell cell2 = new TableCell();

                    cell2.Text = RadioButton1.Checked ? 
                        TempatureConverter.FahrenheitToCelcius(start).ToString() : TempatureConverter.CelciusToFahrenheit(start).ToString();

                    tRow.Cells.Add(cell1);
                    tRow.Cells.Add(cell2);
                    TablePresent.Rows.Add(tRow);

                    startTempRun += endTempRun;
                } while (startTempRun <= endTempRun);

            }
        }
    }
}