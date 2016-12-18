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
            this.button_Get = new System.Windows.Forms.Button();
            this.button_GetNext = new System.Windows.Forms.Button();
            this.button_Watch = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_RemoveAll = new System.Windows.Forms.Button();
            this.button_Search = new System.Windows.Forms.Button();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_SearchType = new System.Windows.Forms.Label();
            this.comboBox_SearchType = new System.Windows.Forms.ComboBox();
            this.label_SearchValue = new System.Windows.Forms.Label();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.button_GetTable = new System.Windows.Forms.Button();
            this.label_IP = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_OID = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView_Database = new System.Windows.Forms.DataGridView();
            this.label_Search_Operator = new System.Windows.Forms.Label();
            this.comboBox_Search_Operator = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Database)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Get
            // 
            this.button_Get.Location = new System.Drawing.Point(236, 23);
            this.button_Get.Name = "button_Get";
            this.button_Get.Size = new System.Drawing.Size(122, 48);
            this.button_Get.TabIndex = 1;
            this.button_Get.Text = "Get";
            this.button_Get.UseVisualStyleBackColor = true;
            this.button_Get.Click += new System.EventHandler(this.button_Get_Click);
            // 
            // button_GetNext
            // 
            this.button_GetNext.Location = new System.Drawing.Point(364, 23);
            this.button_GetNext.Name = "button_GetNext";
            this.button_GetNext.Size = new System.Drawing.Size(117, 48);
            this.button_GetNext.TabIndex = 2;
            this.button_GetNext.Text = "GetNext";
            this.button_GetNext.UseVisualStyleBackColor = true;
            this.button_GetNext.Click += new System.EventHandler(this.button_GetNext_Click);
            // 
            // button_Watch
            // 
            this.button_Watch.Location = new System.Drawing.Point(236, 131);
            this.button_Watch.Name = "button_Watch";
            this.button_Watch.Size = new System.Drawing.Size(245, 48);
            this.button_Watch.TabIndex = 4;
            this.button_Watch.Text = "Watch";
            this.button_Watch.UseVisualStyleBackColor = true;
            this.button_Watch.Click += new System.EventHandler(this.button_Watch_Click);
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(2, 360);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(154, 23);
            this.button_Remove.TabIndex = 5;
            this.button_Remove.Text = "Remove ";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_RemoveAll
            // 
            this.button_RemoveAll.Location = new System.Drawing.Point(162, 360);
            this.button_RemoveAll.Name = "button_RemoveAll";
            this.button_RemoveAll.Size = new System.Drawing.Size(155, 23);
            this.button_RemoveAll.TabIndex = 6;
            this.button_RemoveAll.Text = "Remove All";
            this.button_RemoveAll.UseVisualStyleBackColor = true;
            this.button_RemoveAll.Click += new System.EventHandler(this.button_RemoveAll_Click);
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(391, 400);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(90, 23);
            this.button_Search.TabIndex = 7;
            this.button_Search.Text = "Search";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(323, 360);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(158, 23);
            this.button_Refresh.TabIndex = 8;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(2, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Choose object ID:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_SearchType
            // 
            this.label_SearchType.AutoSize = true;
            this.label_SearchType.Location = new System.Drawing.Point(2, 386);
            this.label_SearchType.Name = "label_SearchType";
            this.label_SearchType.Size = new System.Drawing.Size(104, 13);
            this.label_SearchType.TabIndex = 16;
            this.label_SearchType.Text = "Choose search type:";
            // 
            // comboBox_SearchType
            // 
            this.comboBox_SearchType.FormattingEnabled = true;
            this.comboBox_SearchType.Location = new System.Drawing.Point(2, 402);
            this.comboBox_SearchType.Name = "comboBox_SearchType";
            this.comboBox_SearchType.Size = new System.Drawing.Size(104, 21);
            this.comboBox_SearchType.TabIndex = 15;
            // 
            // label_SearchValue
            // 
            this.label_SearchValue.Location = new System.Drawing.Point(236, 386);
            this.label_SearchValue.Name = "label_SearchValue";
            this.label_SearchValue.Size = new System.Drawing.Size(149, 13);
            this.label_SearchValue.TabIndex = 18;
            this.label_SearchValue.Text = "Value:";
            // 
            // textBox_Search
            // 
            this.textBox_Search.Location = new System.Drawing.Point(236, 402);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(149, 20);
            this.textBox_Search.TabIndex = 17;
            // 
            // button_GetTable
            // 
            this.button_GetTable.Location = new System.Drawing.Point(236, 77);
            this.button_GetTable.Name = "button_GetTable";
            this.button_GetTable.Size = new System.Drawing.Size(245, 48);
            this.button_GetTable.TabIndex = 19;
            this.button_GetTable.Text = "Open Table Viewer";
            this.button_GetTable.UseVisualStyleBackColor = true;
            this.button_GetTable.Click += new System.EventHandler(this.button_GetTable_Click);
            // 
            // label_IP
            // 
            this.label_IP.Location = new System.Drawing.Point(2, 9);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(221, 17);
            this.label_IP.TabIndex = 21;
            this.label_IP.Text = "Agent IP Address:";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(2, 29);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(221, 20);
            this.textBox_IP.TabIndex = 20;
            this.textBox_IP.TextChanged += new System.EventHandler(this.textBox_IP_TextChanged);
            // 
            // textBox_OID
            // 
            this.textBox_OID.Location = new System.Drawing.Point(2, 75);
            this.textBox_OID.Name = "textBox_OID";
            this.textBox_OID.Size = new System.Drawing.Size(221, 20);
            this.textBox_OID.TabIndex = 22;
            this.textBox_OID.TextChanged += new System.EventHandler(this.textBox_OID_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(218, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView_Database
            // 
            this.dataGridView_Database.AllowUserToAddRows = false;
            this.dataGridView_Database.AllowUserToDeleteRows = false;
            this.dataGridView_Database.AllowUserToResizeColumns = false;
            this.dataGridView_Database.AllowUserToResizeRows = false;
            this.dataGridView_Database.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_Database.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Database.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView_Database.CausesValidation = false;
            this.dataGridView_Database.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Database.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_Database.EnableHeadersVisualStyles = false;
            this.dataGridView_Database.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView_Database.Location = new System.Drawing.Point(2, 185);
            this.dataGridView_Database.MultiSelect = false;
            this.dataGridView_Database.Name = "dataGridView_Database";
            this.dataGridView_Database.ReadOnly = true;
            this.dataGridView_Database.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView_Database.Size = new System.Drawing.Size(479, 169);
            this.dataGridView_Database.TabIndex = 14;
            this.dataGridView_Database.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Database_CellContentClick);
            // 
            // label_Search_Operator
            // 
            this.label_Search_Operator.AutoSize = true;
            this.label_Search_Operator.Location = new System.Drawing.Point(112, 386);
            this.label_Search_Operator.Name = "label_Search_Operator";
            this.label_Search_Operator.Size = new System.Drawing.Size(88, 13);
            this.label_Search_Operator.TabIndex = 25;
            this.label_Search_Operator.Text = "Choose operator:";
            // 
            // comboBox_Search_Operator
            // 
            this.comboBox_Search_Operator.FormattingEnabled = true;
            this.comboBox_Search_Operator.Location = new System.Drawing.Point(112, 402);
            this.comboBox_Search_Operator.Name = "comboBox_Search_Operator";
            this.comboBox_Search_Operator.Size = new System.Drawing.Size(104, 21);
            this.comboBox_Search_Operator.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 426);
            this.Controls.Add(this.label_Search_Operator);
            this.Controls.Add(this.comboBox_Search_Operator);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_OID);
            this.Controls.Add(this.label_IP);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.button_GetTable);
            this.Controls.Add(this.label_SearchValue);
            this.Controls.Add(this.textBox_Search);
            this.Controls.Add(this.label_SearchType);
            this.Controls.Add(this.comboBox_SearchType);
            this.Controls.Add(this.dataGridView_Database);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.button_RemoveAll);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_Watch);
            this.Controls.Add(this.button_GetNext);
            this.Controls.Add(this.button_Get);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MIB Browser";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Database)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Get;
        private System.Windows.Forms.Button button_GetNext;
        private System.Windows.Forms.Button button_Watch;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_RemoveAll;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Label label_SearchType;
        private System.Windows.Forms.ComboBox comboBox_SearchType;
        private System.Windows.Forms.Label label_SearchValue;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Button button_GetTable;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_OID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView_Database;
        private System.Windows.Forms.Label label_Search_Operator;
        private System.Windows.Forms.ComboBox comboBox_Search_Operator;
    }
}

