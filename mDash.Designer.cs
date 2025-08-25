namespace projectVp
{
    partial class mDash
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
            pictureBox1 = new PictureBox();
            addStore = new Button();
            label1 = new Label();
            label2 = new Label();
            addCashier = new Button();
            addProduct = new Button();
            logout = new Button();
            label3 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label4 = new Label();
            dgv = new DataGridView();
            name = new Label();
            id = new Label();
            role = new Label();
            label5 = new Label();
            contact = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Gemini_Generated_Image_n7yevgn7yevgn7ye;
            pictureBox1.Location = new Point(21, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(109, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // addStore
            // 
            addStore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addStore.BackColor = Color.FromArgb(255, 192, 128);
            addStore.Location = new Point(470, 154);
            addStore.Name = "addStore";
            addStore.Size = new Size(94, 29);
            addStore.TabIndex = 1;
            addStore.Text = "Add Store";
            addStore.UseVisualStyleBackColor = false;
            addStore.Click += addStore_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(136, 28);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 2;
            label1.Text = "Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(136, 48);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 3;
            label2.Text = "ID :";
            label2.Click += label2_Click;
            // 
            // addCashier
            // 
            addCashier.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addCashier.BackColor = Color.FromArgb(255, 255, 128);
            addCashier.Location = new Point(570, 155);
            addCashier.Name = "addCashier";
            addCashier.Size = new Size(104, 29);
            addCashier.TabIndex = 4;
            addCashier.Text = "Add Cashier";
            addCashier.UseVisualStyleBackColor = false;
            addCashier.Click += addCashier_Click;
            // 
            // addProduct
            // 
            addProduct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addProduct.BackColor = Color.FromArgb(255, 255, 128);
            addProduct.Location = new Point(680, 155);
            addProduct.Name = "addProduct";
            addProduct.Size = new Size(108, 29);
            addProduct.TabIndex = 5;
            addProduct.Text = "Add Product";
            addProduct.UseVisualStyleBackColor = false;
            addProduct.Click += addProduct_Click;
            // 
            // logout
            // 
            logout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            logout.BackColor = Color.FromArgb(255, 128, 128);
            logout.Location = new Point(694, 19);
            logout.Name = "logout";
            logout.Size = new Size(94, 29);
            logout.TabIndex = 6;
            logout.Text = "LOGOUT";
            logout.UseVisualStyleBackColor = false;
            logout.Click += logout_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(136, 68);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 10;
            label3.Text = "Role :";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(21, 156);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(171, 28);
            comboBox1.TabIndex = 11;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(198, 156);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(114, 28);
            comboBox2.TabIndex = 12;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 408);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 13;
            label4.Text = "label4";
            label4.Visible = false;
            label4.Click += label4_Click;
            // 
            // dgv
            // 
            dgv.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(20, 190);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 51;
            dgv.Size = new Size(767, 248);
            dgv.TabIndex = 14;
            dgv.CellContentClick += dgv_CellContentClick;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(198, 28);
            name.Name = "name";
            name.Size = new Size(50, 20);
            name.TabIndex = 15;
            name.Text = "label5";
            name.Click += name_Click;
            // 
            // id
            // 
            id.AutoSize = true;
            id.Location = new Point(173, 48);
            id.Name = "id";
            id.Size = new Size(50, 20);
            id.TabIndex = 16;
            id.Text = "label6";
            id.Click += label6_Click;
            // 
            // role
            // 
            role.AutoSize = true;
            role.Location = new Point(188, 68);
            role.Name = "role";
            role.Size = new Size(50, 20);
            role.TabIndex = 17;
            role.Text = "label7";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(136, 88);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 18;
            label5.Text = "Contact :";
            // 
            // contact
            // 
            contact.AutoSize = true;
            contact.Location = new Point(209, 88);
            contact.Name = "contact";
            contact.Size = new Size(46, 20);
            contact.TabIndex = 19;
            contact.Text = "kjdslk";
            // 
            // mDash
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(800, 450);
            Controls.Add(contact);
            Controls.Add(label5);
            Controls.Add(role);
            Controls.Add(id);
            Controls.Add(name);
            Controls.Add(label4);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(logout);
            Controls.Add(addProduct);
            Controls.Add(addCashier);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(addStore);
            Controls.Add(pictureBox1);
            Controls.Add(dgv);
            Name = "mDash";
            Text = "mDash";
            Load += mDash_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button addStore;
        private Label label1;
        private Label label2;
        private Button addCashier;
        private Button addProduct;
        private Button logout;
        private Label label3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label4;
        private DataGridView dgv;
        private Label name;
        private Label id;
        private Label role;
        private Label label5;
        private Label contact;
    }
}