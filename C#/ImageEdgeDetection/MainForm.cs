/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.ComponentModel;

/*
 * REVIEW: 
 * In this class, we need to make methods more functionnal, and not dependent of class properties. 
 * This way, it is easier to test. 
 * 
 */


namespace ImageEdgeDetection
{
    public partial class MainForm : Form
    {

        private Bitmap edited = null;
        private Bitmap originalBitmap = null;
        private Bitmap modifiedBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;
        private Bitmap filterBitmap = null;
        private bool filterButtonEnabled = false;
        private bool dropListEnabled = false;

        public MainForm()
        {
            InitializeComponent();
            UpdateButtons(); 
            cmbEdgeDetection.SelectedIndex = 0;
            btnSaveNewImage.Enabled = false;
        }


        //Method to load a new picture
        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            // REVIEW: Duplicate code btnOpenOriginal_Click & btnSaveNewImage_Click
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                originalBitmap = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                streamReader.Close();

                previewBitmap = originalBitmap.CopyToSquareCanvas(picPreview.Width);
                picPreview.Image = previewBitmap;
                resultBitmap = originalBitmap;
                filterBitmap = originalBitmap;
                modifiedBitmap = originalBitmap;

                ApplyFilter(true);
            }
        }

        //Method to save a picture
        private void btnSaveNewImage_Click(object sender, EventArgs e)
        {
            ApplyFilter(false);

            if (resultBitmap != null)
            {
                // REVIEW: Duplicate code btnOpenOriginal_Click & btnSaveNewImage_Click
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Specify a file name and file path";
                sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
                sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")
                    {
                        imgFormat = ImageFormat.Bmp;
                    }
                    else if (fileExtension == "JPG")
                    {
                        imgFormat = ImageFormat.Jpeg;
                    }

                    StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                    resultBitmap.Save(streamWriter.BaseStream, imgFormat);
                    streamWriter.Flush();
                    streamWriter.Close();

                    resultBitmap = null;
                }
            }
        }

        // REVIEW: In this method, prefer a Bitmap return with the filtered image.
        //Method to apply edge detection with a dropdownlist
        private void ApplyFilter(bool preview)
        {
            if (previewBitmap == null || cmbEdgeDetection.SelectedIndex == -1)
            {
                return;
            }

            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;


            if (preview == true)
            {
                selectedSource = (Bitmap)picPreview.Image;
            }
            else
            {
                selectedSource = originalBitmap;
            }

            if (selectedSource != null)
            {
                filterButtonEnabled = false;

                if (cmbEdgeDetection.SelectedItem.ToString() == "None")
                {
                    filterButtonEnabled = true;
                    dropListEnabled = false;
                    modifiedBitmap = originalBitmap;
                    picPreview.Image = originalBitmap;
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Sobel 3x3")
                {
                    bitmapResult = selectedSource.Sobel3x3Filter(false);
                }
              
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Prewitt")
                {
                    bitmapResult = selectedSource.PrewittFilter(false);
                }
               
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Kirsch")
                {
                    bitmapResult = selectedSource.KirschFilter(false);
                }
 

                UpdateButtons();
            }

            if (bitmapResult != null)
            {
                if (preview == true)
                {
                    picPreview.Image = bitmapResult;
                }
                else
                {
                    resultBitmap = (Bitmap)picPreview.Image;
                }
            }
        }


        private void NeighbourCountValueChangedEventHandler(object sender, EventArgs e)
        {
            ApplyFilter(true);
        }

        // REVIEW: Prefer a event code by button instead of testing button name. This can cause issue if the button name change
        //Method to choose a filter between none and 2 others (0,1,2)
        private void FilterButtons(object sender, EventArgs e)
        {
            btnSaveNewImage.Enabled = true;

            dropListEnabled = true;
            cmbEdgeDetection.Enabled = dropListEnabled;

            string button = sender.ToString();
            string filter1 = "System.Windows.Forms.Button, Text: None";
            string filter2 = "System.Windows.Forms.Button, Text: Rainbow";
 
            if (button.Equals(filter1)){
                picPreview.Image = originalBitmap;
                modifiedBitmap = originalBitmap;
            }
            else {

                //var mf = new Filters();
                var mf = new ImageFilters();

                if (button.Equals(filter2))
                {
                    edited = mf.RainbowFilter(modifiedBitmap);
                }
                else
                {
                    //edited = mf.ApplyFilterSwap(modifiedBitmap); 
                    edited = mf.SwapFilter(modifiedBitmap);
                }
                modifiedBitmap = edited;
                resultBitmap = modifiedBitmap;
                picPreview.Image = modifiedBitmap;
            }       

        }

        //Method to enable the buttons and dropdownlist
        private void UpdateButtons()
        {
            buttonFilter1.Enabled = filterButtonEnabled;
            buttonFilter2.Enabled = filterButtonEnabled;
            buttonFilter3.Enabled = filterButtonEnabled;
            cmbEdgeDetection.Enabled = dropListEnabled;
        }

        // REVIEW: Remove empty functions
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        // REVIEW: Remove empty functions
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        // REVIEW: Remove comments
        ////Give the filter to the worker
        //private void BgworkerDoWork(object sender, DoWorkEventArgs e)
        //{
        //    rw.DoBgWorker(sender, e, picPreview);

        //}

        ////when the worker work, the progress bar is updated
        //private void BgWorkerProgress(object sender, ProgressChangedEventArgs e)
        //{
        //    p.BgWorkerProg(sender, e, pbtsTraitementPrct, lbltsPrct);
        //}
    }
}
