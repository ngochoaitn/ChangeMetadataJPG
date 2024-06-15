namespace ChangeMetadataJPG
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.BtnChange = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkScanSubfolder = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnBrowserFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thư mục chứa ảnh, mỗi thư mục một dòng (paste đường dẫn vào hoặc ấn nút Chọn thư " +
    "mục):";
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolderPath.Location = new System.Drawing.Point(24, 42);
            this.txtFolderPath.Multiline = true;
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(598, 73);
            this.txtFolderPath.TabIndex = 1;
            // 
            // BtnChange
            // 
            this.BtnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChange.Location = new System.Drawing.Point(24, 195);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(97, 29);
            this.BtnChange.TabIndex = 3;
            this.BtnChange.Text = "Thực hiện";
            this.BtnChange.UseVisualStyleBackColor = true;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(326, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Các định dạng sẽ áp dụng (ngăn cách nhau bằng dấu chấm phẩy):";
            // 
            // txtExtension
            // 
            this.txtExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtension.Location = new System.Drawing.Point(24, 169);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(696, 20);
            this.txtExtension.TabIndex = 5;
            this.txtExtension.Text = "jpg;jpeg";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Location = new System.Drawing.Point(31, 257);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(689, 312);
            this.txtLog.TabIndex = 6;
            this.txtLog.Text = "";
            this.txtLog.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nhật ký:";
            // 
            // chkScanSubfolder
            // 
            this.chkScanSubfolder.AutoSize = true;
            this.chkScanSubfolder.Location = new System.Drawing.Point(24, 121);
            this.chkScanSubfolder.Name = "chkScanSubfolder";
            this.chkScanSubfolder.Size = new System.Drawing.Size(158, 17);
            this.chkScanSubfolder.TabIndex = 8;
            this.chkScanSubfolder.Text = "Tự động duyệt thư mục con";
            this.chkScanSubfolder.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(242, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnBrowserFolder
            // 
            this.BtnBrowserFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBrowserFolder.Location = new System.Drawing.Point(628, 42);
            this.BtnBrowserFolder.Name = "BtnBrowserFolder";
            this.BtnBrowserFolder.Size = new System.Drawing.Size(92, 23);
            this.BtnBrowserFolder.TabIndex = 10;
            this.BtnBrowserFolder.Text = "Thêm thư mục";
            this.BtnBrowserFolder.UseVisualStyleBackColor = true;
            this.BtnBrowserFolder.Click += new System.EventHandler(this.BtnBrowserFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 581);
            this.Controls.Add(this.BtnBrowserFolder);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkScanSubfolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnChange);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Tên thư mục sẽ được dùng làm Title, Subject, Tag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button BtnChange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkScanSubfolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnBrowserFolder;
    }
}

