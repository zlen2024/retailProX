using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace projectVp
{
    public partial class cDash : Form
    {
        private string uid;
        private decimal totalAmmount = 0.0m;
        private string s_id = "no store";


        public cDash(int user_id)
        {
            InitializeComponent();
            uid = user_id.ToString();
            loadUserInfo();
            total.Text = totalAmmount.ToString("F2");
        }
        private void loadUserInfo()
        {

            //dgv.Columns.Add("Product ID", "Product ID");
            // dgv.Columns.Add("Name", "Name");
            // dgv.Columns.Add("Price", "Price");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Text = "Delete";
            btn.Name = "btnDelete";
            btn.UseColumnTextForButtonValue = true; // wajib supaya keluar text
            dgv.Columns.Add(btn);

            dgv.CellPainting += dgv_CellPainting;

           

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
                            // label4.Text = "No cashiers found for this store.";
                        } // Assuming fullname is at index 4
                    }
                }
                using (SqlCommand cmd2 = new SqlCommand("Select store_id FROM UserStore WHERE user_id = @uid", con))
                {
                    cmd2.Parameters.AddWithValue("@uid", uid);
                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                    {
                        reader2.Read();
                        s_id = reader2.GetInt32(0).ToString();
                        store.Text = s_id;
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cDash_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void payment_Click(object sender, EventArgs e)
        {
            // 1. Get connection string
            string cs = ConfigurationManager.ConnectionStrings["dbc"].ConnectionString;

            int newCartId = -1; // To store the new cart_id
            string userId = uid; // Replace with actual user ID (maybe from login session)

            // 2. Insert into Cart
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string insertCart = "INSERT INTO Cart (store_id,user_id, created_at, status) OUTPUT INSERTED.cart_id VALUES (@s_id,@uid, GETDATE(), 'paid')";
                using (SqlCommand cmd = new SqlCommand(insertCart, con))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@s_id", s_id);
                    newCartId = (int)cmd.ExecuteScalar(); // Get newly created cart_id
                }

                // 3. Loop through DataGridView rows
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue; // Skip new row

                    string productId = row.Cells[0].Value?.ToString() ?? "";
                    string nameQty = row.Cells[1].Value?.ToString() ?? "";
                    string priceText = row.Cells[2].Value?.ToString() ?? "0";

                    // Parse price
                    decimal price = 0;
                    decimal.TryParse(priceText, out price);

                    // Parse quantity
                    int quantity = 1;
                    if (nameQty.Contains("*"))
                    {
                        string[] parts = nameQty.Split('*');
                        int.TryParse(parts[1], out quantity);
                    }

                    // 4. Insert into CartItem
                    string insertItem = "INSERT INTO CartItem (cart_id, product_id, quantity, price) VALUES (@cid, @pid, @qty, @price)";
                    using (SqlCommand cmd = new SqlCommand(insertItem, con))
                    {
                        cmd.Parameters.AddWithValue("@cid", newCartId);
                        cmd.Parameters.AddWithValue("@pid", productId);
                        cmd.Parameters.AddWithValue("@qty", quantity);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            totalAmmount = 0.00m;
            total.Text = totalAmmount.ToString("F2");
            MessageBox.Show("Payment successful! Cart saved.");
            dgv.Rows.Clear(); // Clear table if needed
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addtocart_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();
            int productId = 0;
            int quantity = 1; // default
            int newpq = 0;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Sila masukkan Product ID", "Amaran", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (input.Contains("*"))
            {
                string[] parts = input.Split('*');
                if (parts.Length == 2)
                {
                    productId = int.Parse(parts[0]);
                    quantity = int.Parse(parts[1]);
                }
            }
            else
            {
                productId = int.Parse(input);
            }

            string pid = productId.ToString();
            string cs = ConfigurationManager.ConnectionStrings["dbc"].ConnectionString;
            string query = "SELECT * FROM Product WHERE product_id = @id AND store_id=@sid";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", pid);
                    cmd.Parameters.AddWithValue("@sid", s_id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();

                            if (reader.GetInt32(5) < quantity)
                            {
                                MessageBox.Show("Stok tidak mencukupi", "Amaran", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            totalAmmount = totalAmmount + (reader.GetDecimal(4) * quantity);
                            total.Text = totalAmmount.ToString("F2");

                            string name = reader.GetString(2) + "*" + quantity.ToString();
                            string price = (reader.GetDecimal(4) * quantity).ToString("F2");
                            newpq = reader.GetInt32(5);
                            dgv.Rows.Add(pid, name, price);
                        }
                        else
                        {
                            totalAmmount += 0;
                            total.Text = totalAmmount.ToString("F2");
                            MessageBox.Show("Item tiada rekod", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    } // ← reader tutup sini
                }

                // Baru boleh update stok
                string query2 = "UPDATE Product SET stock_quantity = @qty WHERE product_id = @id";
                using (SqlCommand cmd2 = new SqlCommand(query2, con))
                {
                    cmd2.Parameters.AddWithValue("@qty", newpq - quantity);
                    cmd2.Parameters.AddWithValue("@id", pid);
                    cmd2.ExecuteNonQuery();
                }

                textBox1.Clear();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();

            // Close current dashboard form
            this.Close();
        }
        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgv.Columns[e.ColumnIndex].Name == "btnDelete" && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                e.PaintContent(e.CellBounds);

                ButtonRenderer.DrawButton(e.Graphics, e.CellBounds,
                    "Delete",
                    this.Font,
                    false,
                    PushButtonState.Default);

                // Fill red background
                using (Brush b = new SolidBrush(Color.Red))
                {
                    e.Graphics.FillRectangle(b, e.CellBounds);
                }

                // Draw text again on top
                TextRenderer.DrawText(e.Graphics, "Delete", e.CellStyle.Font, e.CellBounds, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
            }
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv.Columns["btnDelete"].Index && e.RowIndex >= 0)
            {
                // Don't do anything if this is the new (empty) row
                if (dgv.Rows[e.RowIndex].IsNewRow) return;

                if (dgv.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    // Read values from the current row
                    string pid = dgv.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? "";
                    string nameQty = dgv.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
                    string priceText = dgv.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "0";
                    decimal price = 0;

                    decimal.TryParse(priceText, out price);

                    // Optional: Split name*quantity if needed
                    string name = "";
                    int quantity = 1;
                    if (nameQty.Contains("*"))
                    {
                        string[] parts = nameQty.Split('*');
                        name = parts[0];
                        int.TryParse(parts[1], out quantity); // safe parse
                    }
                    //cari pq
                    int pq = -1;
                    string cs = ConfigurationManager.ConnectionStrings["dbc"].ConnectionString;
                    string query = "SELECT * FROM Product WHERE product_id = @id AND store_id=@sid";
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", pid);
                            cmd.Parameters.AddWithValue("@sid", s_id);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    pq = reader.GetInt32(5); // Ambil stock_quantity
                                }
                            }
                        }
                    }
                    //tambah stock balik
                    totalAmmount = totalAmmount - price;
                    total.Text = totalAmmount.ToString("F2");
                    int y = pq + quantity;
                    //string cs = ConfigurationManager.ConnectionStrings["dbc"].ConnectionString;

                    string query2 = "UPDATE Product SET stock_quantity = @qty WHERE product_id = @id";
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query2, con))
                        {
                            cmd.Parameters.AddWithValue("@id", pid);
                            cmd.Parameters.AddWithValue("@qty", y);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    dgv.Rows.RemoveAt(e.RowIndex);
                }
            }
        }


    }

}

