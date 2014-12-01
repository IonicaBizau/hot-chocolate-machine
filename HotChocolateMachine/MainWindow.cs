using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
    public MainWindow(): base (Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    string computeCarryOver(int moneyInside)
    {
        switch (moneyInside)
        {
            case 5:
                return "1N ¢";
            case 10:
                return "1D ¢";
            case 15:
                return "1D + 1N ¢";
            case 20:
                return "2D ¢";
            case 25:
                return "1Q ¢";
            default:
                return "0 ¢";
        }
    }

    static int moneyInside = 0;
    protected void OnBtnInsertMoneyClicked(object sender, EventArgs e)
    {
        // What coin was inserted?
        int cValue = 5;
        if (ckbD.Active)
        {
            cValue = 10;
        }
        else if (ckbQ.Active)
        {
            cValue = 25;
        }

        // What to do now?
        moneyInside += cValue;


        if (moneyInside >= 25)
        {
            lblProduct.Text = "Yes";
            moneyInside -= 25;
            lblCarryOver.Text = computeCarryOver(moneyInside);
            moneyInside = 0;
        }
        else
        {
            lblProduct.Text = "No";
            lblCarryOver.Text = "0 ¢";
        }

        lblMoneyInside.Text = moneyInside.ToString() + " ¢";
    }
}
