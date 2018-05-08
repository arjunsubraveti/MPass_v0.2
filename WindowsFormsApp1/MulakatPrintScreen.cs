using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MulakatPassUK
{
    public partial class MulakatPrintScreen : Form
    {
        private Bitmap memoryImage;
        private PrintDocument printDocument1 = new PrintDocument();
        PrintPreviewDialog previewdlg = new PrintPreviewDialog();
        Panel pannel = null;

        public bool FinishedPrinting;

        public MulakatPrintScreen()
        {
            InitializeComponent();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            

        }


        public void GetPrintArea(Panel pnl)
        {
            memoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }

        //private void CaptureScreen()
        //{
        //    Graphics myGraphics = this.CreateGraphics();
        //    Size s = this.Size;
        //    memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
        //    Graphics memoryGraphics = Graphics.FromImage(memoryImage);
        //    memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        //}

        private void printDocument1_PrintPage(System.Object sender, PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(memoryImage, 0, 0);
            //FinishedPrinting = true;

            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }
    

        protected override void OnPaint(PaintEventArgs e)
        {
            if (memoryImage != null)
            {
                e.Graphics.DrawImage(memoryImage, 0, 0);
                base.OnPaint(e);
            }
        }

        public void Print(Panel pnl)
        {
            pannel = pnl;
            GetPrintArea(pnl);
            previewdlg.Document = printDocument1;
            previewdlg.ShowDialog();
        }

        public void LoadPrintData (GPass gpass)
        {
            valSNo.Text = gpass.txtSNo.Text;
            valDate.Text = gpass.txtDate.Text;
            valTime.Text = gpass.txtTime.Text;
            valPassPic.Image = gpass.displayImageBox.Image;
            valPrisonerName1.Text = gpass.txtPrisonerName1.Text;
            valPrisonerName2.Text = gpass.txtPrisonerName2.Text;
            valPrisonerName3.Text = gpass.txtPrisonerName3.Text;
            valPrisonerName4.Text = gpass.txtPrisonerName4.Text;

            valFatherName1.Text = gpass.txtFatherName1.Text;
            valFatherName2.Text = gpass.txtFatherName2.Text;
            valFatherName3.Text = gpass.txtFatherName3.Text;
            valFatherName4.Text = gpass.txtFatherName4.Text;

            valUTxCT1.Text = gpass.drdUTCT1.Text;
            valUTxCT2.Text = gpass.drdUTCT2.Text;
            valUTxCT3.Text = gpass.drdUTCT3.Text;
            valUTxCT4.Text = gpass.drdUTCT4.Text;

            valDOA1.Text = gpass.drdDOA1.Text;
            valDOA2.Text = gpass.drdDOA2.Text;
            valDOA3.Text = gpass.drdDOA3.Text;
            valDOA4.Text = gpass.drdDOA4.Text;

            valDOA1.Text = gpass.drdDOA1.Text;
            valDOA2.Text = gpass.drdDOA2.Text;
            valDOA3.Text = gpass.drdDOA3.Text;
            valDOA4.Text = gpass.drdDOA4.Text;

            valCase1.Text = gpass.drdCase1.Text;
            valCase2.Text = gpass.drdCase2.Text;
            valCase3.Text = gpass.drdCase3.Text;
            valCase4.Text = gpass.drdCase4.Text;

            valPS1.Text = gpass.drdPS1.Text;
            valPS2.Text = gpass.drdPS2.Text;
            valPS3.Text = gpass.drdPS3.Text;
            valPS4.Text = gpass.drdPS4.Text;

            valDistrict1.Text = gpass.drdDistrict1.Text;
            valDistrict2.Text = gpass.drdDistrict2.Text;
            valDistrict3.Text = gpass.drdDistrict3.Text;
            valDistrict4.Text = gpass.drdDistrict4.Text;

            valVisitorName1.Text = gpass.txtVisitorName1.Text;
            valVisitorName2.Text = gpass.txtVisitorName2.Text;
            valVisitorName3.Text = gpass.txtVisitorName3.Text;
            valVisitorName4.Text = gpass.txtVisitorName4.Text;

            valRelation1.Text = gpass.drdRelation1.Text;
            valRelation2.Text = gpass.drdRelation2.Text;
            valRelation3.Text = gpass.drdRelation3.Text;
            valRelation4.Text = gpass.drdRelation4.Text;


            valIDProof1.Text = gpass.drdIdProof1.Text;
            valIDProof2.Text = gpass.drdIdProof1.Text;
            valIDProof3.Text = gpass.drdIdProof1.Text;
            valIDProof4.Text = gpass.drdIdProof1.Text;

            valAadhaar1.Text = gpass.txtAadhaar1.Text;
            valAadhaar2.Text = gpass.txtAadhaar2.Text;
            valAadhaar3.Text = gpass.txtAadhaar3.Text;
            valAadhaar4.Text = gpass.txtAadhaar4.Text;

            valMobile1.Text = gpass.txtMobile1.Text;
            valMobile2.Text = gpass.txtMobile2.Text;
            valMobile3.Text = gpass.txtMobile3.Text;
            valMobile4.Text = gpass.txtMobile4.Text;

            valAddress1.Text = gpass.txtAddress1.Text;
            valAddress2.Text = gpass.txtAddress2.Text;
            valAddress3.Text = gpass.txtAddress3.Text;
            valAddress4.Text = gpass.txtAddress4.Text;

            valPurpose.Text = gpass.drdPurpose.Text;
            valArticles.Text = gpass.drdArticles.Text;
            valMoney.Text = gpass.txtMoney.Text;

           

        }

        private void MulakatPrintScreen_Load(object sender, EventArgs e)
        {
            Print(this.panel1);
        }


    }
}
