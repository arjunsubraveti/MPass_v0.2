using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Printing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private XPdfFontOptions pdfOptions;
        private PdfDocument pdfPass;
        public bool FinishedPrinting;
        private XFont labelFont;
        private XFont hindiTitleFont;
        private XFont hindiSubTitleFont;
        private XFont valueFont;
        private XFont bottomFont;

        public MulakatPrintScreen()
        {
            InitializeComponent();
            PdfFilePrinter.AdobeReaderPath = @"C:\Program Files (x86)\Adobe\Reader 11.0\Reader";
            pdfOptions = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);

            labelFont         = new XFont("Arial Unicode MS", 8F, XFontStyle.Regular, pdfOptions);
            hindiTitleFont    = new XFont("Arial Unicode MS", 12F, XFontStyle.Regular, pdfOptions);
            hindiSubTitleFont = new XFont("Arial Unicode MS", 11F, XFontStyle.Regular, pdfOptions);
            valueFont         = new XFont("Arial Unicode MS", 8F, XFontStyle.Regular, pdfOptions);
            bottomFont        = new XFont("Arial Unicode MS", 7F, XFontStyle.Regular, pdfOptions);


        }


        //public void GetPrintArea(Panel pnl)
        //{
        //    memoryImage = new Bitmap(pnl.Width, pnl.Height);
        //    pnl.DrawToBitmap(memoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        //}

        //private void CaptureScreen()
        //{
        //    Graphics myGraphics = this.CreateGraphics();
        //    Size s = this.Size;
        //    memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
        //    Graphics memoryGraphics = Graphics.FromImage(memoryImage);
        //    memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        //}

        //private void printDocument1_PrintPage(System.Object sender, PrintPageEventArgs e)
        //{
        //    //e.Graphics.DrawImage(memoryImage, 0, 0);
        //    //FinishedPrinting = true;

        //    //Rectangle pagearea = e.PageBounds;
        //    //e.Graphics.DrawImage(memoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);

            
        //}
    

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    if (memoryImage != null)
        //    {
        //        e.Graphics.DrawImage(memoryImage, 0, 0);
        //        base.OnPaint(e);
        //    }
        //}

        //public void Print(Panel pnl)
        //{
        //    //pannel = pnl;
        //    //GetPrintArea(pnl);
        //    //previewdlg.Document = printDocument1;
        //    //previewdlg.ShowDialog();
        //    printDocument1.Print();
        //}

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
            valIDProof2.Text = gpass.drdIdProof2.Text;
            valIDProof3.Text = gpass.drdIdProof3.Text;
            valIDProof4.Text = gpass.drdIdProof4.Text;

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

            //Print(this.panel1);

            CreatePassPDF();


        }

        private void CreatePassPDF()
        {
            pdfPass = new PdfDocument();
            pdfPass.Info.Author = "Mulakat Pass UK"; //Should change this later;

            PdfPage page = pdfPass.AddPage();
            page.Size = PageSize.A4;

            XGraphics gfx = XGraphics.FromPdfPage(page);
            
            

            //Heading part of the Form
            gfx.DrawString(lblTitle1.Text, hindiTitleFont, XBrushes.Black, lblTitle1.Location);
            gfx.DrawString(lblTitle2.Text,hindiTitleFont, XBrushes.Black, lblTitle2.Location);
            gfx.DrawString(lblSubTitle1.Text, hindiSubTitleFont, XBrushes.Black, lblSubTitle1.Location);
            gfx.DrawString(lblSubTitle2.Text, hindiSubTitleFont, XBrushes.Black, lblSubTitle2.Location);
            gfx.DrawString(lblLineLeft.Text, bottomFont, XBrushes.Black, lblLineLeft.Location);
            gfx.DrawString(lblLineRight.Text, bottomFont, XBrushes.Black, lblLineRight.Location);

            gfx.DrawImage(mpassLogo.Image, mpassLogo.Location);

            gfx.DrawString(lblSNo.Text, labelFont, XBrushes.Black, lblSNo.Location);
            gfx.DrawString(valSNo.Text, valueFont, XBrushes.Black, valSNo.Location);
            gfx.DrawString(lblDate.Text, labelFont, XBrushes.Black, lblDate.Location);
            gfx.DrawString(valDate.Text, valueFont, XBrushes.Black, valDate.Location);
            gfx.DrawString(lblTime.Text, labelFont, XBrushes.Black, lblTime.Location);
            gfx.DrawString(valTime.Text, valueFont, XBrushes.Black, valTime.Location);
            gfx.DrawString(lblMTime.Text, labelFont, XBrushes.Black, lblMTime.Location);
 
            gfx.DrawImage(valPassPic.Image, valPassPic.Location);
                
            gfx.DrawString(lblPrisonerName.Text, labelFont, XBrushes.Black, lblPrisonerName.Location);
            gfx.DrawString(valPrisonerName1.Text, valueFont, XBrushes.Black, valPrisonerName1.Location);
            gfx.DrawString(valPrisonerName2.Text, valueFont, XBrushes.Black, valPrisonerName2.Location);
            gfx.DrawString(valPrisonerName3.Text, valueFont, XBrushes.Black, valPrisonerName3.Location);
            gfx.DrawString(valPrisonerName3.Text, valueFont, XBrushes.Black, valPrisonerName4.Location);

            gfx.DrawString(lblFatherName.Text, labelFont, XBrushes.Black, lblFatherName.Location);
            gfx.DrawString(valFatherName1.Text, valueFont, XBrushes.Black, valFatherName1.Location);
            gfx.DrawString(valFatherName2.Text, valueFont, XBrushes.Black, valFatherName2.Location);
            gfx.DrawString(valFatherName3.Text, valueFont, XBrushes.Black, valFatherName3.Location);
            gfx.DrawString(valFatherName3.Text, valueFont, XBrushes.Black, valFatherName4.Location);

            gfx.DrawString(lblUTxCT.Text, labelFont, XBrushes.Black, lblUTxCT.Location);
            gfx.DrawString(valUTxCT1.Text, valueFont, XBrushes.Black, valUTxCT1.Location);
            gfx.DrawString(valUTxCT2.Text, valueFont, XBrushes.Black, valUTxCT2.Location);
            gfx.DrawString(valUTxCT3.Text, valueFont, XBrushes.Black, valUTxCT3.Location);
            gfx.DrawString(valUTxCT3.Text, valueFont, XBrushes.Black, valUTxCT4.Location);

            gfx.DrawString(lblCase.Text, labelFont, XBrushes.Black, lblCase.Location);
            gfx.DrawString(valCase1.Text, valueFont, XBrushes.Black, valCase1.Location);
            gfx.DrawString(valCase2.Text, valueFont, XBrushes.Black, valCase2.Location);
            gfx.DrawString(valCase3.Text, valueFont, XBrushes.Black, valCase3.Location);
            gfx.DrawString(valCase3.Text, valueFont, XBrushes.Black, valCase4.Location);

            gfx.DrawString(lblDOA.Text, labelFont, XBrushes.Black, lblDOA.Location);
            gfx.DrawString(valDOA1.Text, valueFont, XBrushes.Black, valDOA1.Location);
            gfx.DrawString(valDOA2.Text, valueFont, XBrushes.Black, valDOA2.Location);
            gfx.DrawString(valDOA3.Text, valueFont, XBrushes.Black, valDOA3.Location);
            gfx.DrawString(valDOA3.Text, valueFont, XBrushes.Black, valDOA4.Location);

            gfx.DrawString(lblPS.Text, labelFont, XBrushes.Black, lblPS.Location);
            gfx.DrawString(valPS1.Text, valueFont, XBrushes.Black, valPS1.Location);
            gfx.DrawString(valPS2.Text, valueFont, XBrushes.Black, valPS2.Location);
            gfx.DrawString(valPS3.Text, valueFont, XBrushes.Black, valPS3.Location);
            gfx.DrawString(valPS3.Text, valueFont, XBrushes.Black, valPS4.Location);

            gfx.DrawString(lblDistrict.Text, labelFont, XBrushes.Black, lblDistrict.Location);
            gfx.DrawString(valDistrict1.Text, valueFont, XBrushes.Black, valDistrict1.Location);
            gfx.DrawString(valDistrict2.Text, valueFont, XBrushes.Black, valDistrict2.Location);
            gfx.DrawString(valDistrict3.Text, valueFont, XBrushes.Black, valDistrict3.Location);
            gfx.DrawString(valDistrict3.Text, valueFont, XBrushes.Black, valDistrict4.Location);


            gfx.DrawString(lblVisitorName.Text, labelFont, XBrushes.Black, lblVisitorName.Location);
            gfx.DrawString(valVisitorName1.Text, valueFont, XBrushes.Black, valVisitorName1.Location);
            gfx.DrawString(valVisitorName2.Text, valueFont, XBrushes.Black, valVisitorName2.Location);
            gfx.DrawString(valVisitorName3.Text, valueFont, XBrushes.Black, valVisitorName3.Location);
            gfx.DrawString(valVisitorName3.Text, valueFont, XBrushes.Black, valVisitorName4.Location);

            gfx.DrawString(lblRelation.Text, labelFont, XBrushes.Black, lblRelation.Location);
            gfx.DrawString(valRelation1.Text, valueFont, XBrushes.Black, valRelation1.Location);
            gfx.DrawString(valRelation2.Text, valueFont, XBrushes.Black, valRelation2.Location);
            gfx.DrawString(valRelation3.Text, valueFont, XBrushes.Black, valRelation3.Location);
            gfx.DrawString(valRelation3.Text, valueFont, XBrushes.Black, valRelation4.Location);

            gfx.DrawString(lblIDProof.Text, labelFont, XBrushes.Black, lblIDProof.Location);
            gfx.DrawString(valIDProof1.Text, valueFont, XBrushes.Black, valIDProof1.Location);
            gfx.DrawString(valIDProof2.Text, valueFont, XBrushes.Black, valIDProof2.Location);
            gfx.DrawString(valIDProof3.Text, valueFont, XBrushes.Black, valIDProof3.Location);
            gfx.DrawString(valIDProof3.Text, valueFont, XBrushes.Black, valIDProof4.Location);

            gfx.DrawString(lblAadhaar.Text, labelFont, XBrushes.Black, lblAadhaar.Location);
            gfx.DrawString(valAadhaar1.Text, valueFont, XBrushes.Black, valAadhaar1.Location);
            gfx.DrawString(valAadhaar2.Text, valueFont, XBrushes.Black, valAadhaar2.Location);
            gfx.DrawString(valAadhaar3.Text, valueFont, XBrushes.Black, valAadhaar3.Location);
            gfx.DrawString(valAadhaar3.Text, valueFont, XBrushes.Black, valAadhaar4.Location);

            gfx.DrawString(lblMobile.Text, labelFont, XBrushes.Black, lblMobile.Location);
            gfx.DrawString(valMobile1.Text, valueFont, XBrushes.Black, valMobile1.Location);
            gfx.DrawString(valMobile2.Text, valueFont, XBrushes.Black, valMobile2.Location);
            gfx.DrawString(valMobile3.Text, valueFont, XBrushes.Black, valMobile3.Location);
            gfx.DrawString(valMobile3.Text, valueFont, XBrushes.Black, valMobile4.Location);

            gfx.DrawString(lblAddress.Text, labelFont, XBrushes.Black, lblAddress.Location);
            gfx.DrawString(valAddress1.Text, valueFont, XBrushes.Black, valAddress1.Location);
            gfx.DrawString(valAddress2.Text, valueFont, XBrushes.Black, valAddress2.Location);
            gfx.DrawString(valAddress3.Text, valueFont, XBrushes.Black, valAddress3.Location);
            gfx.DrawString(valAddress3.Text, valueFont, XBrushes.Black, valAddress4.Location);

            gfx.DrawString(lblPurpose.Text, labelFont, XBrushes.Black, lblPurpose.Location);
            gfx.DrawString(valPurpose.Text, valueFont, XBrushes.Black, valPurpose.Location);
            gfx.DrawString(lblArticles.Text, labelFont, XBrushes.Black, lblArticles.Location);
            gfx.DrawString(valArticles.Text, valueFont, XBrushes.Black, valArticles.Location);
            gfx.DrawString(lblMoney.Text, labelFont, XBrushes.Black, lblMoney.Location);
            gfx.DrawString(valMoney.Text, valueFont, XBrushes.Black, valMoney.Location);

            gfx.DrawString(lblPermission.Text, bottomFont, XBrushes.Black, lblPermission.Location);
            gfx.DrawString(lblSplPermission.Text, bottomFont, XBrushes.Black, lblSplPermission.Location);
            gfx.DrawString(lblDptyJailorH.Text, bottomFont, XBrushes.Black, lblDptyJailorH.Location);
            gfx.DrawString(lblDptyJailorE.Text, bottomFont, XBrushes.Black, lblDptyJailorE.Location);
            gfx.DrawString(lblJailorH.Text, bottomFont, XBrushes.Black, lblJailorH.Location);
            gfx.DrawString(lblJailorE.Text, bottomFont, XBrushes.Black, lblJailorE.Location);
            gfx.DrawString(lblDptySuperintendentH.Text, bottomFont, XBrushes.Black, lblDptySuperintendentH.Location);
            gfx.DrawString(lblSuperintendentH.Text, bottomFont, XBrushes.Black, lblSuperintendentH.Location);
            gfx.DrawString(lblSuperintendentE.Text, bottomFont, XBrushes.Black, lblSuperintendentE.Location);
            gfx.DrawString(lblInstruction.Text, bottomFont, XBrushes.Black, lblInstruction.Location);



            pdfPass.Save("pdfPassPrint");
            Process.Start("pdfPassPrint");
            FinishedPrinting = true;
        }

       


        private void MulakatPrintScreen_Load(object sender, EventArgs e)
        {
            //Print(this.panel1);
        }

        private void lblPS_Click(object sender, EventArgs e)
        {

        }

        private void lblMobile_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSNo_Click(object sender, EventArgs e)
        {

        }
    }
}
