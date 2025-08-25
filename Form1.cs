using Microsoft.Data.SqlClient;
using System.Configuration;

namespace projectVp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            string cs = ConfigurationManager.ConnectionStrings["dbc"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM [User] WHERE username = @username AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // ✅ check if user exists
                    {
                        int user_id = reader.GetInt32(0); // user_id
                        string role = reader.GetString(3); // role

                        if (role == "manager")
                        {
                            mDash dashboard = new mDash(user_id);
                            
                            dashboard.Show();
                            this.Hide();
                        }
                        else if (role == "cashier")
                        {
                            cDash dashboard = new cDash(user_id);
                            conn.Close();
                            dashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Unknown role: " + role, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close(); // always good to close the reader
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred:\n" + ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    }
}
