using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; // Ensure you have this using directive for ConfigurationManager
using Microsoft.Data.SqlClient; // Ensure you have this using directive for SqlConnection   

namespace projectVp
{
    public partial class mDash : Form
    {
        private string uid;
        public mDash(int user_id)
        {
            InitializeComponent();
            uid = user_id.ToString(); // Store the user_id for later use
            RefreshDatabase();
            loadUserInfo(); // Load user info when the form is initialized
        }
        private void loadUserInfo()
        {
            //C:\Users\LENOVO T470s\Desktop\vp-work\projectVp\img\pfp.png
            string cs = ConfigurationManager.ConnectionStrings["dbc"].ConnectionString;
            string query = "SELECT * FROM [User] WHERE user_id = @uid";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            id.Text = reader.GetInt32(0).ToString();
                            //name.Text = reader.GetString(1);
                            role.Text = reader.GetString(3);
                            name.Text = reader.GetString(4);
                            contact.Text = reader.GetString(5);



                        }
                        else
                        {
                            label4.Text = "No cashiers found for this store.";
                        } // Assuming fullname is at index 4
                    }
                }
            }
        }
        public void RefreshDatabase()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbc"].ConnectionString;
            string query = "SELECT s.store_name FROM UserStore us JOIN Store s ON us.store_id = s.store_id WHERE us.user_id = @uid";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBox1.Items.Clear(); // Prevent duplicate when triggered multiple times

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader.GetString(0)); // store_name
                            }
                            if (comboBox1.Items.Count > 0)
                            {
                                comboBox1.SelectedIndex = 0;
                            }

                        }
                        else
                        {
                            label4.Text = "Store not found.";
                        }
                    }
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Cashier");
            comboBox2.Items.Add("Product");
            comboBox2.Items.Add("Sale Record");


        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if comboBox1 and comboBox2 have valid selected items

            string cs = ConfigurationManager.ConnectionStrings["dbc"].ConnectionString;
            string store = comboBox1.SelectedItem.ToString();
            string selection = comboBox2.SelectedItem.ToString();

            string query = "SELECT u.* FROM Store s JOIN UserStore us ON s.store_id = us.store_id JOIN [User] u ON us.user_id = u.user_id WHERE s.store_name = @store AND u.role = 'cashier';";
            string query2 = "SELECT * FROM Product p JOIN Store s ON p.store_id = s.store_id WHERE s.store_name = @store";
            string query3 = @"
            SELECT 
                c.cart_id,
                c.user_id,
                u.fullname AS cashier_name,
                ISNULL(SUM(ci.price), 0) AS total_sale
            FROM 
                Cart c
            JOIN 
                [User] u ON c.user_id = u.user_id
            JOIN 
                Store s ON c.store_id = s.store_id
            LEFT JOIN 
                CartItem ci ON c.cart_id = ci.cart_id
            WHERE  
                s.store_name = @pname
            GROUP BY 
                c.cart_id, c.user_id, u.fullname
            ORDER BY 
                c.cart_id DESC;
        ";
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                if (store == null)
                {
                    MessageBox.Show("choose store again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (selection == "Cashier")
                {
                    dgv.Columns.Clear();
                    dgv.Rows.Clear();

                    dgv.Columns.Add("UserID", "User ID");
                    dgv.Columns.Add("Username", "Username");
                    dgv.Columns.Add("Role", "Role");
                    dgv.Columns.Add("Full Name", "Full Name");
                    dgv.Columns.Add("Contact", "Contact");

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@store", store);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string username = reader.GetString(1);
                                    string role = reader.GetString(3);
                                    string fullName = reader.GetString(4);
                                    string contact = reader.GetString(5);

                                    dgv.Rows.Add(id, username, role, fullName, contact);
                                }
                            }
                            else
                            {
                                label4.Text = "No cashiers found for this store.";
                            }
                        }
                    }
                }
                else if (selection == "Product")
                {
                    dgv.Columns.Clear();
                    dgv.Rows.Clear();

                    dgv.Columns.Add("Product ID", "Product ID");
                    dgv.Columns.Add("Name", "Name");
                    dgv.Columns.Add("Catogory", "Catogory");
                    dgv.Columns.Add("Price", "Price");
                    dgv.Columns.Add("Quantity", "Quantity");

                    using (SqlCommand cmd = new SqlCommand(query2, con))
                    {
                        cmd.Parameters.AddWithValue("@store", store);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string name = reader.GetString(2);
                                    string category = reader.GetString(3);
                                    string price = reader.GetDecimal(4).ToString("F2");
                                    int quantity = reader.GetInt32(5);

                                    dgv.Rows.Add(id, name, category, price, quantity);
                                }
                            }
                            else
                            {
                                label4.Text = "No cashiers found for this store.";
                            }
                        }
                    }
                }
                else if (selection == "Sale Record")
                {
                    dgv.Columns.Clear();
                    dgv.Rows.Clear();

                    // Add columns
                    dgv.Columns.Add("Cart ID", "Cart ID");
                    dgv.Columns.Add("Cashier ID", "Casier ID");
                    dgv.Columns.Add("Cashier Name", "Cashier Name");
                    dgv.Columns.Add("Total Sale", "Total Sale");

                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    btn.HeaderText = "Action";
                    btn.Text = "Detail";
                    btn.Name = "btnDetail";
                    btn.UseColumnTextForButtonValue = true; // wajib supaya keluar text
                    dgv.Columns.Add(btn);

                    using (SqlCommand cmd = new SqlCommand(query3, con))
                    {
                        cmd.Parameters.AddWithValue("@pname", store); // Make sure s_id is declared and holds current store ID


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string cartId = reader["cart_id"].ToString();
                                string cashierId = reader["user_id"].ToString();
                                string cashierName = reader["cashier_name"].ToString();
                                decimal totalSale = reader.GetDecimal(reader.GetOrdinal("total_sale"));

                                dgv.Rows.Add(cartId, cashierId, cashierName, totalSale.ToString("F2"));
                            }
                        }
                    }
                }

            }
        }


        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addStore_Click(object sender, EventArgs e)
        {
            Form addStoreForm = new Form();
            addStoreForm.Text = "Add New Store";
            addStoreForm.Size = new Size(300, 250);

            Label lblCode = new Label() { Text = "Store Code:", Location = new Point(10, 20), AutoSize = true };
            TextBox txtCode = new TextBox() { Location = new Point(100, 20), Width = 150 };

            Label lblName = new Label() { Text = "Store Name:", Location = new Point(10, 60), AutoSize = true };
            TextBox txtName = new TextBox() { Location = new Point(100, 60), Width = 150 };

            Button btnAdd = new Button() { Text = "Add", Location = new Point(50, 120) };
            Button btnCancel = new Button() { Text = "Cancel", Location = new Point(150, 120) };

            btnAdd.Click += (s, ev) =>
            {
                string code = txtCode.Text;
                string name = txtName.Text;

                if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Please fill all fields.");
                    return;
                }

                string connectionString = ConfigurationManager.ConnectionStrings["dbc"].ConnectionString;
                int storeId = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();

                    try
                    {
                        // Insert ke table Store
                        string insertStore = "INSERT INTO Store (store_code, store_name) OUTPUT INSERTED.store_id VALUES (@code, @name)";
                        SqlCommand cmd = new SqlCommand(insertStore, conn, trans);
                        cmd.Parameters.AddWithValue("@code", code);
                        cmd.Parameters.AddWithValue("@name", name);

                        storeId = (int)cmd.ExecuteScalar(); // dapat ID auto increment

                        // Insert ke table UserStore
                        string insertUserStore = "INSERT INTO UserStore (user_id, store_id, assigned_date) VALUES (@userId, @storeId, @date)";
                        SqlCommand cmd2 = new SqlCommand(insertUserStore, conn, trans);
                        cmd2.Parameters.AddWithValue("@userId", uid); // make sure uid is defined globally
                        cmd2.Parameters.AddWithValue("@storeId", storeId);
                        cmd2.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

                        cmd2.ExecuteNonQuery();

                        trans.Commit();

                        RefreshDatabase(); // refresh comboBox1
                        MessageBox.Show("Store successfully added!");
                        addStoreForm.Close();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            };

            btnCancel.Click += (s, e2) => addStoreForm.Close();

            addStoreForm.Controls.Add(lblCode);
            addStoreForm.Controls.Add(txtCode);
            addStoreForm.Controls.Add(lblName);
            addStoreForm.Controls.Add(txtName);
            addStoreForm.Controls.Add(btnAdd);
            addStoreForm.Controls.Add(btnCancel);

            addStoreForm.ShowDialog();
        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            Form productForm = new Form();
            productForm.Text = "Add Product";
            productForm.Size = new Size(300, 400);

            Label lblN = new Label() { Text = "Product Name:", Top = 20, Left = 20 };
            TextBox txtN = new TextBox() { Top = 45, Left = 20, Width = 240 };

            Label lblC = new Label() { Text = "Category:", Top = 80, Left = 20 };
            TextBox txtC = new TextBox() { Top = 105, Left = 20, Width = 240 };

            Label lblP = new Label() { Text = "Price:", Top = 140, Left = 20 };
            TextBox txtP = new TextBox() { Top = 165, Left = 20, Width = 240 };

            Label lblQ = new Label() { Text = "Quantity:", Top = 200, Left = 20 };
            TextBox txtQ = new TextBox() { Top = 225, Left = 20, Width = 240 };

            Label lblS = new Label() { Text = "Select Store:", Top = 260, Left = 20 };
            ComboBox cmb = new ComboBox() { Top = 285, Left = 20, Width = 240 };

            Button btnAdd = new Button() { Text = "Add", Top = 330, Left = 20 };
            Button btnCancel = new Button() { Text = "Cancel", Top = 330, Left = 120 };

            string cs = ConfigurationManager.ConnectionStrings["dbc"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT s.store_name FROM UserStore us JOIN Store s ON us.store_id = s.store_id WHERE us.user_id = @uid", conn);
                cmd.Parameters.AddWithValue("@uid", uid);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmb.Items.Add(reader.GetString(0));
                }
            }

            btnAdd.Click += (s, ev) =>
            {
                string name = txtN.Text.Trim();
                string category = txtC.Text.Trim();
                string priceText = txtP.Text.Trim();
                string qtyText = txtQ.Text.Trim();
                string store = cmb.SelectedItem?.ToString();

                if (name != "" && category != "" && decimal.TryParse(priceText, out decimal price) && int.TryParse(qtyText, out int qty) && store != null)
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {
                        conn.Open();

                        var cmdGet = new SqlCommand("SELECT store_id FROM Store WHERE store_name = @n", conn);
                        cmdGet.Parameters.AddWithValue("@n", store);
                        int storeId = (int)cmdGet.ExecuteScalar();

                        var cmd = new SqlCommand("INSERT INTO Product (store_id, name, category, price, stock_quantity) VALUES (@sid, @n, @c, @p, @q)", conn);
                        cmd.Parameters.AddWithValue("@sid", storeId);
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@c", category);
                        cmd.Parameters.AddWithValue("@p", price);
                        cmd.Parameters.AddWithValue("@q", qty);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Product added!");
                    productForm.Close();
                }
            };

            btnCancel.Click += (s, ev) => productForm.Close();

            productForm.Controls.Add(lblN);
            productForm.Controls.Add(txtN);
            productForm.Controls.Add(lblC);
            productForm.Controls.Add(txtC);
            productForm.Controls.Add(lblP);
            productForm.Controls.Add(txtP);
            productForm.Controls.Add(lblQ);
            productForm.Controls.Add(txtQ);
            productForm.Controls.Add(lblS);
            productForm.Controls.Add(cmb);
            productForm.Controls.Add(btnAdd);
            productForm.Controls.Add(btnCancel);

            productForm.ShowDialog();
        }




        private void addCashier_Click(object sender, EventArgs e)
        {
            Form cashierForm = new Form();
            cashierForm.Text = "Add Cashier";
            cashierForm.Size = new Size(320, 400);

            Label lblFullName = new Label() { Text = "Full Name:", Top = 20, Left = 20 };
            TextBox txtFullName = new TextBox() { Top = 45, Left = 20, Width = 260 };

            Label lblUsername = new Label() { Text = "Username:", Top = 80, Left = 20 };
            TextBox txtUsername = new TextBox() { Top = 105, Left = 20, Width = 260 };

            Label lblPassword = new Label() { Text = "Password:", Top = 140, Left = 20 };
            TextBox txtPassword = new TextBox() { Top = 165, Left = 20, Width = 260 };

            Label lblContact = new Label() { Text = "Contact:", Top = 200, Left = 20 };
            TextBox txtContact = new TextBox() { Top = 225, Left = 20, Width = 260 };

            Label lblStore = new Label() { Text = "Select Store:", Top = 260, Left = 20 };
            ComboBox cmbStore = new ComboBox() { Top = 285, Left = 20, Width = 260 };

            Button btnAdd = new Button() { Text = "Add", Top = 330, Left = 20 };
            Button btnCancel = new Button() { Text = "Cancel", Top = 330, Left = 120 };

            // Load store list
            string cs = ConfigurationManager.ConnectionStrings["dbc"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT s.store_name FROM UserStore us JOIN Store s ON us.store_id = s.store_id WHERE us.user_id = @uid", conn);
                cmd.Parameters.AddWithValue("@uid", uid);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbStore.Items.Add(reader.GetString(0));
                }
            }

            btnAdd.Click += (s, ev) =>
            {
                string fullName = txtFullName.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string contact = txtContact.Text.Trim();
                string selectedStore = cmbStore.SelectedItem?.ToString();

                if (fullName != "" && username != "" && password != "" && contact != "" && selectedStore != null)
                {
                    string cs = ConfigurationManager.ConnectionStrings["dbc"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(cs))
                    {
                        conn.Open();

                        // 1. Get store_id from selected store name
                        SqlCommand getStoreIdCmd = new SqlCommand("SELECT store_id FROM Store WHERE store_name = @n", conn);
                        getStoreIdCmd.Parameters.AddWithValue("@n", selectedStore);
                        int storeId = (int)getStoreIdCmd.ExecuteScalar();

                        // 2. Insert new user with role 'cashier'
                        SqlCommand insertUserCmd = new SqlCommand(
                            "INSERT INTO [User] (username, password, role, fullname, contact) VALUES (@u, @p, 'cashier', @f, @c); SELECT SCOPE_IDENTITY();",
                            conn);
                        insertUserCmd.Parameters.AddWithValue("@u", username);
                        insertUserCmd.Parameters.AddWithValue("@p", password);
                        insertUserCmd.Parameters.AddWithValue("@f", fullName);
                        insertUserCmd.Parameters.AddWithValue("@c", contact);

                        int newUserId = Convert.ToInt32(insertUserCmd.ExecuteScalar());

                        // 3. Insert into UserStore
                        SqlCommand insertUserStoreCmd = new SqlCommand(
                            "INSERT INTO UserStore (user_id, store_id) VALUES (@uid, @sid)", conn);
                        insertUserStoreCmd.Parameters.AddWithValue("@uid", newUserId);
                        insertUserStoreCmd.Parameters.AddWithValue("@sid", storeId);
                        insertUserStoreCmd.ExecuteNonQuery();
                        RefreshDatabase(); // Refresh comboBox1 after adding new cashier
                    }

                    MessageBox.Show("Cashier added successfully.");
                    cashierForm.Close();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields.");
                }
            };

            btnCancel.Click += (s, ev) => cashierForm.Close();

            cashierForm.Controls.Add(lblFullName);
            cashierForm.Controls.Add(txtFullName);
            cashierForm.Controls.Add(lblUsername);
            cashierForm.Controls.Add(txtUsername);
            cashierForm.Controls.Add(lblPassword);
            cashierForm.Controls.Add(txtPassword);
            cashierForm.Controls.Add(lblContact);
            cashierForm.Controls.Add(txtContact);
            cashierForm.Controls.Add(lblStore);
            cashierForm.Controls.Add(cmbStore);
            cashierForm.Controls.Add(btnAdd);
            cashierForm.Controls.Add(btnCancel);

            cashierForm.ShowDialog();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();

            // Close current dashboard form
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void mDash_Load(object sender, EventArgs e)
        {

        }
    }
}

