using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FRONTIERGUI
{
    
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        /// 
       
        private void InitializeComponent()
        {
            this.listText = new System.Windows.Forms.ListView();
            this.modifiedTextBox = new System.Windows.Forms.TextBox();
            this.originalTextBox = new System.Windows.Forms.TextBox();
            this.modifiedImgBox = new System.Windows.Forms.PictureBox();
            this.originalImgBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.modifiedImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalImgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // listText
            // 
            this.listText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listText.FullRowSelect = true;
            this.listText.GridLines = true;
            this.listText.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listText.HideSelection = false;
            this.listText.Location = new System.Drawing.Point(-2, 10);
            this.listText.Name = "listText";
            this.listText.Size = new System.Drawing.Size(243, 694);
            this.listText.TabIndex = 0;
            this.listText.UseCompatibleStateImageBehavior = false;
            this.listText.View = System.Windows.Forms.View.Details;
            this.listText.SelectedIndexChanged += new System.EventHandler(this.listText_SelectedIndexChanged);
            // 
            // modifiedTextBox
            // 
            this.modifiedTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modifiedTextBox.Location = new System.Drawing.Point(247, 93);
            this.modifiedTextBox.Multiline = true;
            this.modifiedTextBox.Name = "modifiedTextBox";
            this.modifiedTextBox.Size = new System.Drawing.Size(625, 295);
            this.modifiedTextBox.TabIndex = 1;
            this.modifiedTextBox.WordWrap = false;
            this.modifiedTextBox.TextChanged += new System.EventHandler(this.modifiedTextBox_TextChanged);
            // 
            // originalTextBox
            // 
            this.originalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.originalTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.originalTextBox.Location = new System.Drawing.Point(247, 409);
            this.originalTextBox.Multiline = true;
            this.originalTextBox.Name = "originalTextBox";
            this.originalTextBox.ReadOnly = true;
            this.originalTextBox.Size = new System.Drawing.Size(625, 295);
            this.originalTextBox.TabIndex = 2;
            this.originalTextBox.WordWrap = false;
            // 
            // modifiedImgBox
            // 
            this.modifiedImgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modifiedImgBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.modifiedImgBox.Location = new System.Drawing.Point(878, 93);
            this.modifiedImgBox.Name = "modifiedImgBox";
            this.modifiedImgBox.Size = new System.Drawing.Size(698, 295);
            this.modifiedImgBox.TabIndex = 3;
            this.modifiedImgBox.TabStop = false;
            this.modifiedImgBox.Click += new System.EventHandler(this.modifiedImgBox_Click);
            // 
            // originalImgBox
            // 
            this.originalImgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.originalImgBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.originalImgBox.Location = new System.Drawing.Point(878, 409);
            this.originalImgBox.Name = "originalImgBox";
            this.originalImgBox.Size = new System.Drawing.Size(698, 295);
            this.originalImgBox.TabIndex = 4;
            this.originalImgBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(797, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Open Json";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.openFile);
            // 
            // fileNameBox
            // 
            this.fileNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNameBox.Location = new System.Drawing.Point(247, 8);
            this.fileNameBox.Multiline = true;
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.ReadOnly = true;
            this.fileNameBox.Size = new System.Drawing.Size(544, 36);
            this.fileNameBox.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(878, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 36);
            this.button2.TabIndex = 7;
            this.button2.Text = "Save 40PS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonSave40PS);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(1493, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 35);
            this.button3.TabIndex = 8;
            this.button3.Text = "Unpack File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.UnpackFile);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(1493, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 34);
            this.button4.TabIndex = 9;
            this.button4.Text = "Repack File";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.RepackFile);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Moddified Text";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Original Text";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(247, 49);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(625, 16);
            this.progressBar1.TabIndex = 12;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(878, 50);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 35);
            this.button5.TabIndex = 13;
            this.button5.Text = "Save All 40PS";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ButtonSaveAll40PS);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1588, 716);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.fileNameBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.originalImgBox);
            this.Controls.Add(this.modifiedImgBox);
            this.Controls.Add(this.originalTextBox);
            this.Controls.Add(this.modifiedTextBox);
            this.Controls.Add(this.listText);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.modifiedImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originalImgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.ListView listText;
        private System.Windows.Forms.TextBox modifiedTextBox;
        private System.Windows.Forms.TextBox originalTextBox;
        private System.Windows.Forms.PictureBox modifiedImgBox;
        private System.Windows.Forms.PictureBox originalImgBox;
        
        private SP40 sp40;
        private List<Color> pallete = new List<Color>();
        private Bitmap sytemImg;
        private Bitmap kanjiImg;
        private Button button1;
        private TextBox fileNameBox;
        private string fileName;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Label label2;
        private ProgressBar progressBar1;
        private Button button5;
    }
}

