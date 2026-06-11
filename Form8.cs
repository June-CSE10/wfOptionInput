using Sunny.UI.Win32;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace wfOptionInput
{
    public partial class Form8 : Form
    {
        //Global Variable
        //public static SqlConnection conn = new SqlConnection();


        string MyServer = "JUNE-IT\\sqlexpress";
        string MyDb = "Test Connect";
        string MyUserID = "sa";
        string MyPwd = "1206";

        SqlConnection MyConn = new();       //establis connect
        SqlCommand cmd;                     //establis command (Parameter/ExecuteNonQuery)
        string sql;                         //establis query string
        SqlDataReader Myreader;

        public Form8()
        {
            InitializeComponent();
        }


        private void Form8_Load(object sender, EventArgs e)
        {
            CboProfile.Items.Clear();
            CboProfile.Items.Add("Administrator");
            CboProfile.Items.Add("User");
            CboProfile.Text = CboProfile.Items[0].ToString();

        }

        private void BtnCommit_Click(object sender, EventArgs e) //​កន្លែង BtnComit នេះមិនបាច់សរសេរចូលទេ
        {
            /*
            string str_id = uiTxtSupId.Text;
            string str_name = uiTxtSupName.Text;
            string str_contac = uiTxtSupContac.Text;
            string str_phone = uiTxtSupPhone.Text;
            string str_email = uiTxtSupEmail.Text;
            string str_address = uiTxtSupAddress.Text;
            string str_lst =
                "1. ID:" + str_id.ToString()+ Environment.NewLin +
                "2. Name:" + str_name.ToString() + Environment.NewLin
            */

            uiListBox1.Items.Add("ID: " + uiTxtSupId.Text);
            uiListBox1.Items.Add("Name: " + uiTxtSupName.Text);
            uiListBox1.Items.Add("contac Person: " + uiTxtSupContac.Text);
            uiListBox1.Items.Add("Phone: " + uiTxtSupPhone.Text);
            uiListBox1.Items.Add("Email: " + uiTxtSupEmail.Text);
            uiListBox1.Items.Add("Address: " + uiTxtSupAddress.Text);

            //Break Line
            uiListBox1.Items.Add("...........................");

            //Clear TextBox after Commit
            uiTxtSupId.Clear();
            uiTxtSupName.Clear();
            uiTxtSupContac.Clear();
            uiTxtSupPhone.Clear();
            uiTxtSupEmail.Clear();
            uiTxtSupAddress.Clear();
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            //Input
            string StrMyConn_SqlAuth =
            $"Server={MyServer}; " +
            $"Database={MyDb}; " +
            $"User id={MyUserID}; Password={MyPwd}; " +
            "Encrypt=True; " +
            "TrustServerCertificate=True; ";

            using (MyConn = new SqlConnection(StrMyConn_SqlAuth))
            {
                MyConn.Open();      //Start connect to sqlserver
                try
                {
                    sql =
                        "Insert into [USER_LST] ([USER_ID], [USER_NAME], [USER_PWD], [USER_EMAIL],[USER_PROFILE])" +
                        " Values(@userid,@username,@pwd,@email,@Profile);";
                    cmd = new SqlCommand(sql, MyConn);
                    cmd.Parameters.AddWithValue("@userid", int.Parse(TxtID.Text));
                    cmd.Parameters.AddWithValue("@username", TxtName.Text);
                    cmd.Parameters.AddWithValue("@pwd", TxtPwd.Text);
                    cmd.Parameters.AddWithValue("@email", TxtEmail.Text);
                    cmd.Parameters.AddWithValue("@Profile", CboProfile.Text);
                    //Process                
                    int x = cmd.ExecuteNonQuery();
                    //Output 
                    if (x == 1)
                    {
                        //Data one row is inserted!
                        MessageBox.Show("Confirm message..",
                            "Data is inserted", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    else
                    {
                        //Data is not inserted!
                        MessageBox.Show("Confirm message..",
                            "Data is not inserted", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    MyConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Confirm message..",
                        "Error:" + ex.Message);
                }

                //Clear TextBox after Insert
                TxtID.Clear();
                TxtName.Clear();
                TxtPwd.Clear();
                TxtEmail.Clear();
                CboProfile.Clear();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

            //Input
            string StrMyConn_SqlAuth =
            $"Server={MyServer}; " +
            $"Database={MyDb}; " +
            $"User id={MyUserID}; Password={MyPwd}; " +
            "Encrypt=True; " +
            "TrustServerCertificate=True; ";

            using (MyConn = new SqlConnection(StrMyConn_SqlAuth))
            {
                MyConn.Open();      //Start connect to sqlserver
                                    //Insert data to table database
                try
                {
                    sql =
                        "UPDATE [USER_LST] SET " +
                        "[USER_NAME]=@username, " +
                        "[USER_PWD]=@pwd, " +
                        "[USER_EMAIL]=@email," +
                        "[USER_PROFILE]=@Profile " +
                        " WHERE [USER_ID]=@userid ";
                    cmd = new SqlCommand(sql, MyConn);
                    cmd.Parameters.AddWithValue("@userid", int.Parse(TxtID.Text));
                    cmd.Parameters.AddWithValue("@username", TxtName.Text);
                    cmd.Parameters.AddWithValue("@pwd", TxtPwd.Text);
                    cmd.Parameters.AddWithValue("@email", TxtEmail.Text);
                    cmd.Parameters.AddWithValue("@Profile", CboProfile.Text);
                    //Process                
                    int x = cmd.ExecuteNonQuery();
                    //Output 
                    if (x == 1)
                    {
                        //Data one row is inserted!
                        MessageBox.Show("Confirm message..",
                            "Data is Updated", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    else
                    {
                        //Data is not inserted!
                        MessageBox.Show("Confirm message..",
                            "Data is not Updated", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    // MyConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Confirm message..",
                        "Error:" + ex.Message);
                }
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            //Input
            string StrMyConn_SqlAuth =
            $"Server={MyServer}; " +
            $"Database={MyDb}; " +
            $"User id={MyUserID}; Password={MyPwd}; " +
            "Encrypt=True; " +
            "TrustServerCertificate=True; ";

            using (MyConn = new SqlConnection(StrMyConn_SqlAuth))
            {
                MyConn.Open();      //Start connect to sqlserver
                                    //Insert data to table database
                try
                {
                    sql =
                        "SELECT [USER_ID], [USER_NAME], [USER_PWD], [USER_EMAIL],[USER_PROFILE] " +
                        "FROM [USER_LST] WHERE [USER_ID]=@userid ";
                    cmd = new SqlCommand(sql, MyConn);
                    cmd.Parameters.AddWithValue("@userid", int.Parse(TxtID.Text));
                    //Process                
                    Myreader = cmd.ExecuteReader();

                    //Output 

                    if (Myreader.HasRows)
                    {   //Output
                        while (Myreader.Read())
                        {
                            TxtID.Text = Myreader.GetValue(0).ToString();       //USER_ID
                            TxtName.Text = Myreader.GetValue(1).ToString();     //USER_NAME
                            TxtPwd.Text = Myreader.GetValue(2).ToString();      //USER_PWD
                            TxtEmail.Text = Myreader.GetValue(3).ToString();    //USER_EMAIL
                            CboProfile.Text = Myreader.GetValue(4).ToString();      //USER_PROFIL
                        }
                    }
                    else
                    {
                        //Data is not Found!
                        MessageBox.Show("Confirm message..",
                            "Data is not Found", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }


                    //MyConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Confirm message..",
                        "Error:" + ex.Message);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //Input
            string StrMyConn_SqlAuth =
            $"Server={MyServer}; " +
            $"Database={MyDb}; " +
            $"User id={MyUserID}; Password={MyPwd}; " +
            "Encrypt=True; " +
            "TrustServerCertificate=True; ";

            using (MyConn = new SqlConnection(StrMyConn_SqlAuth))
            {
                MyConn.Open();      //Start connect to sqlserver
                                    //Insert data to table database
                try
                {
                    sql =
                        "DELETE FROM [USER_LST] " +
                        " WHERE [USER_ID]=@userid ";
                    cmd = new SqlCommand(sql, MyConn);
                    cmd.Parameters.AddWithValue("@userid", int.Parse(TxtID.Text));
                    //cmd.Parameters.AddWithValue("@username", TxtUserName.Text);
                    //cmd.Parameters.AddWithValue("@pwd", TxtUserPwd.Text);
                    //cmd.Parameters.AddWithValue("@email", TxtUserEmail.Text);
                    //cmd.Parameters.AddWithValue("@Profile", CboProFile.Text);
                    //Process                
                    int x = cmd.ExecuteNonQuery();
                    //Output 
                    if (x == 1)
                    {
                        //Data one row is inserted!
                        MessageBox.Show("Confirm message..",
                            "Data is Deleted", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    else
                    {
                        //Data is not inserted!
                        MessageBox.Show("Confirm message..",
                            "Data is not Deleted", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    // MyConn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Confirm message..",
                        "Error:" + ex.Message);
                }
            }
        }
    }
}
