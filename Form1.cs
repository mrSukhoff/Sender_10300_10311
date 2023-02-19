﻿using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Sender_10300_10311
{
    public partial class Form1 : Form
    {
        private string _antSerial;
        private string _antGTIN;
        private string _antServerTable;
        private int _countOfSgtinLoad = 1;
        private string _workorderID;
        
        private SqlConnection _sqlConnection;

        public Form1()
        {
            InitializeComponent();
        }

        // Удаление соединения при закрытии формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_sqlConnection != null && _sqlConnection.State != ConnectionState.Closed)
                _sqlConnection.Close();
        }
        
        private async Task LoadFromAntaresBySgtinAndFillFormAsync() //SELECT
        {
            //"SELECT  " + _antServerTable + "[Item_All_Crypto].[Serial] ," + _antServerTable + "[Item_All_Crypto].[Status], " + _antServerTable + "[Item_All_Crypto].[Status], " + _antServerTable + "[Item_All_Crypto].[WorkOrderID], " + _antServerTable + "[Item_All_Crypto].[CryptoKey], " + _antServerTable + "[Item_All_Crypto].[CryptoCode], " + _antServerTable + "[WorkOrder].[Expiry], " + _antServerTable + "[Item_All_Crypto].[Ntin]," + _antServerTable + "[WorkOrder].[Lot]," + _antServerTable + "[WorkOrder].[CloseTime] FROM [Item_All_Crypto]  JOIN [WorkOrder]ON [WorkOrder].[Id] = [Item_All_Crypto].[WorkOrderID] Where " + _antServerTable + "[Item_All_Crypto].[Serial] = " + "'" + _antSerial + "'" + " and " + _antServerTable + "[Item_All_Crypto].[Ntin] = " + "'" + _antGTIN + "'"
            string query = $"SELECT i.[Serial], i.[Status], i.[WorkOrderID], i.[CryptoKey], i.[CryptoCode], w.[Expiry], [Ntin], w.[Lot], w.[CloseTime]" +
                $" FROM [Item_All_Crypto] as i" +
                $" JOIN [WorkOrder] as w ON w.Id = i.WorkOrderID " +
                $" WHERE Serial = '{_antSerial}' and Ntin = '{_antGTIN}'";
            SqlCommand getAntaresCommand = new SqlCommand(query, _sqlConnection);
            
            using (SqlDataReader sqlReader = await getAntaresCommand.ExecuteReaderAsync())
            {
                try
                {
                    while (await sqlReader.ReadAsync())
                    {
                        SgtinListView.Items.Add(new ListViewItem(new string[]
                        {
                            Convert.ToString(_countOfSgtinLoad),
                            Convert.ToString(sqlReader["Ntin"]),
                            Convert.ToString(sqlReader["Serial"]),
                            Convert.ToString(sqlReader["CryptoKey"]),
                            Convert.ToString(sqlReader["CryptoCode"]),
                            Convert.ToString(sqlReader["Expiry"]),
                            Convert.ToString(sqlReader["CloseTime"]),
                            Convert.ToString(sqlReader["Lot"]),
                            Convert.ToString(sqlReader["Status"])
                        }));

                        var expDate = Convert.ToString(sqlReader["Expiry"]);
                        if (expDate != "")
                        {
                            expDate = expDate.Substring(6, 2) + "." + expDate.Substring(4, 2) + "." + expDate.Substring(0, 4);
                        }
                        ExpiredTextBox.Text = expDate;

                        ManufacturingDateBox.Text = Convert.ToString(sqlReader["CloseTime"]);

                        LotBox.Text = Convert.ToString(sqlReader["Lot"]);

                        _countOfSgtinLoad++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task LoadFromAntaresByWorkorderAndFillFormAsync() //SELECT
        {
            //"SELECT  " + _antServerTable + "[Item_All_Crypto].[Serial] ," + _antServerTable + "[Item_All_Crypto].[Status], " + _antServerTable + "[Item_All_Crypto].[Status], " + _antServerTable + "[Item_All_Crypto].[WorkOrderID], " + _antServerTable + "[Item_All_Crypto].[CryptoKey], " + _antServerTable + "[Item_All_Crypto].[CryptoCode], " + _antServerTable + "[WorkOrder].[Expiry], " + _antServerTable + "[Item_All_Crypto].[Ntin]," + _antServerTable + "[WorkOrder].[Lot]," + _antServerTable + "[WorkOrder].[CloseTime] FROM [Item_All_Crypto]  JOIN [WorkOrder]ON [WorkOrder].[Id] = [Item_All_Crypto].[WorkOrderID] Where " + _antServerTable + "[Item_All_Crypto].[WorkOrderID] = '"+ _workorderID + "' and " + _antServerTable + "[Item_All_Crypto].[Type] = '100' and " + _antServerTable + "[Item_All_Crypto].[Status] in( '10','1') "
            var query = "SELECT  i.Serial, i.Status, i.WorkOrderID, i.CryptoKey, i.CryptoCode, w.Expiry, i.Ntin, w.Lot, w.CloseTime" +
                " FROM Item_All_Crypto as i  JOIN WorkOrder as ON w.Id = i.WorkOrderID" +
                $" Where i.WorkOrderID = '{_workorderID} and i.Type = '100' and i.Status in( '10','1') ";

            SqlCommand getAntaresCommand = new SqlCommand(query, _sqlConnection);

            using (SqlDataReader sqlReader = await getAntaresCommand.ExecuteReaderAsync())
            {
                try
                {
                    while (await sqlReader.ReadAsync())
                    {
                        ListViewItem item = new ListViewItem(new string[]{
                            Convert.ToString(_countOfSgtinLoad),
                            Convert.ToString(sqlReader["Ntin"]),
                            Convert.ToString(sqlReader["Serial"]),
                            Convert.ToString(sqlReader["CryptoKey"]),
                            Convert.ToString(sqlReader["CryptoCode"]),
                            Convert.ToString(sqlReader["Expiry"]),
                            Convert.ToString(sqlReader["CloseTime"]),
                            Convert.ToString(sqlReader["Lot"]),
                            Convert.ToString(sqlReader["Status"])
                        });
                        SgtinListView.Items.Add(item);

                        string expDate = Convert.ToString(sqlReader["Expiry"]);
                        if (expDate != "") { expDate = expDate.Substring(6, 2) + "." + expDate.Substring(4, 2) + "." + expDate.Substring(0, 4); }
                        ExpiredTextBox.Text = expDate;

                        ManufacturingDateBox.Text = Convert.ToString(sqlReader["CloseTime"]);
                        LotBox.Text = Convert.ToString(sqlReader["Lot"]);
                        _countOfSgtinLoad++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void ManualAddButton_Click(object sender, EventArgs e)
        {
          //  antGTIN = null;
            //antSerial = null;

            _antGTIN = GtinBox.Text;
            _antSerial = SerialNumberBox.Text;
            bool proverkaSerial = true;


            // antGTIN = "04605310007822";
            //antSerial = "0000000078987";
            foreach (ListViewItem item in SgtinListView.Items)
            {

                if (item.SubItems[2].Text == SerialNumberBox.Text)
                {


                   MessageBox.Show("Серийный номер  номер уже присутствует в списке");
                    proverkaSerial = false;
                }
                
            }

            if(proverkaSerial == true)
            {
                if (ServerComboBox.Text == "Тестовый")
                {
                    SubjectIdBox.Text = "00000000106567";
                    _sqlConnection = new SqlConnection("Data Source=IRK-SQL-TST;Initial Catalog=AntaresTracking_QA;Persist Security Info=True;User ID=tav;Password=tav");
                    _antServerTable = "[AntaresTracking_QA].[dbo].";
                }

                if (ServerComboBox.Text == "Тюмень")
                {
                    SubjectIdBox.Text = "00000000160656";
                    _sqlConnection = new SqlConnection("Data Source=TMN-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    _antServerTable = "[AntaresTracking_PRD].[dbo].";
                }
                if (ServerComboBox.Text == "Иркутск")
                {
                    SubjectIdBox.Text = "00000000003013";
                    _sqlConnection = new SqlConnection("Data Source=IRK-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    _antServerTable = "[AntaresTracking_PRD].[dbo].";
                }

                if (ServerComboBox.Text == "Питер")
                {
                    SubjectIdBox.Text = "00000000197244";
                    _sqlConnection = new SqlConnection("Data Source=SPB-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    _antServerTable = "[AntaresTracking_PRD].[dbo].";
                }

                if (ServerComboBox.Text == "Усурийск")
                {
                    SubjectIdBox.Text = "00000000253549";
                    _sqlConnection = new SqlConnection("Data Source=USS-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    _antServerTable = "[AntaresTracking_PRD].[dbo].";
                }


                await _sqlConnection.OpenAsync();
                await LoadFromAntaresBySgtinAndFillFormAsync();
                CountOfSgtinLoadBox.Text = Convert.ToString(_countOfSgtinLoad - 1);
            }

            sgtinBox.Text = null;
            SerialNumberBox.Text = null;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SgtinListView.GridLines = true;
            SgtinListView.FullRowSelect = true;
            SgtinListView.View = View.Details;
            SgtinListView.Columns.Add("№", 20);
            SgtinListView.Columns.Add("GTIN",120);
            SgtinListView.Columns.Add("Серийный Номер", 120);
            SgtinListView.Columns.Add("Крипто ключ", 100);
            SgtinListView.Columns.Add("Криптокод", 300);
            SgtinListView.Columns.Add("Срок годности", 100);
            SgtinListView.Columns.Add("Дата производства", 100);
            SgtinListView.Columns.Add("Лот", 80);
            SgtinListView.Columns.Add("Статус", 80);
        }

        private void ServerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
           
            
            ManufacturingDateBox.Text = null;
            ExpiredTextBox.Text = null;
            LotBox.Text = null;
            SgtinListView.Items.Clear();
            ManualAddButton.Enabled = true;
            LoadFromTxtButton.Enabled = true;
            LoadWODataButton.Enabled = true;
            _countOfSgtinLoad = 1;
            CountOfSgtinLoadBox.Text = "0";
            sgtinBox.Text = null;
            GtinBox.Text = null;
            SerialNumberBox.Text = null;
            WorkorderIdTextBox.Text = null;

            _antGTIN = null;
            _antSerial = null;
            SubjectIdBox.Text = null;
            textBox3.Text = null;


        }

        private async void Save2CsvButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sdf = new SaveFileDialog() { Filter = "CSV|*.CSV", FileName = LotBox.Text})
            {
                if(sdf.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(new FileStream(sdf.FileName, FileMode.Create), Encoding.UTF8))
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach(ListViewItem item in SgtinListView.Items)
                        {
                            sb.AppendLine("01" + item.SubItems[1].Text + "21" + item.SubItems[2].Text );
                        }
                        await sw.WriteLineAsync(sb.ToString());
                        
                    }
                }
            }
        }

        private async void LoadFromTxtButton_Click(object sender, EventArgs e)
        {
            textBox3.Text = null;
            //string aaaa = "046200178611260000000331387";
            SgtinListView.Items.Clear();
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "TXT|*.TXT" })
            { 
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel) { return; }
                
                // получаем выбранный файл
                // string filename = openFileDialog1.FileName;
                // читаем файл в строку
                // string fileText = System.IO.File.ReadAllText(filename);
                //  textBox3.Text = fileText;
                //MessageBox.Show("Файл открыт");

                // antGTIN = gtinBox.Text;
                // antSerial = serialnumberBox.Text;


                //  antGTIN = fileText.Substring(0, 14);
                // antSerial = fileText.Substring(14, 13);

                //  pathBox.Text = fileText;
                int countOfSgtinLoadErr = 0;
                using (StreamReader fs = new StreamReader(openFileDialog1.FileName))
                {
                    _countOfSgtinLoad = 1;

                    while (true)
                    {
                        // Читаем строку из файла во временную переменную.
                        string temp = fs.ReadLine();
                        // Если достигнут конец файла, прерываем считывание.
                        if (temp == null) break;

                        if (temp != "" && temp.Length == 27) { 
                        // Пишем считанную строку в итоговую переменную.
                        textBox3.Text += temp + "\n";
                      
                        //gtinBox.Text = antGTIN;
                        //serialnumberBox.Text = antSerial;
                        _antGTIN = temp.Substring(0, 14);
                        _antSerial = temp.Substring(14, 13);

                        if (ServerComboBox.Text == "Тестовый")
                        {
                            SubjectIdBox.Text = "00000000106567";
                            _sqlConnection = new SqlConnection("Data Source=IRK-SQL-TST;Initial Catalog=AntaresTracking_QA;Persist Security Info=True;User ID=tav;Password=tav");
                            _antServerTable = "[AntaresTracking_QA].[dbo].";
                        }

                        if (ServerComboBox.Text == "Тюмень")
                        {
                            SubjectIdBox.Text = "00000000160656";
                            _sqlConnection = new SqlConnection("Data Source=TMN-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                            _antServerTable = "[AntaresTracking_PRD].[dbo].";
                        }
                        if (ServerComboBox.Text == "Иркутск")
                        {
                            SubjectIdBox.Text = "00000000003013";
                            _sqlConnection = new SqlConnection("Data Source=IRK-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                            _antServerTable = "[AntaresTracking_PRD].[dbo].";
                        }

                        if (ServerComboBox.Text == "Питер")
                        {
                            SubjectIdBox.Text = "00000000197244";
                            _sqlConnection = new SqlConnection("Data Source=SPB-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                            _antServerTable = "[AntaresTracking_PRD].[dbo].";
                        }

                        if (ServerComboBox.Text == "Усурийск")
                        {
                            SubjectIdBox.Text = "00000000253549";
                            _sqlConnection = new SqlConnection("Data Source=USS-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                            _antServerTable = "[AntaresTracking_PRD].[dbo].";
                        }

                        await _sqlConnection.OpenAsync();
                        await LoadFromAntaresBySgtinAndFillFormAsync();
                        }
                        //   else { textBox3.Text += temp + "\n"; }

                        //countOfSgtinLoad++;
                        if (temp != "") { countOfSgtinLoadErr++; }
                        
                            
                    }

                    CountOfSgtinLoadBox.Text = Convert.ToString(_countOfSgtinLoad -1);
                    if (_countOfSgtinLoad - 1 == countOfSgtinLoadErr)
                    {
                        MessageBox.Show("Загружено " + Convert.ToString(_countOfSgtinLoad - 1) + " SGTIN из " + Convert.ToString(countOfSgtinLoadErr));
                    }
                    else { MessageBox.Show("Загружено " + Convert.ToString(_countOfSgtinLoad - 1) + " SGTIN из " + Convert.ToString(countOfSgtinLoadErr) + "\n Проверьте длину SGTIN"); }

                }

                foreach (ListViewItem item in SgtinListView.Items)
                {

                    if (item.SubItems[7].Text != LotBox.Text)
                    {


                        MessageBox.Show("Проверьте файл, Некоторые SGTIN не из серии " + LotBox.Text);
                        break;
                    }
                }


            }
        }

        private void sgtinBox_TextChanged(object sender, EventArgs e)
        {

            if (sgtinBox.Text != null && sgtinBox.Text.Length ==27) 
            { 
            GtinBox.Text = sgtinBox.Text.Substring(0, 14);
            SerialNumberBox.Text = sgtinBox.Text.Substring(14, 13);
            }
        }

        private async void  LoadWODataButton_Click(object sender, EventArgs e)
        {

            ManufacturingDateBox.Text = null;
            ExpiredTextBox.Text = null;
            LotBox.Text = null;
            SgtinListView.Items.Clear();
            ManualAddButton.Enabled = true;
            LoadFromTxtButton.Enabled = true;
            LoadWODataButton.Enabled = true;
            _countOfSgtinLoad = 1;
            CountOfSgtinLoadBox.Text = "0";
            sgtinBox.Text = null;
            GtinBox.Text = null;
            SerialNumberBox.Text = null;


            if (ServerComboBox.Text == "Тестовый")
                {
                    SubjectIdBox.Text = "00000000106567";
                    _sqlConnection = new SqlConnection("Data Source=IRK-SQL-TST;Initial Catalog=AntaresTracking_QA;Persist Security Info=True;User ID=tav;Password=tav");
                    _antServerTable = "[AntaresTracking_QA].[dbo].";
                }

                if (ServerComboBox.Text == "Тюмень")
                {
                    SubjectIdBox.Text = "00000000160656";
                    _sqlConnection = new SqlConnection("Data Source=TMN-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    _antServerTable = "[AntaresTracking_PRD].[dbo].";
                }
                if (ServerComboBox.Text == "Иркутск")
                {
                    SubjectIdBox.Text = "00000000003013";
                    _sqlConnection = new SqlConnection("Data Source=IRK-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    _antServerTable = "[AntaresTracking_PRD].[dbo].";
                }

                if (ServerComboBox.Text == "Питер")
                {
                    SubjectIdBox.Text = "00000000197244";
                    _sqlConnection = new SqlConnection("Data Source=SPB-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    _antServerTable = "[AntaresTracking_PRD].[dbo].";
                }

                if (ServerComboBox.Text == "Усурийск")
                {
                    SubjectIdBox.Text = "00000000253549";
                    _sqlConnection = new SqlConnection("Data Source=USS-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    _antServerTable = "[AntaresTracking_PRD].[dbo].";
                }

                _workorderID = WorkorderIdTextBox.Text;

                await _sqlConnection.OpenAsync();
                await LoadFromAntaresByWorkorderAndFillFormAsync();
                CountOfSgtinLoadBox.Text = Convert.ToString(_countOfSgtinLoad - 1);
            
        }
    }
}
