﻿namespace What_s_That
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.buttonAddFace = new System.Windows.Forms.Button();
            this.imgCamUser = new Emgu.CV.UI.ImageBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddFace
            // 
            this.buttonAddFace.Location = new System.Drawing.Point(71, 294);
            this.buttonAddFace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAddFace.Name = "buttonAddFace";
            this.buttonAddFace.Size = new System.Drawing.Size(169, 26);
            this.buttonAddFace.TabIndex = 2;
            this.buttonAddFace.Text = "Add Face";
            this.buttonAddFace.UseVisualStyleBackColor = true;
            this.buttonAddFace.Click += new System.EventHandler(this.buttonAddFace_Click);
            // 
            // imgCamUser
            // 
            this.imgCamUser.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.imgCamUser.Location = new System.Drawing.Point(284, 15);
            this.imgCamUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imgCamUser.Name = "imgCamUser";
            this.imgCamUser.Size = new System.Drawing.Size(448, 338);
            this.imgCamUser.TabIndex = 2;
            this.imgCamUser.TabStop = false;
            this.imgCamUser.Click += new System.EventHandler(this.ImgCamUser_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(121, 262);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(117, 22);
            this.nameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 266);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(748, 383);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.imgCamUser);
            this.Controls.Add(this.buttonAddFace);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainWindow";
            this.Text = "What\'s That?";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonAddFace;
        private Emgu.CV.UI.ImageBox imgCamUser;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
    }
}

