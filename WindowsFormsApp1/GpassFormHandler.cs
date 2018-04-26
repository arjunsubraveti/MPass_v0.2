using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class GpassFormHandler
    {
        public void PopulateComboBox(string filename, ComboBox comboBox)
        {
            filename = AppDomain.CurrentDomain.BaseDirectory + @"\" + filename;
            string[] lineOfContents = File.ReadAllLines(filename);
            foreach (var line in lineOfContents)
            {
                comboBox.Items.Add(line);
            }


        }
    }
}
