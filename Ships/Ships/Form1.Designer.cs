namespace Ships
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
            this.dataGridViewVoyage = new System.Windows.Forms.DataGridView();
            this.textBoxShipId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAvgDays = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoyage)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewVoyage
            // 
            this.dataGridViewVoyage.AllowUserToAddRows = false;
            this.dataGridViewVoyage.AllowUserToDeleteRows = false;
            this.dataGridViewVoyage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVoyage.Location = new System.Drawing.Point(12, 54);
            this.dataGridViewVoyage.Name = "dataGridViewVoyage";
            this.dataGridViewVoyage.RowHeadersWidth = 62;
            this.dataGridViewVoyage.RowTemplate.Height = 28;
            this.dataGridViewVoyage.Size = new System.Drawing.Size(1323, 271);
            this.dataGridViewVoyage.TabIndex = 0;
            this.dataGridViewVoyage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBoxShipId
            // 
            this.textBoxShipId.Location = new System.Drawing.Point(600, 389);
            this.textBoxShipId.Name = "textBoxShipId";
            this.textBoxShipId.Size = new System.Drawing.Size(113, 26);
            this.textBoxShipId.TabIndex = 1;
            this.textBoxShipId.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(596, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Insert a ship ID";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // buttonAvgDays
            // 
            this.buttonAvgDays.Location = new System.Drawing.Point(580, 421);
            this.buttonAvgDays.Name = "buttonAvgDays";
            this.buttonAvgDays.Size = new System.Drawing.Size(151, 58);
            this.buttonAvgDays.TabIndex = 4;
            this.buttonAvgDays.Text = "Get the average number of days";
            this.buttonAvgDays.UseVisualStyleBackColor = true;
            this.buttonAvgDays.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1347, 581);
            this.Controls.Add(this.buttonAvgDays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxShipId);
            this.Controls.Add(this.dataGridViewVoyage);
            this.Name = "Form1";
            this.Text = "Ship Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVoyage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewVoyage;
        private System.Windows.Forms.TextBox textBoxShipId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAvgDays;
    }
}

