namespace Zst_Projekt_EtapII
{
    partial class WatchForm
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
            this.button_Proceed = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.textBox_timeDelay = new System.Windows.Forms.TextBox();
            this.textBox_numberOfIt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Proceed
            // 
            this.button_Proceed.Location = new System.Drawing.Point(32, 143);
            this.button_Proceed.Name = "button_Proceed";
            this.button_Proceed.Size = new System.Drawing.Size(75, 23);
            this.button_Proceed.TabIndex = 0;
            this.button_Proceed.Text = "Proceed";
            this.button_Proceed.UseVisualStyleBackColor = true;
            this.button_Proceed.Click += new System.EventHandler(this.button_Proceed_Click);
            // 
            // button_Back
            // 
            this.button_Back.Location = new System.Drawing.Point(173, 143);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(75, 23);
            this.button_Back.TabIndex = 1;
            this.button_Back.Text = "Back";
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // textBox_timeDelay
            // 
            this.textBox_timeDelay.Location = new System.Drawing.Point(160, 55);
            this.textBox_timeDelay.Name = "textBox_timeDelay";
            this.textBox_timeDelay.Size = new System.Drawing.Size(100, 20);
            this.textBox_timeDelay.TabIndex = 2;
            this.textBox_timeDelay.Text = "5";
            // 
            // textBox_numberOfIt
            // 
            this.textBox_numberOfIt.Location = new System.Drawing.Point(160, 97);
            this.textBox_numberOfIt.Name = "textBox_numberOfIt";
            this.textBox_numberOfIt.Size = new System.Drawing.Size(100, 20);
            this.textBox_numberOfIt.TabIndex = 3;
            this.textBox_numberOfIt.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose parametres for watch command";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time delay in seconds:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Number of iterations:";
            // 
            // WatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 173);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_numberOfIt);
            this.Controls.Add(this.textBox_timeDelay);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_Proceed);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WatchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WatchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Proceed;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.TextBox textBox_timeDelay;
        private System.Windows.Forms.TextBox textBox_numberOfIt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}