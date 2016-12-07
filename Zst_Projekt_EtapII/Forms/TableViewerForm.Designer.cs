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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_TableName = new System.Windows.Forms.ComboBox();
            this.button_Table_GetTable = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Table_Back = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_TableOID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Table_GetTableOID = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(14, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Choose table name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_TableName
            // 
            this.comboBox_TableName.FormattingEnabled = true;
            this.comboBox_TableName.Location = new System.Drawing.Point(14, 89);
            this.comboBox_TableName.Name = "comboBox_TableName";
            this.comboBox_TableName.Size = new System.Drawing.Size(246, 21);
            this.comboBox_TableName.TabIndex = 22;
            // 
            // button_Table_GetTable
            // 
            this.button_Table_GetTable.Location = new System.Drawing.Point(14, 127);
            this.button_Table_GetTable.Name = "button_Table_GetTable";
            this.button_Table_GetTable.Size = new System.Drawing.Size(246, 31);
            this.button_Table_GetTable.TabIndex = 22;
            this.button_Table_GetTable.Text = "Get Table by Name";
            this.button_Table_GetTable.UseVisualStyleBackColor = true;
            this.button_Table_GetTable.Click += new System.EventHandler(this.button_Table_GetTable_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.CausesValidation = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(14, 164);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(558, 249);
            this.dataGridView1.TabIndex = 22;
            // 
            // button_Table_Back
            // 
            this.button_Table_Back.Location = new System.Drawing.Point(12, 419);
            this.button_Table_Back.Name = "button_Table_Back";
            this.button_Table_Back.Size = new System.Drawing.Size(560, 30);
            this.button_Table_Back.TabIndex = 24;
            this.button_Table_Back.Text = "BACK";
            this.button_Table_Back.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(326, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Choose table OID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_TableOID
            // 
            this.comboBox_TableOID.FormattingEnabled = true;
            this.comboBox_TableOID.Location = new System.Drawing.Point(325, 89);
            this.comboBox_TableOID.Name = "comboBox_TableOID";
            this.comboBox_TableOID.Size = new System.Drawing.Size(246, 21);
            this.comboBox_TableOID.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(279, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "OR";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.Font = new System.Drawing.Font("PanRoman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label4.Location = new System.Drawing.Point(14, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(557, 31);
            this.label4.TabIndex = 28;
            this.label4.Text = "TABLE VIEWER";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Table_GetTableOID
            // 
            this.button_Table_GetTableOID.Location = new System.Drawing.Point(325, 127);
            this.button_Table_GetTableOID.Name = "button_Table_GetTableOID";
            this.button_Table_GetTableOID.Size = new System.Drawing.Size(246, 31);
            this.button_Table_GetTableOID.TabIndex = 29;
            this.button_Table_GetTableOID.Text = "Get Table by OID";
            this.button_Table_GetTableOID.UseVisualStyleBackColor = true;
            this.button_Table_GetTableOID.Click += new System.EventHandler(this.button_Table_GetTableOID_Click);
            // 
            // TableViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.button_Table_GetTableOID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_TableOID);
            this.Controls.Add(this.button_Table_Back);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_Table_GetTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_TableName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TableViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TableViewerForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_TableName;
        private System.Windows.Forms.Button button_Table_GetTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Table_Back;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_TableOID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Table_GetTableOID;
    }
}