using ExifLibrary;
using NExifTool;
using NExifTool.Writer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using File = System.IO.File;
using Tag = NExifTool.Tag;

namespace ChangeMetadataJPG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnChange_Click(object sender, EventArgs e)
        {
            BtnChange.Enabled = false;

            SearchOption searchOption = SearchOption.TopDirectoryOnly;
            if(chkScanSubfolder.Checked)
                searchOption = SearchOption.AllDirectories;

            var dirPaths = txtFolderPath.Lines;
            List<string> filePaths = new List<string>();
            
            foreach (string dir in dirPaths)
            {
                foreach (string ext in txtExtension.Text.Split(';'))
                {
                    var tmp = Directory.GetFiles(dir, $"*{ext.Trim()}", searchOption);
                    filePaths.AddRange(tmp);
                }
            }
            bool isDone = false;

            Thread thread = new Thread(async () =>
            {
                int count = 0;
                int total = filePaths.Count;
                foreach (string filePath in filePaths)
                {
                    count++;

                    try
                    {
                        //ChangeInfo(filePath);
                        await ChangeInfoAsync(filePath);

                        AddLog($"{count/ total} Xong {filePath}", Color.DarkGreen);
                    }
                    catch (Exception ex)
                    {
                        AddLog($"Lỗi {ex.Message}", Color.Red);
                    }
                }

                isDone = true;
            })
            {
                IsBackground = false
            };

            thread.Start();

            while (!isDone)
                await Task.Delay(100);

            BtnChange.Enabled = true;

            AddLog($"Xong {filePaths.Count} tệp", Color.DarkGreen);
        }

        async Task ChangeInfoAsync(string filePath)
        {
            filePath = "\\\\?\\" + filePath;
            string dirPath = Path.GetDirectoryName(filePath);
            string title = new DirectoryInfo(dirPath).Name;

            // https://github.com/oozcitak/exiflibrary
            var file = ImageFile.FromFile(filePath);
            // note the explicit cast to ushort
            //file.Properties.Set(ExifTag.ISOSpeedRatings, 300); // Ok
            file.Properties.Set(ExifTag.WindowsSubject, title); // OK
            file.Properties.Set(ExifTag.WindowsTitle, title);
            file.Save(filePath);
            file = null;

            List<Operation> UPDATES = new List<Operation> {
                new SetOperation(new Tag("title", title)), // OK
                //new SetOperation(new Tag("subject", COMMENT)), // Not OK
                //new SetOperation(new Tag("xp subject", COMMENT)), // Not OK
                new SetOperation(new Tag("keywords", new string[] { title })) // OK
            };

            // https://github.com/AerisG222/NExifTool
            var opts = new ExifToolOptions
            {
                ExifToolPath = Path.Combine(Directory.GetCurrentDirectory(), "exiftool(-k).exe")
            };
            var et = new ExifTool(opts);
            var src = new FileStream(filePath, FileMode.Open);

            var result = await et.WriteTagsAsync(src, UPDATES);
            src.Close();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                // Copy data from sourceStream to fileStream
                result.Output.CopyTo(fileStream);
            }
        }

        public void addImageComment(string imageFlePath, string comments)
        {
            string jpegDirectory = Path.GetDirectoryName(imageFlePath);
            string jpegFileName = Path.GetFileNameWithoutExtension(imageFlePath);

            BitmapDecoder decoder = null;
            BitmapFrame bitmapFrame = null;
            BitmapMetadata metadata = null;
            FileInfo originalImage = new FileInfo(imageFlePath);

            if (File.Exists(imageFlePath))
            {
                // load the jpg file with a JpegBitmapDecoder    
                using (Stream jpegStreamIn = File.Open(imageFlePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    decoder = new JpegBitmapDecoder(jpegStreamIn, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                }

                bitmapFrame = decoder.Frames[0];
                metadata = (BitmapMetadata)bitmapFrame.Metadata;

                if (bitmapFrame != null)
                {
                    BitmapMetadata metaData = (BitmapMetadata)bitmapFrame.Metadata.Clone();

                    if (metaData != null)
                    {
                        // modify the metadata   
                        metaData.SetQuery("/app1/ifd/exif:{uint=40092}", comments);

                        // get an encoder to create a new jpg file with the new metadata.      
                        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(bitmapFrame, bitmapFrame.Thumbnail, metaData, bitmapFrame.ColorContexts));
                        //string jpegNewFileName = Path.Combine(jpegDirectory, "JpegTemp.jpg");

                        // Delete the original
                        originalImage.Delete();

                        // Save the new image 
                        using (Stream jpegStreamOut = File.Open(imageFlePath, FileMode.CreateNew, FileAccess.ReadWrite))
                        {
                            encoder.Save(jpegStreamOut);
                        }
                    }
                }
            }
        }

        private void AddLog(string content, Color color)
        {
            txtLog.BeginInvoke(new Action(() =>
            {
                if (txtLog.Lines.Length >= 2000)
                    txtLog.Text = "";

                // Lưu vị trí bắt đầu của đoạn văn bản sẽ thêm vào
                int start = txtLog.TextLength;
                content = $"{DateTime.Now.ToShortTimeString()}: {content}\r\n";
                // Thêm nội dung vào RichTextBox
                txtLog.AppendText(content);

                // Chọn đoạn văn bản vừa thêm vào
                txtLog.Select(start, content.Length);

                // Đặt màu sắc cho đoạn văn bản vừa chọn
                txtLog.SelectionColor = color;

                // Bỏ chọn đoạn văn bản
                txtLog.SelectionLength = 0;
            }));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // ChangeInfo(@"C:\Users\ngoch\Desktop\New folder\Mockup\Test product mockup\Title product\2.jpg");
            await ChangeInfoAsync(@"C:\Users\ngoch\Desktop\New folder\Mockup\Test product mockup\Title product\2.jpg");
            //addImageComment(@"C:\Users\ngoch\Desktop\New folder\Mockup\Test product mockup\Title product\be051fb4-809a-4e6e-aa0e-6d0c378f4679.jpg", "Test");
        }

        private void BtnBrowserFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
                txtFolderPath.Text = dialog.SelectedPath;
        }
    }
}
