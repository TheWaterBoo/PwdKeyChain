using System.Drawing;

namespace PwdKeychain.Models;

public class ComboBoxItem
{
    public string Text { get; set; }
    public Image Image { get; set; }

    public ComboBoxItem(string text, Image image)
    {
        Text = text;
        Image = image;
    }

    public override string ToString()
    {
        return Text;
    }
}