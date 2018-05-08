using MulakatDataOps;
using MulakatEntities;
using MulakatImageCapture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MulakatPassUK
{
    public partial class GPass : Form
    {
        private GpassEntity objGPass;
        private IGpassDB objIGpassDB;
        private GpassFormHandler objGpassFormHandler;
        private PassImageForm passImage;
        private MulakatPrintScreen mps;

        private Timer tm = new Timer();

        private GpassFormHandler CreateNewGpassFormHandler()
        {
            return new GpassFormHandler();
        }

        private GpassEntity CreateNewGpassEntity()
        {
            return new GpassEntity();
        }

        private IGpassDB CreateNewIGpassDBEntity()
        {
            return new GPassDBOps();
        }

        public GPass()
        {
            InitializeComponent();

            objIGpassDB = CreateNewIGpassDBEntity();
            objGpassFormHandler = CreateNewGpassFormHandler();

        }

        private void Form1_Load(object o, EventArgs e)
        {

            LoadFormElements();

            objGpassFormHandler.PopulateComboBox("Relation.txt", drdRelation1);
            objGpassFormHandler.PopulateComboBox("Relation.txt", drdRelation2);
            objGpassFormHandler.PopulateComboBox("Relation.txt", drdRelation3);
            objGpassFormHandler.PopulateComboBox("Relation.txt", drdRelation4);

            objGpassFormHandler.PopulateComboBox("Article.txt", drdArticles);
            objGpassFormHandler.PopulateComboBox("Purpose.txt", drdPurpose);

            objGpassFormHandler.PopulateComboBox("Case.txt", drdCase1);
            objGpassFormHandler.PopulateComboBox("Case.txt", drdCase2);
            objGpassFormHandler.PopulateComboBox("Case.txt", drdCase3);
            objGpassFormHandler.PopulateComboBox("Case.txt", drdCase4);

            objGpassFormHandler.PopulateComboBox("District.txt", drdDistrict1);
            objGpassFormHandler.PopulateComboBox("District.txt", drdDistrict2);
            objGpassFormHandler.PopulateComboBox("District.txt", drdDistrict3);
            objGpassFormHandler.PopulateComboBox("District.txt", drdDistrict4);

            objGpassFormHandler.PopulateComboBox("ID.txt", drdIdProof1);
            objGpassFormHandler.PopulateComboBox("ID.txt", drdIdProof2);
            objGpassFormHandler.PopulateComboBox("ID.txt", drdIdProof3);
            objGpassFormHandler.PopulateComboBox("ID.txt", drdIdProof4);

            objGpassFormHandler.PopulateComboBox("DOA.txt", drdDOA1);
            objGpassFormHandler.PopulateComboBox("DOA.txt", drdDOA2);
            objGpassFormHandler.PopulateComboBox("DOA.txt", drdDOA3);
            objGpassFormHandler.PopulateComboBox("DOA.txt", drdDOA4);

            objGpassFormHandler.PopulateComboBox("PS.txt", drdPS1);
            objGpassFormHandler.PopulateComboBox("PS.txt", drdPS2);
            objGpassFormHandler.PopulateComboBox("PS.txt", drdPS3);
            objGpassFormHandler.PopulateComboBox("PS.txt", drdPS4);

            objGpassFormHandler.PopulateComboBox("UTCT.txt", drdUTCT1);
            objGpassFormHandler.PopulateComboBox("UTCT.txt", drdUTCT2);
            objGpassFormHandler.PopulateComboBox("UTCT.txt", drdUTCT3);
            objGpassFormHandler.PopulateComboBox("UTCT.txt", drdUTCT4);


        }

        private void LoadFormElements()
        {
            txtSNo.Text = objIGpassDB.RetrieveSerialNumber().ToString();
            txtDate.Text = DateTime.Now.ToShortDateString();
            displayImageBox.Image = displayImageBox.InitialImage;
            tm.Tick += new EventHandler(tm_Tick);
            tm.Interval = 1000;
            tm.Enabled = true;
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Checks if object has been created already or not
            objGPass = objGPass ?? CreateNewGpassEntity();

            CaptureFormText();


            if (objGpassFormHandler.IsEmptyTextBox(txtPrisonerName1, lblPrisonerName) ||
            objGpassFormHandler.IsEmptyTextBox(txtVisitorName1, lblVisitorName) ||
            objGpassFormHandler.IsEmptyComboBox(drdPurpose, lblPurpose) ||
            objGpassFormHandler.IsEmptyTextBox(txtMobile1, lblMobile) ||
            objGpassFormHandler.IsEmptyComboBox(drdIdProof1, lblIDProof) ||
            objGpassFormHandler.IsEmptyTextBox(txtAadhaar1, lblAadhaar))
            {
                MessageBox.Show(objGpassFormHandler.errorMessage);
            }
            else if(!objGpassFormHandler.CheckIfImageCaptured(displayImageBox))
            {
                MessageBox.Show("Take visitor's photo");
            }
            else

            {
                objGpassFormHandler.ValidateAllComboBoxes(this);
         
                objGpassFormHandler.TextBoxValidationForNames(txtPrisonerName1, lblPrisonerName);
                objGpassFormHandler.TextBoxValidationForNames(txtPrisonerName2, lblPrisonerName);
                objGpassFormHandler.TextBoxValidationForNames(txtPrisonerName3, lblPrisonerName);
                objGpassFormHandler.TextBoxValidationForNames(txtPrisonerName4, lblPrisonerName);

                objGpassFormHandler.TextBoxValidationForNames(txtVisitorName1, lblVisitorName);
                objGpassFormHandler.TextBoxValidationForNames(txtVisitorName2, lblVisitorName);
                objGpassFormHandler.TextBoxValidationForNames(txtVisitorName3, lblVisitorName);
                objGpassFormHandler.TextBoxValidationForNames(txtVisitorName4, lblVisitorName);

                objGpassFormHandler.TextBoxValidationForNames(txtFatherName1, lblFatherName);
                objGpassFormHandler.TextBoxValidationForNames(txtFatherName2, lblFatherName);
                objGpassFormHandler.TextBoxValidationForNames(txtFatherName3, lblFatherName);
                objGpassFormHandler.TextBoxValidationForNames(txtFatherName4, lblFatherName);

                objGpassFormHandler.TextBoxValidationForMobile(txtMobile1, lblMobile);
                objGpassFormHandler.TextBoxValidationForMobile(txtMobile2, lblMobile);
                objGpassFormHandler.TextBoxValidationForMobile(txtMobile3, lblMobile);
                objGpassFormHandler.TextBoxValidationForMobile(txtMobile4, lblMobile);

              

                objGPass.IsIncorrectData = objGpassFormHandler.IsValidData(this);

                if (!(objGPass.IsIncorrectData) && SendToDB() > 0)
                {
                    MessageBox.Show("Insert Successful!");
                    objGPass.IsInsertFinished = true;
                    objGpassFormHandler.DisableBoxes(this);
                    btnSave.Enabled = false;
                    btnPhotoCapture.Enabled = false;
                }
                else
                {
                    MessageBox.Show("\n"+objGpassFormHandler.errorMessage);
                }

            }

            objGpassFormHandler.errorMessage = "";


 
        }

        private void CaptureFormText()
        {
            tm.Enabled = false;
            objGPass.OnlyDate = txtDate.Text;
            objGPass.OnlyTime = txtTime.Text;

            objGPass.PrisonerName1 = txtPrisonerName1.Text;
            objGPass.PrisonerName2 = txtPrisonerName2.Text;
            objGPass.PrisonerName3 = txtPrisonerName3.Text;
            objGPass.PrisonerName4 = txtPrisonerName4.Text;

            objGPass.VisitorName1 = txtVisitorName1.Text;
            objGPass.VisitorName2 = txtVisitorName2.Text;
            objGPass.VisitorName3 = txtVisitorName3.Text;
            objGPass.VisitorName4 = txtVisitorName4.Text;

            objGPass.FatherName1 = txtFatherName1.Text;
            objGPass.FatherName2 = txtFatherName2.Text;
            objGPass.FatherName3 = txtFatherName3.Text;
            objGPass.FatherName4 = txtFatherName4.Text;

            objGPass.District1 = drdDistrict1.Text;
            objGPass.District2 = drdDistrict2.Text;
            objGPass.District3 = drdDistrict3.Text;
            objGPass.District4 = drdDistrict4.Text;

            objGPass.UTxCT1 = drdUTCT1.Text;
            objGPass.UTxCT2 = drdUTCT2.Text;
            objGPass.UTxCT3 = drdUTCT3.Text;
            objGPass.UTxCT4 = drdUTCT4.Text;

            objGPass.DOA1 = drdDOA1.Text;
            objGPass.DOA2 = drdDOA2.Text;
            objGPass.DOA3 = drdDOA3.Text;
            objGPass.DOA4 = drdDOA4.Text;

            objGPass.PS1 = drdPS1.Text;
            objGPass.PS2 = drdPS2.Text;
            objGPass.PS3 = drdPS3.Text;
            objGPass.PS4 = drdPS4.Text;

            objGPass.District1 = drdDistrict1.Text;
            objGPass.District2 = drdDistrict2.Text;
            objGPass.District3 = drdDistrict3.Text;
            objGPass.District4 = drdDistrict4.Text;

            objGPass.Relation1 = drdRelation1.Text;
            objGPass.Relation2 = drdRelation2.Text;
            objGPass.Relation3 = drdRelation3.Text;
            objGPass.Relation4 = drdRelation4.Text;

            objGPass.IdProof1 = drdIdProof1.Text;
            objGPass.IdProof2 = drdIdProof2.Text;
            objGPass.IdProof3 = drdIdProof3.Text;
            objGPass.IdProof4 = drdIdProof4.Text;

            objGPass.Aadhaar1 = txtAadhaar1.Text;
            objGPass.Aadhaar2 = txtAadhaar2.Text;
            objGPass.Aadhaar3 = txtAadhaar3.Text;
            objGPass.Aadhaar4 = txtAadhaar4.Text;

            objGPass.Mobile1 = txtMobile1.Text;
            objGPass.Mobile2 = txtMobile2.Text;
            objGPass.Mobile3 = txtMobile3.Text;
            objGPass.Mobile4 = txtMobile4.Text;

            objGPass.Address1 = txtAddress1.Text;
            objGPass.Address2 = txtAddress2.Text;
            objGPass.Address3 = txtAddress3.Text;
            objGPass.Address4 = txtAddress4.Text;

            objGPass.Purpose = drdPurpose.Text;

            objGPass.Articles = drdArticles.Text;

            objGPass.Money = txtMoney.Text;

            objGPass.PassImageData = ImageToByte(displayImageBox.Image);

        }

        private int SendToDB()
        {
            
            return (objIGpassDB.InsertGPassDB(objGPass));
        }

        public byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Call Print methods
            //Disable Print
            //Show messagebox that data has been printed
            if( (objGPass != null) && objGPass.IsInsertFinished)
            {
                mps = new MulakatPrintScreen();
                mps.LoadPrintData(this);
                mps.Show();
            }
            else
            {
                btnSave_Click(null, null);
                if ((objGPass != null) && objGPass.IsInsertFinished)
                {
                    btnPrint_Click(null, null);
                }
                    
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            objGpassFormHandler.EmptyTextBoxes(this);
            LoadFormElements();
            objGPass = new GpassEntity();
            mps = new MulakatPrintScreen();
            objGpassFormHandler.EnableBoxes(this);
            btnSave.Enabled = true;
            btnPrint.Enabled = true;
            btnPhotoCapture.Enabled = true;
            displayImageBox.Image = displayImageBox.InitialImage;
            btnPrint.Enabled = true;
            tm.Enabled = true;
        }

        private void btnPhotoCapture_Click(object sender, EventArgs e)
        {
            passImage = new PassImageForm();
            passImage.Show();
            passImage.FormClosed += new FormClosedEventHandler(passImage_Closed);
            
        }

        private void passImage_Closed(object sender, FormClosedEventArgs e)
        {

            //displayImageBox.Image = Image.FromFile(passImage.tempFilePath);
            passImage.tempFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\" + "tmpImg.jpg";
            passImage.frame.Save(passImage.tempFilePath);
            Image img = new Bitmap(passImage.tempFilePath);
            displayImageBox.Image = img.GetThumbnailImage(130, 130, new Image.GetThumbnailImageAbort(CallbackFun), new IntPtr());
            

        }

        public bool CallbackFun()
        {
            return true;
        }

    }

}
