using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class GpassFormHandler   
    {
        private string regExForName = @"^[a-zA-Z][a-zA-Z]+";
        private string regExForMobile = @"^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}98(\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$";
        private ErrorProvider errorProvider;

        public GpassFormHandler()
        {
            errorProvider = new ErrorProvider();
        }


        public void PopulateComboBox(string filename, ComboBox comboBox)
        {
            try
            {
                filename = AppDomain.CurrentDomain.BaseDirectory + @"\" + filename;
                string[] lineOfContents = File.ReadAllLines(filename);
                foreach (var line in lineOfContents)
                {
                    comboBox.Items.Add(line);
                }
            }

            catch(Exception e)
            {
                MessageBox.Show("Error reading file. File not found - " + filename);
            }


        }


       public void CheckForAllEmptyTextBox(Control parents)
        {
            foreach (Control c in parents.Controls)
            {
                if ((c.GetType() == typeof(TextBox)) && (c.Text == string.Empty) )
                {
                    ((TextBox)(c)).BackColor = Color.Pink;

                }
                else
                {
                    if ((c.GetType() == typeof(ComboBox)) && (c.Text == string.Empty))
                    {
                        ((ComboBox)(c)).BackColor = Color.Pink;

                    }

                }
            }

        }

        public bool IsEmptyTextBox(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.BackColor = Color.Pink;
                return true;
            }
            else
            {
                textBox.BackColor = Color.White;
                return false;
            }
        }

        public bool IsEmptyComboBox(ComboBox comboBox)
        {
            if (string.IsNullOrEmpty(comboBox.Text))
            {
                comboBox.BackColor = Color.Pink;
                return true;
            }
            else
            {
                comboBox.BackColor = Color.White;
                return false;
            }
        }

        public void ValidateComboBox(ComboBox comboBox)
        {
            if (!(string.IsNullOrEmpty(comboBox.Text)))
            {
                comboBox.BackColor = Color.Pink;

                foreach (var item in (comboBox.Items))
                {
                    if (item.ToString() == comboBox.Text)
                    {
                        comboBox.BackColor = Color.White;
                    }
                }
            }
            else
            {
                comboBox.BackColor = Color.White;
            }
        }


        public void ValidateAllComboBoxes(Control parents)
        {  
            foreach (Control c in parents.Controls)
            {              
                if ((c.GetType() == typeof(ComboBox)))
                {
                    if(!string.IsNullOrWhiteSpace(c.Text))
                    {
                        ((ComboBox)(c)).BackColor = Color.Pink;

                        foreach (var item in ((ComboBox)(c)).Items)
                        {
                            if (item.ToString() == c.Text)
                            {
                                ((ComboBox)(c)).BackColor = Color.White;
                            }
                        }

                    }

                    //If users make the combox empty after entering value
                    else
                    {
                        ((ComboBox)(c)).BackColor = Color.White;
                    }

                }
               
                }
            }

    
        public void TextBoxValidationForNames(TextBox textBox)
        {   
            
            if ( !string.IsNullOrEmpty(textBox.Text))
            {
                 var test = Regex.IsMatch(textBox.Text, regExForName);

                if (!Regex.IsMatch(textBox.Text, regExForName))
                    {
                    textBox.BackColor = Color.Pink;
                }
                //errorProvider.SetError(textBox, "Alphabets and spaces are only allowed");
               

            }
            else
            {
                textBox.BackColor = Color.White; ;
                //errorProvider.Clear();
            }
        }


        public void TextBoxValidationForMobile(TextBox textBox)
        {

            if ( !string.IsNullOrEmpty(textBox.Text) && !Regex.IsMatch(textBox.Text, regExForMobile))
            {
                //errorProvider.SetError(textBox, "Alphabets and spaces are only allowed");
                textBox.BackColor = Color.Pink;

            }
            else
            {
                textBox.BackColor = Color.White; ;
                //errorProvider.Clear();
            }
        }


        public bool IsValidData(Control parent)
        {

            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
                {
                    if (c.BackColor == Color.Pink)
                    {
                        return true;
                    }
                       
                }
            }
            return false;
        }


        public void EmptyTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) )
                {
                    c.Text = string.Empty;
                    c.BackColor = Color.White;
                }
            }
        }


        public void DisableBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Enabled = false;
                    
                }
                else
                {
                    if (c.GetType() == typeof(ComboBox))
                    {
                        ((ComboBox)(c)).Enabled = false;

                    }

                }
            }
        }

        public bool CheckIfImageCaptured(PictureBox pb)
        {
            if(pb.Image == pb.InitialImage)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void EnableBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    if( c.Name.ToString() != "txtDate" || c.Name.ToString() !=  "txtTime" || c.Name.ToString() != "txtSNo")
                    {
                        ((TextBox)(c)).Enabled = true;
                    }   
                    
                }
                else
                {
                    if (c.GetType() == typeof(ComboBox))
                    {
                        ((ComboBox)(c)).Enabled = true;

                    }
                  
                }
            }
        }

       



    }
}
