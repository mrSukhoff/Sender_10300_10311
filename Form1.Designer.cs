
namespace Sender_10300_10311
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GtinBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SerialNumberBox = new System.Windows.Forms.TextBox();
            this.ServerComboBox = new System.Windows.Forms.ComboBox();
            this.ManualAddButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SubjectIdBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ManufacturingDateBox = new System.Windows.Forms.TextBox();
            this.ExpiredTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LotBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sgtinBox = new System.Windows.Forms.TextBox();
            this.Save2CsvButton = new System.Windows.Forms.Button();
            this.LoadFromTxtButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CountOfSgtinLoadBox = new System.Windows.Forms.TextBox();
            this.LoadWODataButton = new System.Windows.Forms.Button();
            this.WorkorderIdTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GtinBox
            // 
            this.GtinBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GtinBox.Location = new System.Drawing.Point(16, 249);
            this.GtinBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GtinBox.Name = "GtinBox";
            this.GtinBox.Size = new System.Drawing.Size(304, 29);
            this.GtinBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 225);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "GTIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(17, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Серийный номер";
            // 
            // SerialNumberBox
            // 
            this.SerialNumberBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SerialNumberBox.Location = new System.Drawing.Point(17, 311);
            this.SerialNumberBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SerialNumberBox.Name = "SerialNumberBox";
            this.SerialNumberBox.Size = new System.Drawing.Size(304, 29);
            this.SerialNumberBox.TabIndex = 2;
            // 
            // ServerComboBox
            // 
            this.ServerComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerComboBox.FormattingEnabled = true;
            this.ServerComboBox.Items.AddRange(new object[] {
            "Тестовый",
            "Иркутск",
            "Тюмень",
            "Питер",
            "Усурийск"});
            this.ServerComboBox.Location = new System.Drawing.Point(17, 46);
            this.ServerComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ServerComboBox.Name = "ServerComboBox";
            this.ServerComboBox.Size = new System.Drawing.Size(303, 32);
            this.ServerComboBox.TabIndex = 4;
            this.ServerComboBox.Text = "Выберите сервер";
            this.ServerComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ManualAddButton
            // 
            this.ManualAddButton.Enabled = false;
            this.ManualAddButton.Location = new System.Drawing.Point(13, 92);
            this.ManualAddButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ManualAddButton.Name = "ManualAddButton";
            this.ManualAddButton.Size = new System.Drawing.Size(308, 48);
            this.ManualAddButton.TabIndex = 5;
            this.ManualAddButton.Text = "Добавить в ручную";
            this.ManualAddButton.UseVisualStyleBackColor = true;
            this.ManualAddButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(13, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Сервер";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(13, 367);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1423, 333);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // SubjectIdBox
            // 
            this.SubjectIdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SubjectIdBox.Location = new System.Drawing.Point(499, 46);
            this.SubjectIdBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SubjectIdBox.Name = "SubjectIdBox";
            this.SubjectIdBox.Size = new System.Drawing.Size(255, 29);
            this.SubjectIdBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(495, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(346, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "Идентификатор места деятельности";
            // 
            // ManufacturingDateBox
            // 
            this.ManufacturingDateBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ManufacturingDateBox.Location = new System.Drawing.Point(499, 111);
            this.ManufacturingDateBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ManufacturingDateBox.Name = "ManufacturingDateBox";
            this.ManufacturingDateBox.Size = new System.Drawing.Size(255, 29);
            this.ManufacturingDateBox.TabIndex = 15;
            // 
            // ExpiredTextBox
            // 
            this.ExpiredTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExpiredTextBox.Location = new System.Drawing.Point(500, 178);
            this.ExpiredTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExpiredTextBox.Name = "ExpiredTextBox";
            this.ExpiredTextBox.Size = new System.Drawing.Size(253, 29);
            this.ExpiredTextBox.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(496, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 24);
            this.label7.TabIndex = 17;
            this.label7.Text = "Дата производства";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(496, 153);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 24);
            this.label8.TabIndex = 18;
            this.label8.Text = "Срок годности";
            // 
            // LotBox
            // 
            this.LotBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LotBox.Location = new System.Drawing.Point(499, 249);
            this.LotBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LotBox.Name = "LotBox";
            this.LotBox.Size = new System.Drawing.Size(253, 29);
            this.LotBox.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(496, 223);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 24);
            this.label5.TabIndex = 20;
            this.label5.Text = "Серия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "SGTIN";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // sgtinBox
            // 
            this.sgtinBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sgtinBox.Location = new System.Drawing.Point(16, 178);
            this.sgtinBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sgtinBox.Name = "sgtinBox";
            this.sgtinBox.Size = new System.Drawing.Size(304, 29);
            this.sgtinBox.TabIndex = 21;
            this.sgtinBox.TextChanged += new System.EventHandler(this.sgtinBox_TextChanged);
            // 
            // Save2CsvButton
            // 
            this.Save2CsvButton.Location = new System.Drawing.Point(896, 279);
            this.Save2CsvButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Save2CsvButton.Name = "Save2CsvButton";
            this.Save2CsvButton.Size = new System.Drawing.Size(233, 62);
            this.Save2CsvButton.TabIndex = 23;
            this.Save2CsvButton.Text = "Сохранить в CSV";
            this.Save2CsvButton.UseVisualStyleBackColor = true;
            this.Save2CsvButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoadFromTxtButton
            // 
            this.LoadFromTxtButton.Enabled = false;
            this.LoadFromTxtButton.Location = new System.Drawing.Point(896, 183);
            this.LoadFromTxtButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadFromTxtButton.Name = "LoadFromTxtButton";
            this.LoadFromTxtButton.Size = new System.Drawing.Size(233, 70);
            this.LoadFromTxtButton.TabIndex = 24;
            this.LoadFromTxtButton.Text = "Загрузить из файла TXT";
            this.LoadFromTxtButton.UseVisualStyleBackColor = true;
            this.LoadFromTxtButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1181, 12);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(243, 328);
            this.textBox3.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(496, 286);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 24);
            this.label9.TabIndex = 27;
            this.label9.Text = "Счетчик";
            // 
            // CountOfSgtinLoadBox
            // 
            this.CountOfSgtinLoadBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountOfSgtinLoadBox.Location = new System.Drawing.Point(499, 311);
            this.CountOfSgtinLoadBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CountOfSgtinLoadBox.Name = "CountOfSgtinLoadBox";
            this.CountOfSgtinLoadBox.Size = new System.Drawing.Size(253, 29);
            this.CountOfSgtinLoadBox.TabIndex = 26;
            // 
            // LoadWODataButton
            // 
            this.LoadWODataButton.Enabled = false;
            this.LoadWODataButton.Location = new System.Drawing.Point(896, 95);
            this.LoadWODataButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadWODataButton.Name = "LoadWODataButton";
            this.LoadWODataButton.Size = new System.Drawing.Size(233, 65);
            this.LoadWODataButton.TabIndex = 29;
            this.LoadWODataButton.Text = "Загрузить данные по Workorder";
            this.LoadWODataButton.UseVisualStyleBackColor = true;
            this.LoadWODataButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // WorkorderIdTextBox
            // 
            this.WorkorderIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkorderIdTextBox.Location = new System.Drawing.Point(896, 46);
            this.WorkorderIdTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WorkorderIdTextBox.Name = "WorkorderIdTextBox";
            this.WorkorderIdTextBox.Size = new System.Drawing.Size(232, 29);
            this.WorkorderIdTextBox.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(892, 20);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 24);
            this.label10.TabIndex = 31;
            this.label10.Text = "Workorder";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 715);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.WorkorderIdTextBox);
            this.Controls.Add(this.LoadWODataButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CountOfSgtinLoadBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.LoadFromTxtButton);
            this.Controls.Add(this.Save2CsvButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sgtinBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LotBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ExpiredTextBox);
            this.Controls.Add(this.ManufacturingDateBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SubjectIdBox);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ManualAddButton);
            this.Controls.Add(this.ServerComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SerialNumberBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GtinBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Отправитель 10311";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox GtinBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SerialNumberBox;
        private System.Windows.Forms.ComboBox ServerComboBox;
        private System.Windows.Forms.Button ManualAddButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox SubjectIdBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ManufacturingDateBox;
        private System.Windows.Forms.TextBox ExpiredTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox LotBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sgtinBox;
        private System.Windows.Forms.Button Save2CsvButton;
        private System.Windows.Forms.Button LoadFromTxtButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CountOfSgtinLoadBox;
        private System.Windows.Forms.Button LoadWODataButton;
        private System.Windows.Forms.TextBox WorkorderIdTextBox;
        private System.Windows.Forms.Label label10;
    }
}

