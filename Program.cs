using System.Drawing.Drawing2D;
/* Dit programma tekent een Mandelbrot
*/
using System;
using System.Windows.Forms;
using System.Drawing;


int npixels = 300, x, y;
double middenx = 0, middeny = 0, schaal = 0.01;
byte MandelGetal, aantal = 100;
Form scherm = new Form();
scherm.Text = "Mandelbrot";

byte CalculateMandalgetal(double x, double y, byte aantal)
{
    byte stap;
    double afstand, a = 0.0, b = 0.0, anew;
    a = x;
    b = y;
    for (stap = 0; stap < aantal - 1; stap++)
    {
        afstand = Math.Sqrt(a * a + b * b);
        if (afstand > 2) return stap;
        anew = a * a - b * b + x;
        b = 2 * a * b + y;
        a = anew;
    }
    return stap;

}

scherm.ClientSize = new Size(2 * npixels - 1 + 400, 2 * npixels - 1);
Bitmap plaatje = new Bitmap(2 * npixels - 1, 2 * npixels - 1);
for (x = -(npixels - 1); x < (npixels - 1); x++)
{
    for (y = -(npixels - 1); y < (npixels - 1); y++)
    {
        MandelGetal = CalculateMandalgetal(middenx + x * schaal, middeny + y * schaal, aantal);
        if (MandelGetal % 2 == 1) plaatje.SetPixel(x + npixels, y + npixels, Color.Black); else plaatje.SetPixel(x + npixels, y + npixels, Color.FromArgb(255, ((4 * MandelGetal) % 255), ((6 * MandelGetal) % 255), ((5 * MandelGetal) % 255)));
    }
}
Label afbeelding = new Label();
scherm.Controls.Add(afbeelding);
afbeelding.Location = new Point(0, 0);
afbeelding.Size = new Size(2 * npixels - 1, 2 * npixels - 1);
afbeelding.BackColor = Color.White;
afbeelding.Image = plaatje;
//Graphics gr = Graphics.FromImage(plaatje);

Button knop = new Button();
scherm.Controls.Add(knop);
knop.Location = new Point(2 * npixels - 1 + 160, 500);
knop.Size = new Size(80, 20);
knop.Text = "go";

TextBox invoermiddenx = new TextBox();
scherm.Controls.Add(invoermiddenx);
invoermiddenx.Location = new Point(2 * npixels - 1 + 200, 100);
invoermiddenx.Size = new Size(80, 20);
invoermiddenx.Text = middenx.ToString();

TextBox invoermiddeny = new TextBox();
scherm.Controls.Add(invoermiddeny);
invoermiddeny.Location = new Point(2 * npixels - 1 + 200, 200);
invoermiddeny.Size = new Size(80, 20);
invoermiddeny.Text = middeny.ToString();

TextBox invoerschaal = new TextBox();
scherm.Controls.Add(invoerschaal);
invoerschaal.Location = new Point(2 * npixels - 1 + 200, 300);
invoerschaal.Size = new Size(80, 20);
invoerschaal.Text = schaal.ToString();

TextBox invoeraantal = new TextBox();
scherm.Controls.Add(invoeraantal);
invoeraantal.Location = new Point(2 * npixels - 1 + 200, 400);
invoeraantal.Size = new Size(80, 20);
invoeraantal.Text = aantal.ToString();

Label textmiddenx = new Label();
scherm.Controls.Add(textmiddenx);
textmiddenx.Location = new Point(2 * npixels - 1 + 100, 100);
textmiddenx.Size = new Size(80, 20);
textmiddenx.Text = "midden x:";

Label textmiddeny = new Label();
scherm.Controls.Add(textmiddeny);
textmiddeny.Location = new Point(2 * npixels - 1 + 100, 200);
textmiddeny.Size = new Size(80, 20);
textmiddeny.Text = "midden y:";

Label textschaal = new Label();
scherm.Controls.Add(textschaal);
textschaal.Location = new Point(2 * npixels - 1 + 100, 300);
textschaal.Size = new Size(80, 20);
textschaal.Text = "schaal:";

Label textaantal = new Label();
scherm.Controls.Add(textaantal);
textaantal.Location = new Point(2 * npixels - 1 + 100, 400);
textaantal.Size = new Size(80, 20);
textaantal.Text = "aantal 0...255:";

void klik(object o, EventArgs e)
{
    middenx = double.Parse(invoermiddenx.Text);
    middeny = double.Parse(invoermiddeny.Text);
    schaal = double.Parse(invoerschaal.Text);
    aantal = byte.Parse(invoeraantal.Text);
    for (x = -(npixels - 1); x < (npixels - 1); x++)
    {
        for (y = -(npixels - 1); y < (npixels - 1); y++)
        {
            MandelGetal = CalculateMandalgetal(middenx + x * schaal, middeny + y * schaal, aantal);
            if (MandelGetal % 2 == 1) plaatje.SetPixel(x + npixels, y + npixels, Color.Black); else plaatje.SetPixel(x + npixels, y + npixels, Color.FromArgb(255, ((4 * MandelGetal) % 255), ((6 * MandelGetal) % 255), ((5 * MandelGetal) % 255)));
        }
    }
    afbeelding.Image = plaatje;
    afbeelding.Refresh();
}

void mouseKlik(object o, MouseEventArgs e)
{
    Point point = e.Location;
    middenx = middenx + (point.X - 300) * schaal;
    middeny = middeny + (point.Y - 300) * schaal;
    invoermiddenx.Text = middenx.ToString();
    invoermiddeny.Text = middeny.ToString();
    if (e.Button == MouseButtons.Left)
    {
        schaal = schaal / 2;
    }
    else
    {
        schaal = schaal * 2;
    }
    invoerschaal.Text = schaal.ToString();
    for (x = -(npixels - 1); x < (npixels - 1); x++)
    {
        for (y = -(npixels - 1); y < (npixels - 1); y++)
        {
            MandelGetal = CalculateMandalgetal(middenx + x * schaal, middeny + y * schaal, aantal);
            if (MandelGetal % 2 == 1) plaatje.SetPixel(x + npixels, y + npixels, Color.Black); else plaatje.SetPixel(x + npixels, y + npixels, Color.FromArgb(255, ((4 * MandelGetal) % 255), ((6 * MandelGetal) % 255), ((5 * MandelGetal) % 255)));
        }
    }
    afbeelding.Image = plaatje;
    afbeelding.Refresh();
}

afbeelding.MouseClick += mouseKlik;
knop.Click += klik;

Application.Run(scherm);