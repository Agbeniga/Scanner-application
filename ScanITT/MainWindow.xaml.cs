using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WIA;
using System.IO;
using System.Runtime.InteropServices;
using Aspose.Pdf;


namespace ScanITT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Scanned images/folder path
        private const string path = @"C:\Scannned Files";
        
        // Default storage path
        //private string filePath = path + @"\scan.jpg";

        //
        private int counter { get; set; }

        // file locations of images that would be added to pdf 
        private List<string> pdfimages = new List<string>();

        private FileType _fileType;

        enum FileType { PNG, JPG, PDF, WORD}

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Scan_Document(object sender, RoutedEventArgs e)
        {

            // Create a DeviceManager instance
            //var deviceManager = new DeviceManager();

            // Disable scan button when scanning document
            Scan_Btn.IsEnabled = false;

            try
            {

                // Get info about first scanner device
                //DeviceInfo firstScannerAvailable = null;

                // Loop through the list of devices
                //for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                //{

                    // Skip the device if it's not a scanner
                    //if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    //{
                    //    continue;
                    //}

                    //Console.WriteLine(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());

                    // Adds the device name to the dropdown/combobox
                //    AvailableScanners.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());

                //}


                //if(deviceManager.DeviceInfos.Count > 0) { 

                //firstScannerAvailable = deviceManager.DeviceInfos[1];

                //AvailableScanners.SelectedIndex = 0;

                //Connect to the first available scanner
                //var device = firstScannerAvailable.Connect();

                // Select the scanner
                //var scannerItem = device.Items[1];

                //int resolution = 150;
                //int width_pixel = 1250;
                //int height_pixel = 1700;
                //int color_mode = 1;
                //AdjustScannerSettings(scannerItem, resolution, 0, 0, width_pixel, height_pixel, 0, 0, color_mode);


                //CommonDialogClass dlg = new CommonDialogClass();

                //object scanResult = dlg.ShowTransfer(scannerItem, WIA.FormatID.wiaFormatPNG, true);

                //if (scanResult != null)
                //{
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path + @"\" + $"scan0.png");
                bitmap.EndInit();
                previewImage.Source = bitmap;
                //switch (_fileType)
                //{
                //    case FileType.PNG:
                //        filePath = path + @"\" + $"scan{counter}.png";
                //        previewImage.Source = Save_to_image(filePath,  scanResult);
                //        break;
                //    case FileType.JPG:
                //        filePath = path + @"\" + $"scan{counter}.jpg";
                //        previewImage.Source = Save_to_image(filePath, scanResult);
                //        break;
                //    default:
                //        filePath = path + @"\" + $"scan{counter}.jpg";
                //        previewImage.Source = Save_to_image(filePath, scanResult);
                //        break;
                //}
                //}

                Save_Btn.IsEnabled = true;
                Scan_Btn.IsEnabled = true;
                //}
                //else
                //{

                //}

            }
            catch (COMException exep)
            {
                // Convert the error code to UINT
                uint errorCode = (uint)exep.ErrorCode;

                // see the error codes
                if (errorCode == 0x80210006)
                {
                   
                    errorMessage.Text = "The scanner is busy or isn't ready";
                    Console.WriteLine("The scanner is busy or isn't ready");
                }
                else if (errorCode == 0x80210064)
                {
                    errorMessage.Text = "The scanning process has been cancelled.";
                    Console.WriteLine("The scanning process has been cancelled.");
                }
                else if (errorCode == 0x8021000C)
                {
                    errorMessage.Text = "There is an incorrect setting on the WIA device.";
                    Console.WriteLine("There is an incorrect setting on the WIA device.");
                }
                else if (errorCode == 0x80210005)
                {
                    errorMessage.Text = "The device is offline. Make sure the device is powered on and connected to the PC.";
                    Console.WriteLine("The device is offline. Make sure the device is powered on and connected to the PC.");
                }
                else if (errorCode == 0x80210001)
                {
                    errorMessage.Text = "An unknown error has occurred with the WIA device.";
                    Console.WriteLine("An unknown error has occurred with the WIA device.");
                }
                errorPopup.IsOpen = true;
                Scan_Btn.IsEnabled = true;
            }
        }

        private void existPopup(object sender, RoutedEventArgs e)
        {
            errorPopup.IsOpen = false;
        }
        /// <summary>
        /// Adjusts the settings of the scanner with the providen parameters.
        /// </summary>
        /// <param name="scannnerItem">Scanner Item</param>
        /// <param name="scanResolutionDPI">Provide the DPI resolution that should be used e.g 150</param>
        /// <param name="scanStartLeftPixel"></param>
        /// <param name="scanStartTopPixel"></param>
        /// <param name="scanWidthPixels"></param>
        /// <param name="scanHeightPixels"></param>
        /// <param name="brightnessPercents"></param>
        /// <param name="contrastPercents">Modify the contrast percent</param>
        /// <param name="colorMode">Set the color mode</param>
        private static void AdjustScannerSettings(IItem scannnerItem, int scanResolutionDPI, int scanStartLeftPixel, int scanStartTopPixel, int scanWidthPixels, int scanHeightPixels, int brightnessPercents, int contrastPercents, int colorMode)
        {
            const string WIA_SCAN_COLOR_MODE = "6146";
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
            const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
            const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scanStartLeftPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scanStartTopPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, scanWidthPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, scanHeightPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightnessPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrastPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_COLOR_MODE, colorMode);
        }

        /// <summary>
        /// Modify a WIA property
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="propName"></param>
        /// <param name="propValue"></param>
        private static void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
            Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }

        private static BitmapImage Save_to_image(string imagePath, object scanResult)
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            ImageFile imageFile = (ImageFile)scanResult;
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }

                // Save Image !
                imageFile.SaveFile(imagePath);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath);
                bitmap.EndInit();
           
            return bitmap;

            
        }

        
        private void Add_To_Pdf(object sender, RoutedEventArgs e)
        {
            counter++;
            PdfPagesText.Visibility = Visibility.Visible;

            System.Windows.Controls.Image pageImage = new System.Windows.Controls.Image();
           
            pageImage.Height = 100;
            pageImage.Width = 70;
            pageImage.Source = previewImage.Source;
          
            PdfImages.Children.Add(pageImage);
            pdfimages.Add(previewImage.Source.ToString());

            //AddToPdf.IsEnabled = false;
        }

        private void Upload_To_Cloud(object sender, RoutedEventArgs e)
        {

        }

        private void Save_to_PC(object sender, RoutedEventArgs e)
        {
            //FileStream fileStream;
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            
            switch (_fileType)
            {
                case FileType.PNG:
                    saveFileDialog.Filter = "Png file (*.png)|*.png";
                    break;
                case FileType.JPG:
                    saveFileDialog.Filter = "Jpg file (*.jpg)|*.jpg";
                    break;
                case FileType.PDF:
                    saveFileDialog.Filter = "Pdf file (*.pdf)|*.pdf";

                    // Initialize new PDF document
                    Document doc = new Document();

                    // Add empty page in empty document
                    Aspose.Pdf.Page page = doc.Pages.Add();

                    Aspose.Pdf.Image image = new Aspose.Pdf.Image();

                    for (int i = 0; i < pdfimages.Count; i++)
                    {

                        image.File = pdfimages[i];

                        //Add image on a page
                        page.Paragraphs.Add(image);
                    }

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string pdfPath = saveFileDialog.FileName;
                        Console.WriteLine(pdfPath);
                        doc.Save(pdfPath);
                    }
                    break;
                case FileType.WORD:
                    saveFileDialog.Filter = "Word file (*.doc)|(*.docx)|*.doc|*.docx";
                    break;
                default:
                    break;
            }
           
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            //Save output PDF file


            //if (File.Exists(filePath))
            //{
            //    File.Delete(filePath);
            //}
            if (saveFileDialog.ShowDialog() == true)
            {
                string pdfPath = saveFileDialog.FileName.ToString();
                Console.WriteLine(pdfPath);

            }

        }

        private void AvailableScanners_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Png_Button(object sender, RoutedEventArgs e)
        {
            pngButton.BorderBrush = new SolidColorBrush(Colors.Blue);
            jpgButton.BorderBrush = new SolidColorBrush(Colors.Black);
            pdfButton.BorderBrush = new SolidColorBrush(Colors.Black);
            wordButton.BorderBrush = new SolidColorBrush(Colors.Black);

            _fileType = FileType.PNG;
            AddToPdf.IsEnabled = false;

        }

        private void Jpg_Button(object sender, RoutedEventArgs e)
        {
            pngButton.BorderBrush = new SolidColorBrush(Colors.Black);
            jpgButton.BorderBrush = new SolidColorBrush(Colors.Blue);
            pdfButton.BorderBrush = new SolidColorBrush(Colors.Black);
            wordButton.BorderBrush = new SolidColorBrush(Colors.Black);

            _fileType = FileType.JPG;

            AddToPdf.IsEnabled = false;
        }

        private void Pdf_Button(object sender, RoutedEventArgs e)
        {
            AddToPdf.IsEnabled = true;
            pngButton.BorderBrush = new SolidColorBrush(Colors.Black);
            jpgButton.BorderBrush = new SolidColorBrush(Colors.Black);
            pdfButton.BorderBrush = new SolidColorBrush(Colors.Blue);
            wordButton.BorderBrush = new SolidColorBrush(Colors.Black);

            _fileType = FileType.PDF;
        }

        private void word_Button(object sender, RoutedEventArgs e)
        {
            pngButton.BorderBrush = new SolidColorBrush(Colors.Black);
            jpgButton.BorderBrush = new SolidColorBrush(Colors.Black);
            pdfButton.BorderBrush = new SolidColorBrush(Colors.Black);
            wordButton.BorderBrush = new SolidColorBrush(Colors.Blue);

            _fileType = FileType.WORD;
            AddToPdf.IsEnabled = false;
        }
    }
}
