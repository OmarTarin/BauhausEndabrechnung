using Org.BouncyCastle.Asn1.Crmf;
using System.Windows.Forms;

namespace WinFormsApp1
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
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            gridView = new DataGridView();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(29, 47);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(466, 23);
            comboBox1.TabIndex = 0;
            comboBox1.DropDown += comboBox1_DropDown;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(531, 691);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(145, 23);
            textBox1.TabIndex = 3;
            // 
            // gridView
            // 
            gridView.Location = new Point(531, 84);
            gridView.MultiSelect = false;
            gridView.Name = "gridView";
            gridView.ReadOnly = true;
            gridView.Size = new Size(642, 580);
            gridView.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1028, 691);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(145, 23);
            textBox2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.Location = new Point(29, 84);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(466, 580);
            dataGridView1.TabIndex = 5;
            dataGridView1.SelectionChanged += dataGridView1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(29, 683);
            button1.Name = "button1";
            button1.Size = new Size(185, 31);
            button1.TabIndex = 6;
            button1.Text = "Zuordnung Speichern";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1028, 49);
            button2.Name = "button2";
            button2.Size = new Size(145, 23);
            button2.TabIndex = 7;
            button2.Text = "Als PDF Speichern";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(531, 673);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 8;
            label1.Text = "Summe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1028, 673);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 9;
            label2.Text = "10 % von der Summe";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 747);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(gridView);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bauhaus Jahresabrechner";
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private TextBox textBox1;
        private DataGridView gridView;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
    }
}