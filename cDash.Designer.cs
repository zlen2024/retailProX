namespace projectVp
{
    partial class cDash
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
            textBox1 = new TextBox();
            total = new Label();
            label2 = new Label();
            label3 = new Label();
            payment = new Button();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            name = new Label();
            id = new Label();
            role = new Label();
            contact = new Label();
            dgv = new DataGridView();
            label8 = new Label();
            label1 = new Label();
            store = new Label();
            addtocart = new Button();
            button1 = new Button();
            SCode = new DataGridViewTextBoxColumn();
            PName = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(8, 148);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(140, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // total
            // 
            total.BackColor = SystemColors.ButtonFace;
            total.Font = new Font("Segoe UI", 33F, FontStyle.Bold);
            total.ForeColor = Color.Red;
            total.Location = new Point(559, 21);
            total.Name = "total";
            total.Size = new Size(215, 79);
            total.TabIndex = 1;
            total.Text = "100.00";
            total.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label2.ForeColor = Color.Red;
            label2.ImageAlign = ContentAlignment.TopCenter;
            label2.Location = new Point(431, 48);
            label2.Name = "label2";
            label2.Size = new Size(125, 51);
            label2.TabIndex = 2;
            label2.Text = "RM";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = SystemColors.Highlight;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(421, 11);
            label3.Name = "label3";
            label3.Size = new Size(363, 99);
            label3.TabIndex = 3;
            // 
            // payment
            // 
            payment.BackColor = Color.Lime;
            payment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            payment.Location = new Point(688, 412);
            payment.Name = "payment";
            payment.Size = new Size(94, 29);
            payment.TabIndex = 5;
            payment.Text = "PAY";
            payment.UseVisualStyleBackColor = false;
            payment.Click += payment_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(102, 8);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 6;
            label4.Text = "Name :";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Gemini_Generated_Image_n7yevgn7yevgn7ye;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(84, 98);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(102, 28);
            label5.Name = "label5";
            label5.Size = new Size(31, 20);
            label5.TabIndex = 8;
            label5.Text = "ID :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(102, 48);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 9;
            label6.Text = "Role :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(102, 68);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 10;
            label7.Text = "Contact :";
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(164, 8);
            name.Name = "name";
            name.Size = new Size(50, 20);
            name.TabIndex = 11;
            name.Text = "label8";
            name.Click += label8_Click;
            // 
            // id
            // 
            id.AutoSize = true;
            id.Location = new Point(139, 28);
            id.Name = "id";
            id.Size = new Size(17, 20);
            id.TabIndex = 12;
            id.Text = "2";
            id.Click += label9_Click;
            // 
            // role
            // 
            role.AutoSize = true;
            role.Location = new Point(154, 48);
            role.Name = "role";
            role.Size = new Size(38, 20);
            role.TabIndex = 13;
            role.Text = "Tank";
            // 
            // contact
            // 
            contact.AutoSize = true;
            contact.Location = new Point(175, 68);
            contact.Name = "contact";
            contact.Size = new Size(33, 20);
            contact.TabIndex = 14;
            contact.Text = "999";
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { SCode, PName, price });
            dgv.Location = new Point(232, 116);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 51;
            dgv.Size = new Size(556, 291);
            dgv.TabIndex = 15;
            dgv.CellContentClick += dgv_CellContentClick;
            // 
            // label8
            // 
            label8.BackColor = SystemColors.Highlight;
            label8.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(421, 12);
            label8.Name = "label8";
            label8.Size = new Size(135, 46);
            label8.TabIndex = 16;
            label8.Text = "TOTAL : ";
            label8.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 88);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 17;
            label1.Text = "Store :";
            // 
            // store
            // 
            store.AutoSize = true;
            store.Location = new Point(154, 90);
            store.Name = "store";
            store.Size = new Size(37, 20);
            store.TabIndex = 18;
            store.Text = "NSK";
            // 
            // addtocart
            // 
            addtocart.BackColor = Color.FromArgb(255, 255, 128);
            addtocart.Location = new Point(154, 148);
            addtocart.Name = "addtocart";
            addtocart.Size = new Size(73, 29);
            addtocart.TabIndex = 19;
            addtocart.Text = "Add";
            addtocart.UseVisualStyleBackColor = false;
            addtocart.Click += addtocart_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 128, 128);
            button1.Location = new Point(8, 412);
            button1.Name = "button1";
            button1.Size = new Size(88, 29);
            button1.TabIndex = 20;
            button1.Text = "LOGOUT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // SCode
            // 
            SCode.HeaderText = "SCode";
            SCode.MinimumWidth = 6;
            SCode.Name = "SCode";
            SCode.ReadOnly = true;
            SCode.Width = 125;
            // 
            // PName
            // 
            PName.HeaderText = "Product Name";
            PName.MinimumWidth = 6;
            PName.Name = "PName";
            PName.ReadOnly = true;
            PName.Width = 125;
            // 
            // price
            // 
            price.HeaderText = "Price";
            price.MinimumWidth = 6;
            price.Name = "price";
            price.ReadOnly = true;
            price.Width = 125;
            // 
            // cDash
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(addtocart);
            Controls.Add(store);
            Controls.Add(label1);
            Controls.Add(dgv);
            Controls.Add(contact);
            Controls.Add(role);
            Controls.Add(id);
            Controls.Add(name);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(payment);
            Controls.Add(label2);
            Controls.Add(total);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Name = "cDash";
            Text = "cDash";
            Load += cDash_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label total;
        private Label label2;
        private Label label3;
        private Button payment;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label name;
        private Label id;
        private Label role;
        private Label contact;
        private DataGridView dgv;
        private Label label8;
        private Label label1;
        private Label store;
        private Button addtocart;
        private Button button1;
        private DataGridViewTextBoxColumn SCode;
        private DataGridViewTextBoxColumn PName;
        private DataGridViewTextBoxColumn price;
    }
}