namespace Shadowsocks.View
{
    partial class SubscriptionManagementForm
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
            this.ListBox_subscription = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_url = new System.Windows.Forms.Label();
            this.TextBox_url = new System.Windows.Forms.TextBox();
            this.Label_expiry = new System.Windows.Forms.Label();
            this.Label_traffic = new System.Windows.Forms.Label();
            this.Label_traffic_used = new System.Windows.Forms.Label();
            this.Label_expiry_date = new System.Windows.Forms.Label();
            this.TextBox_name = new System.Windows.Forms.TextBox();
            this.Label_name = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_delete = new System.Windows.Forms.Button();
            this.Button_save = new System.Windows.Forms.Button();
            this.Button_add = new System.Windows.Forms.Button();
            this.CheckBox_use_proxy = new System.Windows.Forms.CheckBox();
            this.Label_proxy_tips = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox_subscription
            // 
            this.ListBox_subscription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_subscription.FormattingEnabled = true;
            this.ListBox_subscription.ItemHeight = 25;
            this.ListBox_subscription.Location = new System.Drawing.Point(3, 3);
            this.ListBox_subscription.Name = "ListBox_subscription";
            this.ListBox_subscription.Size = new System.Drawing.Size(386, 354);
            this.ListBox_subscription.TabIndex = 0;
            this.ListBox_subscription.SelectedIndexChanged += new System.EventHandler(this.SubscriptionSelected);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.ListBox_subscription, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(980, 360);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_proxy_tips, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(395, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(582, 354);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.Controls.Add(this.Label_url, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.TextBox_url, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Label_expiry, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.Label_traffic, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.Label_traffic_used, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.Label_expiry_date, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.TextBox_name, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.Label_name, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.CheckBox_use_proxy, 0, 4);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(576, 294);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // Label_url
            // 
            this.Label_url.AutoSize = true;
            this.Label_url.Location = new System.Drawing.Point(3, 0);
            this.Label_url.Name = "Label_url";
            this.Label_url.Size = new System.Drawing.Size(179, 25);
            this.Label_url.TabIndex = 3;
            this.Label_url.Text = "Subscription URL";
            // 
            // TextBox_url
            // 
            this.TextBox_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_url.Location = new System.Drawing.Point(233, 3);
            this.TextBox_url.Name = "TextBox_url";
            this.TextBox_url.Size = new System.Drawing.Size(340, 31);
            this.TextBox_url.TabIndex = 1;
            // 
            // Label_expiry
            // 
            this.Label_expiry.AutoSize = true;
            this.Label_expiry.Location = new System.Drawing.Point(233, 169);
            this.Label_expiry.Name = "Label_expiry";
            this.Label_expiry.Size = new System.Drawing.Size(200, 25);
            this.Label_expiry.TabIndex = 15;
            this.Label_expiry.Text = "????-??-?? ?day(s)";
            // 
            // Label_traffic
            // 
            this.Label_traffic.AutoSize = true;
            this.Label_traffic.Location = new System.Drawing.Point(3, 169);
            this.Label_traffic.Name = "Label_traffic";
            this.Label_traffic.Size = new System.Drawing.Size(64, 25);
            this.Label_traffic.TabIndex = 13;
            this.Label_traffic.Text = "?/? G";
            // 
            // Label_traffic_used
            // 
            this.Label_traffic_used.AutoSize = true;
            this.Label_traffic_used.Location = new System.Drawing.Point(3, 122);
            this.Label_traffic_used.Name = "Label_traffic_used";
            this.Label_traffic_used.Size = new System.Drawing.Size(134, 25);
            this.Label_traffic_used.TabIndex = 12;
            this.Label_traffic_used.Text = "Traffic Used:";
            // 
            // Label_expiry_date
            // 
            this.Label_expiry_date.AutoSize = true;
            this.Label_expiry_date.Location = new System.Drawing.Point(233, 122);
            this.Label_expiry_date.Name = "Label_expiry_date";
            this.Label_expiry_date.Size = new System.Drawing.Size(129, 25);
            this.Label_expiry_date.TabIndex = 14;
            this.Label_expiry_date.Text = "Expiry Date:";
            // 
            // TextBox_name
            // 
            this.TextBox_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_name.Enabled = false;
            this.TextBox_name.ForeColor = System.Drawing.Color.Gray;
            this.TextBox_name.Location = new System.Drawing.Point(233, 64);
            this.TextBox_name.Name = "TextBox_name";
            this.TextBox_name.Size = new System.Drawing.Size(340, 31);
            this.TextBox_name.TabIndex = 6;
            this.TextBox_name.Text = "(Auto)";
            // 
            // Label_name
            // 
            this.Label_name.AutoSize = true;
            this.Label_name.Location = new System.Drawing.Point(3, 61);
            this.Label_name.Name = "Label_name";
            this.Label_name.Size = new System.Drawing.Size(137, 25);
            this.Label_name.TabIndex = 5;
            this.Label_name.Text = "Airport Name";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.Button_delete, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.Button_save, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.Button_add, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(233, 219);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(340, 72);
            this.tableLayoutPanel4.TabIndex = 16;
            // 
            // Button_delete
            // 
            this.Button_delete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_delete.Enabled = false;
            this.Button_delete.Location = new System.Drawing.Point(229, 23);
            this.Button_delete.Name = "Button_delete";
            this.Button_delete.Size = new System.Drawing.Size(108, 46);
            this.Button_delete.TabIndex = 7;
            this.Button_delete.Text = "&Delete";
            this.Button_delete.UseVisualStyleBackColor = true;
            this.Button_delete.Click += new System.EventHandler(this.DeleteSubscription);
            // 
            // Button_save
            // 
            this.Button_save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_save.Enabled = false;
            this.Button_save.Location = new System.Drawing.Point(116, 23);
            this.Button_save.Name = "Button_save";
            this.Button_save.Size = new System.Drawing.Size(107, 46);
            this.Button_save.TabIndex = 8;
            this.Button_save.Text = "&Save";
            this.Button_save.UseVisualStyleBackColor = true;
            this.Button_save.Click += new System.EventHandler(this.SaveSubscription);
            // 
            // Button_add
            // 
            this.Button_add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_add.Location = new System.Drawing.Point(3, 23);
            this.Button_add.Name = "Button_add";
            this.Button_add.Size = new System.Drawing.Size(107, 46);
            this.Button_add.TabIndex = 2;
            this.Button_add.Text = "&Add";
            this.Button_add.UseVisualStyleBackColor = true;
            this.Button_add.Click += new System.EventHandler(this.AddSubscription);
            // 
            // CheckBox_use_proxy
            // 
            this.CheckBox_use_proxy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBox_use_proxy.AutoSize = true;
            this.CheckBox_use_proxy.Location = new System.Drawing.Point(3, 262);
            this.CheckBox_use_proxy.Name = "CheckBox_use_proxy";
            this.CheckBox_use_proxy.Size = new System.Drawing.Size(143, 29);
            this.CheckBox_use_proxy.TabIndex = 9;
            this.CheckBox_use_proxy.Text = "Use Proxy";
            this.CheckBox_use_proxy.UseVisualStyleBackColor = true;
            // 
            // Label_proxy_tips
            // 
            this.Label_proxy_tips.AutoSize = true;
            this.Label_proxy_tips.Location = new System.Drawing.Point(3, 300);
            this.Label_proxy_tips.Name = "Label_proxy_tips";
            this.Label_proxy_tips.Size = new System.Drawing.Size(423, 25);
            this.Label_proxy_tips.TabIndex = 3;
            this.Label_proxy_tips.Text = "* Proxy will always be used in Global Mode";
            // 
            // SubscriptionManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 384);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MaximizeBox = false;
            this.Name = "SubscriptionManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subscription Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagementClosed);
            this.Load += new System.EventHandler(this.LoadSubscriptionManage);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox_subscription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label Label_url;
        private System.Windows.Forms.TextBox TextBox_url;
        private System.Windows.Forms.Label Label_expiry;
        private System.Windows.Forms.Label Label_traffic;
        private System.Windows.Forms.Label Label_traffic_used;
        private System.Windows.Forms.Label Label_expiry_date;
        private System.Windows.Forms.TextBox TextBox_name;
        private System.Windows.Forms.Label Label_name;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button Button_delete;
        private System.Windows.Forms.Button Button_save;
        private System.Windows.Forms.Button Button_add;
        private System.Windows.Forms.CheckBox CheckBox_use_proxy;
        private System.Windows.Forms.Label Label_proxy_tips;
    }
}