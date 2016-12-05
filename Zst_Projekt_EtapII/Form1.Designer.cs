namespace Zst_Projekt_EtapII
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnGetNext = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnWatch = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilepath = new System.Windows.Forms.TextBox();
            this.cbObjects = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(120, 9);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(61, 43);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load MIB";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(-1, 53);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(78, 23);
            this.btnGet.TabIndex = 1;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnGetNext
            // 
            this.btnGetNext.Location = new System.Drawing.Point(83, 53);
            this.btnGetNext.Name = "btnGetNext";
            this.btnGetNext.Size = new System.Drawing.Size(78, 23);
            this.btnGetNext.TabIndex = 2;
            this.btnGetNext.Text = "GetNext";
            this.btnGetNext.UseVisualStyleBackColor = true;
            this.btnGetNext.Click += new System.EventHandler(this.btnGetNext_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(167, 53);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "GetBulk";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnWatch
            // 
            this.btnWatch.Location = new System.Drawing.Point(251, 53);
            this.btnWatch.Name = "btnWatch";
            this.btnWatch.Size = new System.Drawing.Size(78, 23);
            this.btnWatch.TabIndex = 4;
            this.btnWatch.Text = "Watch";
            this.btnWatch.UseVisualStyleBackColor = true;
            this.btnWatch.Click += new System.EventHandler(this.btnWatch_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(-1, 257);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(78, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Remove ";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(83, 257);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(78, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "Remove All";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(167, 257);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(78, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "Search";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(251, 257);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(78, 23);
            this.button9.TabIndex = 8;
            this.button9.Text = "Refresh";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 9;
            // 
            // tbFilepath
            // 
            this.tbFilepath.Location = new System.Drawing.Point(2, 27);
            this.tbFilepath.Name = "tbFilepath";
            this.tbFilepath.Size = new System.Drawing.Size(115, 20);
            this.tbFilepath.TabIndex = 10;
            this.tbFilepath.Text = "C:\\Users\\Piotrek\\Desktop\\MIBbasic.xml";
            this.tbFilepath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbObjects
            // 
            this.cbObjects.FormattingEnabled = true;
            this.cbObjects.Location = new System.Drawing.Point(187, 26);
            this.cbObjects.Name = "cbObjects";
            this.cbObjects.Size = new System.Drawing.Size(142, 21);
            this.cbObjects.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Choose object name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Filepath to MIB";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 281);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbObjects);
            this.Controls.Add(this.tbFilepath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnWatch);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnGetNext);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MIB Browser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnGetNext;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnWatch;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilepath;
        private System.Windows.Forms.ComboBox cbObjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

