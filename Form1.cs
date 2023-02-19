using System;
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

        string antSerial = null;
        string antGTIN = null;
        string antServerTable = null;
        int countOfSgtinLoad = 1;
        string workorderID = null;
        
        private SqlConnection sqlConnection = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private async Task LoadAntaresAsync() //SELECT
        {
            string expDate, manufacturedData = null;
            SqlDataReader sqlReader = null;
            //SqlCommand getAntaresCommand = new SqlCommand("SELECT [Serial] ,[CryptoKey], [CryptoCode] ,[Ntin],[Expiry] FROM " + antServerTable + " where Serial =" + "'" + antSerial + "'" + "and Ntin = " + "'" + antGTIN + "'", sqlConnection);
            
            SqlCommand getAntaresCommand = new SqlCommand("SELECT  "+ antServerTable + "[Item_All_Crypto].[Serial] ," + antServerTable + "[Item_All_Crypto].[Status], " + antServerTable + "[Item_All_Crypto].[Status], " + antServerTable + "[Item_All_Crypto].[WorkOrderID], " + antServerTable + "[Item_All_Crypto].[CryptoKey], " + antServerTable + "[Item_All_Crypto].[CryptoCode], " + antServerTable + "[WorkOrder].[Expiry], " + antServerTable + "[Item_All_Crypto].[Ntin]," + antServerTable + "[WorkOrder].[Lot]," + antServerTable + "[WorkOrder].[CloseTime] FROM [Item_All_Crypto]  JOIN [WorkOrder]ON [WorkOrder].[Id] = [Item_All_Crypto].[WorkOrderID] Where " + antServerTable + "[Item_All_Crypto].[Serial] = " + "'" + antSerial + "'" + " and " + antServerTable + "[Item_All_Crypto].[Ntin] = " + "'" + antGTIN + "'", sqlConnection);
            



            try
            {
                sqlReader = await getAntaresCommand.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    
                     
                   
                    ListViewItem item = new ListViewItem(new string[]{
                    Convert.ToString(countOfSgtinLoad),
                    Convert.ToString(sqlReader["Ntin"]),
                    Convert.ToString(sqlReader["Serial"]),
                    Convert.ToString(sqlReader["CryptoKey"]),
                    Convert.ToString(sqlReader["CryptoCode"]),
                    Convert.ToString(sqlReader["Expiry"]),
                    Convert.ToString(sqlReader["CloseTime"]),
                    Convert.ToString(sqlReader["Lot"]),
                    Convert.ToString(sqlReader["Status"])
                    

                });
                    countOfSgtinLoad++;

                listView1.Items.Add(item);
                    

                expDate = Convert.ToString(sqlReader["Expiry"]);
                //manufacturedData = Convert.ToString(sqlReader["CloseTime"]);
                   
                if (expDate != "") { expDate = expDate.Substring(6, 2) + "." + expDate.Substring(4, 2) + "." + expDate.Substring(0, 4); }
                ExpiredTextBox.Text = expDate;
                ManufacturingDateBox.Text = Convert.ToString(sqlReader["CloseTime"]);
                //if (manufacturedData != "") { manufacturedData = manufacturedData.Substring(6, 2) + "." + manufacturedData.Substring(4, 2) + "." + manufacturedData.Substring(0, 4); }
                    // textBox1.Text = manufacturedData;
                LotBox.Text = Convert.ToString(sqlReader["Lot"]);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }

        }

        private async Task LoadAntaresAsync1() //SELECT
        {
            string expDate, manufacturedData = null;
            SqlDataReader sqlReader = null;
            //SqlCommand getAntaresCommand = new SqlCommand("SELECT [Serial] ,[CryptoKey], [CryptoCode] ,[Ntin],[Expiry] FROM " + antServerTable + " where Serial =" + "'" + antSerial + "'" + "and Ntin = " + "'" + antGTIN + "'", sqlConnection);

            SqlCommand getAntaresCommand = new SqlCommand("SELECT  " + antServerTable + "[Item_All_Crypto].[Serial] ," + antServerTable + "[Item_All_Crypto].[Status], " + antServerTable + "[Item_All_Crypto].[Status], " + antServerTable + "[Item_All_Crypto].[WorkOrderID], " + antServerTable + "[Item_All_Crypto].[CryptoKey], " + antServerTable + "[Item_All_Crypto].[CryptoCode], " + antServerTable + "[WorkOrder].[Expiry], " + antServerTable + "[Item_All_Crypto].[Ntin]," + antServerTable + "[WorkOrder].[Lot]," + antServerTable + "[WorkOrder].[CloseTime] FROM [Item_All_Crypto]  JOIN [WorkOrder]ON [WorkOrder].[Id] = [Item_All_Crypto].[WorkOrderID] Where " + antServerTable + "[Item_All_Crypto].[WorkOrderID] = '"+ workorderID + "' and " + antServerTable + "[Item_All_Crypto].[Type] = '100' and " + antServerTable + "[Item_All_Crypto].[Status] in( '10','1') ", sqlConnection);




            try
            {
                sqlReader = await getAntaresCommand.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {



                    ListViewItem item = new ListViewItem(new string[]{
                    Convert.ToString(countOfSgtinLoad),
                    Convert.ToString(sqlReader["Ntin"]),
                    Convert.ToString(sqlReader["Serial"]),
                    Convert.ToString(sqlReader["CryptoKey"]),
                    Convert.ToString(sqlReader["CryptoCode"]),
                    Convert.ToString(sqlReader["Expiry"]),
                    Convert.ToString(sqlReader["CloseTime"]),
                    Convert.ToString(sqlReader["Lot"]),
                    Convert.ToString(sqlReader["Status"])


                });
                    countOfSgtinLoad++;

                    listView1.Items.Add(item);


                    expDate = Convert.ToString(sqlReader["Expiry"]);
                    //manufacturedData = Convert.ToString(sqlReader["CloseTime"]);

                    if (expDate != "") { expDate = expDate.Substring(6, 2) + "." + expDate.Substring(4, 2) + "." + expDate.Substring(0, 4); }
                    ExpiredTextBox.Text = expDate;
                    ManufacturingDateBox.Text = Convert.ToString(sqlReader["CloseTime"]);
                    //if (manufacturedData != "") { manufacturedData = manufacturedData.Substring(6, 2) + "." + manufacturedData.Substring(4, 2) + "." + manufacturedData.Substring(0, 4); }
                    // textBox1.Text = manufacturedData;
                    LotBox.Text = Convert.ToString(sqlReader["Lot"]);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
          //  antGTIN = null;
            //antSerial = null;

            antGTIN = GtinBox.Text;
            antSerial = SerialNumberBox.Text;
            bool proverkaSerial = true;


            // antGTIN = "04605310007822";
            //antSerial = "0000000078987";
            foreach (ListViewItem item in listView1.Items)
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
                    sqlConnection = new SqlConnection("Data Source=IRK-SQL-TST;Initial Catalog=AntaresTracking_QA;Persist Security Info=True;User ID=tav;Password=tav");
                    antServerTable = "[AntaresTracking_QA].[dbo].";
                }

                if (ServerComboBox.Text == "Тюмень")
                {
                    SubjectIdBox.Text = "00000000160656";
                    sqlConnection = new SqlConnection("Data Source=TMN-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    antServerTable = "[AntaresTracking_PRD].[dbo].";
                }
                if (ServerComboBox.Text == "Иркутск")
                {
                    SubjectIdBox.Text = "00000000003013";
                    sqlConnection = new SqlConnection("Data Source=IRK-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    antServerTable = "[AntaresTracking_PRD].[dbo].";
                }

                if (ServerComboBox.Text == "Питер")
                {
                    SubjectIdBox.Text = "00000000197244";
                    sqlConnection = new SqlConnection("Data Source=SPB-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    antServerTable = "[AntaresTracking_PRD].[dbo].";
                }

                if (ServerComboBox.Text == "Усурийск")
                {
                    SubjectIdBox.Text = "00000000253549";
                    sqlConnection = new SqlConnection("Data Source=USS-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    antServerTable = "[AntaresTracking_PRD].[dbo].";
                }


                await sqlConnection.OpenAsync();
                await LoadAntaresAsync();
                CountOfSgtinLoadBox.Text = Convert.ToString(countOfSgtinLoad - 1);
            }

            sgtinBox.Text = null;
            SerialNumberBox.Text = null;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("№", 20);
            listView1.Columns.Add("GTIN",120);
            listView1.Columns.Add("Серийный Номер", 120);
            listView1.Columns.Add("Крипто ключ", 100);
            listView1.Columns.Add("Криптокод", 300);
            listView1.Columns.Add("Срок годности", 100);
            listView1.Columns.Add("Дата производства", 100);
            listView1.Columns.Add("Лот", 80);
            listView1.Columns.Add("Статус", 80);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
           
            
            ManufacturingDateBox.Text = null;
            ExpiredTextBox.Text = null;
            LotBox.Text = null;
            listView1.Items.Clear();
            ManualAddButton.Enabled = true;
            LoadFromTxtButton.Enabled = true;
            LoadWODataButton.Enabled = true;
            countOfSgtinLoad = 1;
            CountOfSgtinLoadBox.Text = "0";
            sgtinBox.Text = null;
            GtinBox.Text = null;
            SerialNumberBox.Text = null;
            WorkorderIdTextBox.Text = null;

            antGTIN = null;
            antSerial = null;
            SubjectIdBox.Text = null;
            textBox3.Text = null;


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sdf = new SaveFileDialog() { Filter = "CSV|*.CSV", FileName = LotBox.Text})
            {
                if(sdf.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(new FileStream(sdf.FileName, FileMode.Create), Encoding.UTF8))
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach(ListViewItem item in listView1.Items)
                        {
                            sb.AppendLine("01" + item.SubItems[1].Text + "21" + item.SubItems[2].Text );
                        }
                        await sw.WriteLineAsync(sb.ToString());
                        
                    }
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = null;
            //string aaaa = "046200178611260000000331387";
            listView1.Items.Clear();
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
                    countOfSgtinLoad = 1;

                    while (true)
                    {
                        // Читаем строку из файла во временную переменную.
                        string temp = fs.ReadLine();
                        // Если достигнут конец файла, прерываем считывание.
                        if (temp == null) break;

                        if (temp != "" && temp.Length == 27) 
                        { 
                            // Пишем считанную строку в итоговую переменную.
                            textBox3.Text += temp + "\n";
                      
                            //gtinBox.Text = antGTIN;
                            //serialnumberBox.Text = antSerial;
                            antGTIN = temp.Substring(0, 14);
                            antSerial = temp.Substring(14, 13);

                            if (ServerComboBox.Text == "Тестовый")
                            {
                                SubjectIdBox.Text = "00000000106567";
                                sqlConnection = new SqlConnection("Data Source=IRK-SQL-TST;Initial Catalog=AntaresTracking_QA;Persist Security Info=True;User ID=tav;Password=tav");
                                antServerTable = "[AntaresTracking_QA].[dbo].";
                            }

                            if (ServerComboBox.Text == "Тюмень")
                            {
                                SubjectIdBox.Text = "00000000160656";
                                sqlConnection = new SqlConnection("Data Source=TMN-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                                antServerTable = "[AntaresTracking_PRD].[dbo].";
                            }
                            if (ServerComboBox.Text == "Иркутск")
                            {
                                SubjectIdBox.Text = "00000000003013";
                                sqlConnection = new SqlConnection("Data Source=IRK-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                                antServerTable = "[AntaresTracking_PRD].[dbo].";
                            }

                            if (ServerComboBox.Text == "Питер")
                            {
                                SubjectIdBox.Text = "00000000197244";
                                sqlConnection = new SqlConnection("Data Source=SPB-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                                antServerTable = "[AntaresTracking_PRD].[dbo].";
                            }

                            if (ServerComboBox.Text == "Усурийск")
                            {
                                SubjectIdBox.Text = "00000000253549";
                                sqlConnection = new SqlConnection("Data Source=USS-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                                antServerTable = "[AntaresTracking_PRD].[dbo].";
                            }

                            await sqlConnection.OpenAsync();
                            await LoadAntaresAsync();
                        }
                        //   else { textBox3.Text += temp + "\n"; }

                        //countOfSgtinLoad++;
                        if (temp != "") { countOfSgtinLoadErr++; }
                        
                            
                    }

                    CountOfSgtinLoadBox.Text = Convert.ToString(countOfSgtinLoad -1);
                    if (countOfSgtinLoad - 1 == countOfSgtinLoadErr)
                    {
                        MessageBox.Show("Загружено " + Convert.ToString(countOfSgtinLoad - 1) + " SGTIN из " + Convert.ToString(countOfSgtinLoadErr));
                    }
                    else { MessageBox.Show("Загружено " + Convert.ToString(countOfSgtinLoad - 1) + " SGTIN из " + Convert.ToString(countOfSgtinLoadErr) + "\n Проверьте длину SGTIN"); }

                }

                foreach (ListViewItem item in listView1.Items)
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

        private async void  button4_Click(object sender, EventArgs e)
        {

            ManufacturingDateBox.Text = null;
            ExpiredTextBox.Text = null;
            LotBox.Text = null;
            listView1.Items.Clear();
            ManualAddButton.Enabled = true;
            LoadFromTxtButton.Enabled = true;
            LoadWODataButton.Enabled = true;
            countOfSgtinLoad = 1;
            CountOfSgtinLoadBox.Text = "0";
            sgtinBox.Text = null;
            GtinBox.Text = null;
            SerialNumberBox.Text = null;


            if (ServerComboBox.Text == "Тестовый")
                {
                    SubjectIdBox.Text = "00000000106567";
                    sqlConnection = new SqlConnection("Data Source=IRK-SQL-TST;Initial Catalog=AntaresTracking_QA;Persist Security Info=True;User ID=tav;Password=tav");
                    antServerTable = "[AntaresTracking_QA].[dbo].";
                }

                if (ServerComboBox.Text == "Тюмень")
                {
                    SubjectIdBox.Text = "00000000160656";
                    sqlConnection = new SqlConnection("Data Source=TMN-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    antServerTable = "[AntaresTracking_PRD].[dbo].";
                }
                if (ServerComboBox.Text == "Иркутск")
                {
                    SubjectIdBox.Text = "00000000003013";
                    sqlConnection = new SqlConnection("Data Source=IRK-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    antServerTable = "[AntaresTracking_PRD].[dbo].";
                }

                if (ServerComboBox.Text == "Питер")
                {
                    SubjectIdBox.Text = "00000000197244";
                    sqlConnection = new SqlConnection("Data Source=SPB-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    antServerTable = "[AntaresTracking_PRD].[dbo].";
                }

                if (ServerComboBox.Text == "Усурийск")
                {
                    SubjectIdBox.Text = "00000000253549";
                    sqlConnection = new SqlConnection("Data Source=USS-M1-SQL;Initial Catalog=AntaresTracking_PRD;Persist Security Info=True;User ID=tav;Password=tav");
                    antServerTable = "[AntaresTracking_PRD].[dbo].";
                }

                workorderID = WorkorderIdTextBox.Text;

                await sqlConnection.OpenAsync();
                await LoadAntaresAsync1();
                CountOfSgtinLoadBox.Text = Convert.ToString(countOfSgtinLoad - 1);
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
