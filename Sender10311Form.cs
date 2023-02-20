﻿using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Sender_10300_10311
{
    public partial class Sender10311Form : Form
    {
        private int _countOfSgtinLoad = 1;
 
        public Sender10311Form()
        {
            InitializeComponent();
            SgtinListView.GridLines = true;
            SgtinListView.FullRowSelect = true;
            SgtinListView.View = View.Details;
            SgtinListView.Columns.Add("№", 20);
            SgtinListView.Columns.Add("GTIN", 120);
            SgtinListView.Columns.Add("Серийный Номер", 120);
            SgtinListView.Columns.Add("Крипто ключ", 100);
            SgtinListView.Columns.Add("Криптокод", 300);
            SgtinListView.Columns.Add("Срок годности", 100);
            SgtinListView.Columns.Add("Дата производства", 100);
            SgtinListView.Columns.Add("Лот", 80);
            SgtinListView.Columns.Add("Статус", 80);
        }

        private void SgtinBox_TextChanged(object sender, EventArgs e)
        {
            if (sgtinBox.Text != null && sgtinBox.Text.Length == 27)
            {
                GtinBox.Text = sgtinBox.Text.Substring(0, 14);
                SerialNumberBox.Text = sgtinBox.Text.Substring(14, 13);
            }
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
            CountOfLoadedSgtinBox.Text = "0";
            sgtinBox.Text = null;
            GtinBox.Text = null;
            SerialNumberBox.Text = null;
            WorkorderIdTextBox.Text = null;

            SubjectIdBox.Text = null;
            SgtinListTextBox.Text = null;
        }

        private async void ManualAddButton_Click(object sender, EventArgs e)
        {
            bool IsSerialUniq = true;

            foreach (ListViewItem item in SgtinListView.Items)
            {
                if (item.SubItems[2].Text == SerialNumberBox.Text)
                {
                   MessageBox.Show("Серийный номер  номер уже присутствует в списке");
                   IsSerialUniq = false;
                }
            }

            if(IsSerialUniq)
            {
                SelectServer(ServerComboBox.Text, out string subjectId, out string connectionString);
                SubjectIdBox.Text = subjectId;

                //"SELECT  " + _antServerTable + "[Item_All_Crypto].[Serial] ," + _antServerTable + "[Item_All_Crypto].[Status], " + _antServerTable + "[Item_All_Crypto].[Status], " + _antServerTable + "[Item_All_Crypto].[WorkOrderID], " + _antServerTable + "[Item_All_Crypto].[CryptoKey], " + _antServerTable + "[Item_All_Crypto].[CryptoCode], " + _antServerTable + "[WorkOrder].[Expiry], " + _antServerTable + "[Item_All_Crypto].[Ntin]," + _antServerTable + "[WorkOrder].[Lot]," + _antServerTable + "[WorkOrder].[CloseTime] FROM [Item_All_Crypto]  JOIN [WorkOrder]ON [WorkOrder].[Id] = [Item_All_Crypto].[WorkOrderID] Where " + _antServerTable + "[Item_All_Crypto].[Serial] = " + "'" + _antSerial + "'" + " and " + _antServerTable + "[Item_All_Crypto].[Ntin] = " + "'" + _antGTIN + "'"
                string query = $"SELECT i.[Serial], i.[Status], i.[WorkOrderID], i.[CryptoKey], i.[CryptoCode], w.[Expiry], [Ntin], w.[Lot], w.[CloseTime]" +
                    $" FROM [Item_All_Crypto] as i" +
                    $" JOIN [WorkOrder] as w ON w.Id = i.WorkOrderID " +
                    $" WHERE Serial = '{SerialNumberBox.Text}' and Ntin = '{GtinBox.Text}'";

                try
                {
                    await LoadFromAntaresDbAndFillFormAsync(connectionString, query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };

                CountOfLoadedSgtinBox.Text = Convert.ToString(_countOfSgtinLoad - 1);
            }

            sgtinBox.Text = null;
            SerialNumberBox.Text = null;
        }

        private async void Save2CsvButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog() { Filter = "CSV|*.CSV", FileName = LotBox.Text };
            if (dialog.ShowDialog() != DialogResult.OK) return;
                
            using (StreamWriter sw = new StreamWriter(new FileStream(dialog.FileName, FileMode.Create), Encoding.UTF8))
            {
                StringBuilder sb = new StringBuilder();
                foreach(ListViewItem item in SgtinListView.Items)
                {
                    sb.AppendLine("01" + item.SubItems[1].Text + "21" + item.SubItems[2].Text + "91" + item.SubItems[3].Text + "92" + item.SubItems[4].Text);
                }
                await sw.WriteLineAsync(sb.ToString());
            }
        }

        private async void LoadFromTxtButton_Click(object sender, EventArgs e)
        {
            SgtinListTextBox.Text = null;
            SgtinListView.Items.Clear();

            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "TXT|*.TXT" };
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) { return; }
                
            int countOfSgtinLoadErr = 0;
            
            using (StreamReader fs = new StreamReader(openFileDialog.FileName))
            {
                int _countOfSgtinLoad = 1;

                while (!fs.EndOfStream)
                {
                    // Читаем строку из файла во временную переменную.
                    string temp = fs.ReadLine();

                    if (temp != "" && temp.Length == 27)
                    {
                        // Пишем считанную строку в итоговую переменную.
                        SgtinListTextBox.Text += temp + '\n';

                        var gtin = temp.Substring(0, 14);
                        var serial = temp.Substring(14, 13);

                        SelectServer(ServerComboBox.Text, out string subjectId, out string connectionString);
                        //SubjectIdBox.Text = subjectId;

                        //"SELECT  " + _antServerTable + "[Item_All_Crypto].[Serial] ," + _antServerTable + "[Item_All_Crypto].[Status], " + _antServerTable + "[Item_All_Crypto].[Status], " + _antServerTable + "[Item_All_Crypto].[WorkOrderID], " + _antServerTable + "[Item_All_Crypto].[CryptoKey], " + _antServerTable + "[Item_All_Crypto].[CryptoCode], " + _antServerTable + "[WorkOrder].[Expiry], " + _antServerTable + "[Item_All_Crypto].[Ntin]," + _antServerTable + "[WorkOrder].[Lot]," + _antServerTable + "[WorkOrder].[CloseTime] FROM [Item_All_Crypto]  JOIN [WorkOrder]ON [WorkOrder].[Id] = [Item_All_Crypto].[WorkOrderID] Where " + _antServerTable + "[Item_All_Crypto].[Serial] = " + "'" + _antSerial + "'" + " and " + _antServerTable + "[Item_All_Crypto].[Ntin] = " + "'" + _antGTIN + "'"
                        string query = $"SELECT i.Serial, i.Status, i.WorkOrderID, i.CryptoKey, i.CryptoCode, w.Expiry, i.Ntin, w.Lot, w.CloseTime" +
                            $" FROM [Item_All_Crypto] as i" +
                            $" JOIN [WorkOrder] as w ON w.Id = i.WorkOrderID " +
                            $" WHERE Serial = '{serial}' and Ntin = '{gtin}'";

                        try
                        {
                            await LoadFromAntaresDbAndFillFormAsync(connectionString, query);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        };
                    };
                    if (temp != "") { countOfSgtinLoadErr++; }
                };

                CountOfLoadedSgtinBox.Text = Convert.ToString(_countOfSgtinLoad - 1);
                if (_countOfSgtinLoad - 1 == countOfSgtinLoadErr)
                {
                    MessageBox.Show("Загружено " + Convert.ToString(_countOfSgtinLoad - 1) + " SGTIN из " + Convert.ToString(countOfSgtinLoadErr));
                }
                else { 
                    MessageBox.Show("Загружено " + Convert.ToString(_countOfSgtinLoad - 1) + " SGTIN из " + Convert.ToString(countOfSgtinLoadErr) + "\n Проверьте длину SGTIN"); 
                }

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

        private async void  LoadWODataButton_Click(object sender, EventArgs e)
        {
            ManufacturingDateBox.Text = null;
            ExpiredTextBox.Text = null;
            LotBox.Text = null;
            SgtinListView.Items.Clear();
            ManualAddButton.Enabled = true;
            LoadFromTxtButton.Enabled = true;
            LoadWODataButton.Enabled = true;
            CountOfLoadedSgtinBox.Text = "0";
            sgtinBox.Text = null;
            GtinBox.Text = null;
            SerialNumberBox.Text = null;

            _countOfSgtinLoad = 1;

            SelectServer(ServerComboBox.Text, out string subjectId, out string connectionString);
            SubjectIdBox.Text = subjectId;

            //"SELECT  " + _antServerTable + "[Item_All_Crypto].[Serial] ," + _antServerTable + "[Item_All_Crypto].[Status], " + _antServerTable + "[Item_All_Crypto].[Status], " + _antServerTable + "[Item_All_Crypto].[WorkOrderID], " + _antServerTable + "[Item_All_Crypto].[CryptoKey], " + _antServerTable + "[Item_All_Crypto].[CryptoCode], " + _antServerTable + "[WorkOrder].[Expiry], " + _antServerTable + "[Item_All_Crypto].[Ntin]," + _antServerTable + "[WorkOrder].[Lot]," + _antServerTable + "[WorkOrder].[CloseTime] FROM [Item_All_Crypto]  JOIN [WorkOrder]ON [WorkOrder].[Id] = [Item_All_Crypto].[WorkOrderID] Where " + _antServerTable + "[Item_All_Crypto].[WorkOrderID] = '"+ _workorderID + "' and " + _antServerTable + "[Item_All_Crypto].[Type] = '100' and " + _antServerTable + "[Item_All_Crypto].[Status] in( '10','1') "
            var query = "SELECT  i.Serial, i.Status, i.WorkOrderID, i.CryptoKey, i.CryptoCode, w.Expiry, i.Ntin, w.Lot, w.CloseTime" +
                " FROM Item_All_Crypto as i  JOIN WorkOrder as w ON w.Id = i.WorkOrderID" +
                $" Where i.WorkOrderID = '{WorkorderIdTextBox.Text}' and i.Type = '100' and i.Status in( '10','1') ";

            try 
            { 
                await LoadFromAntaresDbAndFillFormAsync(connectionString, query);
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

            CountOfLoadedSgtinBox.Text = Convert.ToString(_countOfSgtinLoad - 1);
        }

        /*
         private async Task LoadFromAntaresDbAndFillFormAsync(string connectionString, string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand getAntaresCommand = new SqlCommand(query, connection);
                using (SqlDataReader sqlReader = await getAntaresCommand.ExecuteReaderAsync())
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
            }
        }
         
        */
        private async Task LoadFromAntaresDbAndFillFormAsync(string connectionString, string query)
        {
            List<Sgtin> sgitins = await GetDataFromDb(connectionString, query);
            
            foreach (Sgtin sgtin in sgitins)
            {
                SgtinListView.Items.Add(new ListViewItem(sgtin.ToString()));
            }
            if (sgitins.Count > 0)
            {
                ExpiredTextBox.Text = sgitins[0].Expiry;
                ManufacturingDateBox.Text = sgitins[0].CloseTime;
                LotBox.Text = sgitins[0].Lot;
            }
            CountOfLoadedSgtinBox.Text = sgitins.Count.ToString();
        }

        private async Task<List<Sgtin>> GetDataFromDb(string connectionString, string query)
        {
            List<Sgtin> result = new List<Sgtin>; 
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand getAntaresCommand = new SqlCommand(query, connection);
                using (SqlDataReader sqlReader = await getAntaresCommand.ExecuteReaderAsync())
                {
                    while (await sqlReader.ReadAsync())
                    {
                        Sgtin sgtin = new Sgtin
                        {
                            Ntin = Convert.ToString(sqlReader["Ntin"]),
                            Serial = Convert.ToString(sqlReader["Serial"]),
                            CryptoKey = Convert.ToString(sqlReader["CryptoKey"]),
                            CryptoCode = Convert.ToString(sqlReader["CryptoCode"]),
                            Expiry = Convert.ToString(sqlReader["Expiry"]),
                            CloseTime = Convert.ToString(sqlReader["CloseTime"]),
                            Lot = Convert.ToString(sqlReader["Lot"]),
                            Status = Convert.ToString(sqlReader["Status"])
                        };
                        if (sgtin.Expiry != "")
                        {
                            sgtin.Expiry = sgtin.Expiry.Substring(6, 2) + "." + sgtin.Expiry.Substring(4, 2) + "." + sgtin.Expiry.Substring(0, 4);
                        }
                        result.Add(sgtin);
                    }
                }
            }
            return result;
        }

        private void SelectServer(string ServerName, out string SubjectId, out string ConnectionString) 
        {
            switch (ServerName)
            {
                case "Тестовый":
                    SubjectId = "00000000106567";
                    ConnectionString = "Data Source=IRK-SQL-TST;Initial Catalog=AntaresTracking_QA;Persist Security Info=True;User ID=tav;Password=tav";
                    break;

                case "Тюмень":

                    SubjectId = "00000000160656";
                    ConnectionString = "Data Source=TMN-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav";
                    break;
                case "Иркутск":
                    SubjectId = "00000000003013";
                    ConnectionString = "Data Source=IRK-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav";
                    break;

                case "Питер":
                    SubjectId = "00000000197244";
                    ConnectionString = "Data Source=SPB-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav";
                    break;
                case "Усурийск":
                    SubjectId = "00000000253549";
                    ConnectionString = "Data Source=USS-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav";
                    break;
                default: throw new ArgumentException("Некоректное имя сервера");
            }
        }
    }

    public struct Sgtin
    {
        public string Ntin;
        public string Serial;
        public string CryptoKey;
        public string CryptoCode;
        public string Expiry;
        public string CloseTime;
        public string Lot;
        public string Status;
    }

}
