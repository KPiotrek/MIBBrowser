namespace Zst_Projekt_EtapII
{
    partial class TableViewerForm
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
            this.dataGridView_TABLE = new System.Windows.Forms.DataGridView();
            this.button_Table_Back = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Table_GetTableOID = new System.Windows.Forms.Button();
            this.textBox_Table_OID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TABLE)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_TABLE
            // 
            this.dataGridView_TABLE.AllowUserToAddRows = false;
            this.dataGridView_TABLE.AllowUserToDeleteRows = false;
            this.dataGridView_TABLE.AllowUserToResizeColumns = false;
            this.dataGridView_TABLE.AllowUserToResizeRows = false;
            this.dataGridView_TABLE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_TABLE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_TABLE.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_TABLE.CausesValidation = false;
            this.dataGridView_TABLE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TABLE.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_TABLE.EnableHeadersVisualStyles = false;
            this.dataGridView_TABLE.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView_TABLE.Location = new System.Drawing.Point(14, 109);
            this.dataGridView_TABLE.MultiSelect = false;
            this.dataGridView_TABLE.Name = "dataGridView_TABLE";
            this.dataGridView_TABLE.ReadOnly = true;
            this.dataGridView_TABLE.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView_TABLE.Size = new System.Drawing.Size(560, 249);
            this.dataGridView_TABLE.TabIndex = 22;
            // 
            // button_Table_Back
            // 
            this.button_Table_Back.Location = new System.Drawing.Point(14, 364);
            this.button_Table_Back.Name = "button_Table_Back";
            this.button_Table_Back.Size = new System.Drawing.Size(560, 30);
            this.button_Table_Back.TabIndex = 24;
            this.button_Table_Back.Text = "BACK";
            this.button_Table_Back.UseVisualStyleBackColor = true;
            this.button_Table_Back.Click += new System.EventHandler(this.button_Table_Back_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Choose table OID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(17, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(557, 31);
            this.label4.TabIndex = 28;
            this.label4.Text = "TABLE VIEWER";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Table_GetTableOID
            // 
            this.button_Table_GetTableOID.Location = new System.Drawing.Point(328, 48);
            this.button_Table_GetTableOID.Name = "button_Table_GetTableOID";
            this.button_Table_GetTableOID.Size = new System.Drawing.Size(246, 55);
            this.button_Table_GetTableOID.TabIndex = 29;
            this.button_Table_GetTableOID.Text = "Get Table";
            this.button_Table_GetTableOID.UseVisualStyleBackColor = true;
            this.button_Table_GetTableOID.Click += new System.EventHandler(this.button_Table_GetTableOID_Click);
            // 
            // textBox_Table_OID
            // 
            this.textBox_Table_OID.Location = new System.Drawing.Point(14, 71);
            this.textBox_Table_OID.Name = "textBox_Table_OID";
            this.textBox_Table_OID.Size = new System.Drawing.Size(301, 20);
            this.textBox_Table_OID.TabIndex = 30;
            // 
            // TableViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 399);
            this.Controls.Add(this.textBox_Table_OID);
            this.Controls.Add(this.button_Table_GetTableOID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Table_Back);
            this.Controls.Add(this.dataGridView_TABLE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TableViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TableViewerForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TABLE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_TABLE;
        private System.Windows.Forms.Button button_Table_Back;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Table_GetTableOID;
        private System.Windows.Forms.TextBox textBox_Table_OID;
    }
}