﻿
using System;
using System.Windows.Forms;

namespace VSIXProject1
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
            this.doneButton = new System.Windows.Forms.Button();
            this.managedPathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browseManaged = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.modNameBox = new System.Windows.Forms.TextBox();
            this.versionBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.authorNameBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addAssCSfDll = new System.Windows.Forms.CheckBox();
            this.addHarmonyDll = new System.Windows.Forms.CheckBox();
            this.addcInputDll = new System.Windows.Forms.CheckBox();
            this.addUIDll = new System.Windows.Forms.CheckBox();
            this.addAssCSDll = new System.Windows.Forms.CheckBox();
            this.addPlaymakerDll = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.setupOnGUI = new System.Windows.Forms.CheckBox();
            this.setupOnPreLoad = new System.Windows.Forms.CheckBox();
            this.setupPostLoad = new System.Windows.Forms.CheckBox();
            this.setupFixedUpdate = new System.Windows.Forms.CheckBox();
            this.setupUpdate = new System.Windows.Forms.CheckBox();
            this.setupOnNewGame = new System.Windows.Forms.CheckBox();
            this.setupOnSave = new System.Windows.Forms.CheckBox();
            this.setupOnMenuLoad = new System.Windows.Forms.CheckBox();
            this.setupOnLoad = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.doneButton.Location = new System.Drawing.Point(278, 400);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 21);
            this.doneButton.TabIndex = 0;
            this.doneButton.Text = "Done";
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // managedPathBox
            // 
            this.managedPathBox.Location = new System.Drawing.Point(12, 64);
            this.managedPathBox.Name = "managedPathBox";
            this.managedPathBox.ReadOnly = true;
            this.managedPathBox.Size = new System.Drawing.Size(249, 20);
            this.managedPathBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "MSCLoader Template Config";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // browseManaged
            // 
            this.browseManaged.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browseManaged.Location = new System.Drawing.Point(267, 64);
            this.browseManaged.Name = "browseManaged";
            this.browseManaged.Size = new System.Drawing.Size(87, 20);
            this.browseManaged.TabIndex = 3;
            this.browseManaged.Text = "Browse...";
            this.browseManaged.Click += new System.EventHandler(this.browseManaged_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "My summer car Managed folder: ";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name of your mod:";
            // 
            // modNameBox
            // 
            this.modNameBox.Location = new System.Drawing.Point(12, 113);
            this.modNameBox.Name = "modNameBox";
            this.modNameBox.Size = new System.Drawing.Size(127, 20);
            this.modNameBox.TabIndex = 6;
            // 
            // versionBox
            // 
            this.versionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.versionBox.Location = new System.Drawing.Point(267, 113);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(86, 20);
            this.versionBox.TabIndex = 7;
            this.versionBox.Text = "1.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Version:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "* You can change all of this later in code.";
            // 
            // authorNameBox
            // 
            this.authorNameBox.Location = new System.Drawing.Point(145, 113);
            this.authorNameBox.Name = "authorNameBox";
            this.authorNameBox.Size = new System.Drawing.Size(116, 20);
            this.authorNameBox.TabIndex = 10;
            this.authorNameBox.Text = "Your name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Author:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.addAssCSfDll);
            this.groupBox1.Controls.Add(this.addHarmonyDll);
            this.groupBox1.Controls.Add(this.addcInputDll);
            this.groupBox1.Controls.Add(this.addUIDll);
            this.groupBox1.Controls.Add(this.addAssCSDll);
            this.groupBox1.Controls.Add(this.addPlaymakerDll);
            this.groupBox1.Location = new System.Drawing.Point(166, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 155);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add additional references";
            // 
            // addAssCSfDll
            // 
            this.addAssCSfDll.AutoSize = true;
            this.addAssCSfDll.Location = new System.Drawing.Point(6, 134);
            this.addAssCSfDll.Name = "addAssCSfDll";
            this.addAssCSfDll.Size = new System.Drawing.Size(162, 17);
            this.addAssCSfDll.TabIndex = 5;
            this.addAssCSfDll.Text = "Assembly-CSharp-firstpass.dll";
            this.addAssCSfDll.UseVisualStyleBackColor = true;
            // 
            // addHarmonyDll
            // 
            this.addHarmonyDll.AutoSize = true;
            this.addHarmonyDll.Location = new System.Drawing.Point(6, 111);
            this.addHarmonyDll.Name = "addHarmonyDll";
            this.addHarmonyDll.Size = new System.Drawing.Size(87, 17);
            this.addHarmonyDll.TabIndex = 4;
            this.addHarmonyDll.Text = "0Harmony.dll";
            this.addHarmonyDll.UseVisualStyleBackColor = true;
            // 
            // addcInputDll
            // 
            this.addcInputDll.AutoSize = true;
            this.addcInputDll.Location = new System.Drawing.Point(6, 65);
            this.addcInputDll.Name = "addcInputDll";
            this.addcInputDll.Size = new System.Drawing.Size(69, 17);
            this.addcInputDll.TabIndex = 3;
            this.addcInputDll.Text = "cInput.dll";
            this.addcInputDll.UseVisualStyleBackColor = true;
            // 
            // addUIDll
            // 
            this.addUIDll.AutoSize = true;
            this.addUIDll.Location = new System.Drawing.Point(6, 88);
            this.addUIDll.Name = "addUIDll";
            this.addUIDll.Size = new System.Drawing.Size(110, 17);
            this.addUIDll.TabIndex = 2;
            this.addUIDll.Text = "UnityEngine.UI.dll";
            this.addUIDll.UseVisualStyleBackColor = true;
            // 
            // addAssCSDll
            // 
            this.addAssCSDll.AutoSize = true;
            this.addAssCSDll.Location = new System.Drawing.Point(6, 42);
            this.addAssCSDll.Name = "addAssCSDll";
            this.addAssCSDll.Size = new System.Drawing.Size(121, 17);
            this.addAssCSDll.TabIndex = 1;
            this.addAssCSDll.Text = "Assembly-CSharp.dll";
            this.addAssCSDll.UseVisualStyleBackColor = true;
            // 
            // addPlaymakerDll
            // 
            this.addPlaymakerDll.AutoSize = true;
            this.addPlaymakerDll.Location = new System.Drawing.Point(6, 19);
            this.addPlaymakerDll.Name = "addPlaymakerDll";
            this.addPlaymakerDll.Size = new System.Drawing.Size(89, 17);
            this.addPlaymakerDll.TabIndex = 0;
            this.addPlaymakerDll.Text = "PlayMaker.dll";
            this.addPlaymakerDll.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.setupOnGUI);
            this.groupBox2.Controls.Add(this.setupOnPreLoad);
            this.groupBox2.Controls.Add(this.setupPostLoad);
            this.groupBox2.Controls.Add(this.setupFixedUpdate);
            this.groupBox2.Controls.Add(this.setupUpdate);
            this.groupBox2.Controls.Add(this.setupOnNewGame);
            this.groupBox2.Controls.Add(this.setupOnSave);
            this.groupBox2.Controls.Add(this.setupOnMenuLoad);
            this.groupBox2.Controls.Add(this.setupOnLoad);
            this.groupBox2.Location = new System.Drawing.Point(12, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 226);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Setup for me";
            // 
            // setupOnGUI
            // 
            this.setupOnGUI.AutoSize = true;
            this.setupOnGUI.Location = new System.Drawing.Point(6, 157);
            this.setupOnGUI.Name = "setupOnGUI";
            this.setupOnGUI.Size = new System.Drawing.Size(90, 17);
            this.setupOnGUI.TabIndex = 9;
            this.setupOnGUI.Text = "Setup OnGUI";
            this.setupOnGUI.UseVisualStyleBackColor = true;
            // 
            // setupOnPreLoad
            // 
            this.setupOnPreLoad.AutoSize = true;
            this.setupOnPreLoad.Location = new System.Drawing.Point(6, 65);
            this.setupOnPreLoad.Name = "setupOnPreLoad";
            this.setupOnPreLoad.Size = new System.Drawing.Size(97, 17);
            this.setupOnPreLoad.TabIndex = 8;
            this.setupOnPreLoad.Text = "Setup PreLoad";
            this.setupOnPreLoad.UseVisualStyleBackColor = true;
            // 
            // setupPostLoad
            // 
            this.setupPostLoad.AutoSize = true;
            this.setupPostLoad.Location = new System.Drawing.Point(6, 111);
            this.setupPostLoad.Name = "setupPostLoad";
            this.setupPostLoad.Size = new System.Drawing.Size(102, 17);
            this.setupPostLoad.TabIndex = 7;
            this.setupPostLoad.Text = "Setup PostLoad";
            this.setupPostLoad.UseVisualStyleBackColor = true;
            // 
            // setupFixedUpdate
            // 
            this.setupFixedUpdate.AutoSize = true;
            this.setupFixedUpdate.Location = new System.Drawing.Point(6, 203);
            this.setupFixedUpdate.Name = "setupFixedUpdate";
            this.setupFixedUpdate.Size = new System.Drawing.Size(117, 17);
            this.setupFixedUpdate.TabIndex = 6;
            this.setupFixedUpdate.Text = "Setup FixedUpdate";
            this.setupFixedUpdate.UseVisualStyleBackColor = true;
            // 
            // setupUpdate
            // 
            this.setupUpdate.AutoSize = true;
            this.setupUpdate.Location = new System.Drawing.Point(6, 180);
            this.setupUpdate.Name = "setupUpdate";
            this.setupUpdate.Size = new System.Drawing.Size(92, 17);
            this.setupUpdate.TabIndex = 5;
            this.setupUpdate.Text = "Setup Update";
            this.setupUpdate.UseVisualStyleBackColor = true;
            // 
            // setupOnNewGame
            // 
            this.setupOnNewGame.AutoSize = true;
            this.setupOnNewGame.Location = new System.Drawing.Point(6, 42);
            this.setupOnNewGame.Name = "setupOnNewGame";
            this.setupOnNewGame.Size = new System.Drawing.Size(121, 17);
            this.setupOnNewGame.TabIndex = 4;
            this.setupOnNewGame.Text = "Setup OnNewGame";
            this.setupOnNewGame.UseVisualStyleBackColor = true;
            // 
            // setupOnSave
            // 
            this.setupOnSave.AutoSize = true;
            this.setupOnSave.Location = new System.Drawing.Point(6, 134);
            this.setupOnSave.Name = "setupOnSave";
            this.setupOnSave.Size = new System.Drawing.Size(96, 17);
            this.setupOnSave.TabIndex = 3;
            this.setupOnSave.Text = "Setup OnSave";
            this.setupOnSave.UseVisualStyleBackColor = true;
            // 
            // setupOnMenuLoad
            // 
            this.setupOnMenuLoad.AutoSize = true;
            this.setupOnMenuLoad.Location = new System.Drawing.Point(6, 19);
            this.setupOnMenuLoad.Name = "setupOnMenuLoad";
            this.setupOnMenuLoad.Size = new System.Drawing.Size(122, 17);
            this.setupOnMenuLoad.TabIndex = 2;
            this.setupOnMenuLoad.Text = "Setup OnMenuLoad";
            this.setupOnMenuLoad.UseVisualStyleBackColor = true;
            // 
            // setupOnLoad
            // 
            this.setupOnLoad.AutoSize = true;
            this.setupOnLoad.Checked = true;
            this.setupOnLoad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.setupOnLoad.Location = new System.Drawing.Point(6, 88);
            this.setupOnLoad.Name = "setupOnLoad";
            this.setupOnLoad.Size = new System.Drawing.Size(95, 17);
            this.setupOnLoad.TabIndex = 1;
            this.setupOnLoad.Text = "Setup OnLoad";
            this.setupOnLoad.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.linkLabel3);
            this.groupBox3.Controls.Add(this.linkLabel2);
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Location = new System.Drawing.Point(166, 296);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 69);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Help + Documentation";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(6, 42);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(95, 13);
            this.linkLabel3.TabIndex = 2;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Order of Execution";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(6, 29);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(136, 13);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "MSCLoader documentation";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 16);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(99, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Template explained";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "My Summer Car",
            "My Winter Car",
            "Both (Universal)"});
            this.comboBox1.Location = new System.Drawing.Point(62, 401);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(128, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 404);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Target: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 433);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.authorNameBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.versionBox);
            this.Controls.Add(this.modNameBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseManaged);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.managedPathBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure MSCLoader Mod";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public static string CustomMessage
        {
            get
            {
                return customMessage;
            }
            set
            {
                customMessage = value;
            }
        }

        #endregion
        private static string customMessage;
        private TextBox managedPathBox;
        private Button doneButton;
        private Label label1;
        private Button browseManaged;
        private Label label2;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label3;
        private TextBox modNameBox;
        private TextBox versionBox;
        private Label label4;
        private Label label5;
        private TextBox authorNameBox;
        private Label label6;
        private GroupBox groupBox1;
        private CheckBox addAssCSfDll;
        private CheckBox addHarmonyDll;
        private CheckBox addcInputDll;
        private CheckBox addUIDll;
        private CheckBox addAssCSDll;
        private CheckBox addPlaymakerDll;
        private GroupBox groupBox2;
        private CheckBox setupOnGUI;
        private CheckBox setupOnPreLoad;
        private CheckBox setupPostLoad;
        private CheckBox setupFixedUpdate;
        private CheckBox setupUpdate;
        private CheckBox setupOnNewGame;
        private CheckBox setupOnSave;
        private CheckBox setupOnMenuLoad;
        private CheckBox setupOnLoad;
        private GroupBox groupBox3;
        private ComboBox comboBox1;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
        private Label label7;
    }
}