﻿namespace Shadowsocks.View
{
    partial class ProxyForm
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
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.UseProxyCheckBox = new System.Windows.Forms.CheckBox();
            this.ProxyAddrLabel = new System.Windows.Forms.Label();
            this.ProxyServerTextBox = new System.Windows.Forms.TextBox();
            this.ProxyPortLabel = new System.Windows.Forms.Label();
            this.ProxyPortTextBox = new System.Windows.Forms.TextBox();
            this.ProxyTypeLabel = new System.Windows.Forms.Label();
            this.ProxyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ProxyTimeoutTextBox = new System.Windows.Forms.TextBox();
            this.ProxyTimeoutLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ProxyNotificationLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AuthUserLabel = new System.Windows.Forms.Label();
            this.AuthPwdLabel = new System.Windows.Forms.Label();
            this.UseAuthCheckBox = new System.Windows.Forms.CheckBox();
            this.AuthUserTextBox = new System.Windows.Forms.TextBox();
            this.AuthPwdTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(84, 3);
            this.MyCancelButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(75, 23);
            this.MyCancelButton.TabIndex = 13;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(3, 3);
            this.OKButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 12;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // UseProxyCheckBox
            // 
            this.UseProxyCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UseProxyCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.UseProxyCheckBox, 2);
            this.UseProxyCheckBox.Location = new System.Drawing.Point(3, 6);
            this.UseProxyCheckBox.Name = "UseProxyCheckBox";
            this.UseProxyCheckBox.Size = new System.Drawing.Size(78, 16);
            this.UseProxyCheckBox.TabIndex = 0;
            this.UseProxyCheckBox.Text = "Use Proxy";
            this.UseProxyCheckBox.UseVisualStyleBackColor = true;
            this.UseProxyCheckBox.CheckedChanged += new System.EventHandler(this.UseProxyCheckBox_CheckedChanged);
            // 
            // ProxyAddrLabel
            // 
            this.ProxyAddrLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProxyAddrLabel.AutoSize = true;
            this.ProxyAddrLabel.Location = new System.Drawing.Point(3, 64);
            this.ProxyAddrLabel.Name = "ProxyAddrLabel";
            this.ProxyAddrLabel.Size = new System.Drawing.Size(65, 12);
            this.ProxyAddrLabel.TabIndex = 0;
            this.ProxyAddrLabel.Text = "Proxy Addr";
            // 
            // ProxyServerTextBox
            // 
            this.ProxyServerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProxyServerTextBox.Location = new System.Drawing.Point(74, 59);
            this.ProxyServerTextBox.MaxLength = 512;
            this.ProxyServerTextBox.Name = "ProxyServerTextBox";
            this.ProxyServerTextBox.Size = new System.Drawing.Size(138, 21);
            this.ProxyServerTextBox.TabIndex = 1;
            this.ProxyServerTextBox.WordWrap = false;
            // 
            // ProxyPortLabel
            // 
            this.ProxyPortLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProxyPortLabel.AutoSize = true;
            this.ProxyPortLabel.Location = new System.Drawing.Point(218, 64);
            this.ProxyPortLabel.Name = "ProxyPortLabel";
            this.ProxyPortLabel.Size = new System.Drawing.Size(77, 12);
            this.ProxyPortLabel.TabIndex = 2;
            this.ProxyPortLabel.Text = "Proxy Port";
            // 
            // ProxyPortTextBox
            // 
            this.ProxyPortTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProxyPortTextBox.Location = new System.Drawing.Point(301, 59);
            this.ProxyPortTextBox.MaxLength = 10;
            this.ProxyPortTextBox.Name = "ProxyPortTextBox";
            this.ProxyPortTextBox.Size = new System.Drawing.Size(91, 21);
            this.ProxyPortTextBox.TabIndex = 3;
            this.ProxyPortTextBox.WordWrap = false;
            // 
            // ProxyTypeLabel
            // 
            this.ProxyTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProxyTypeLabel.AutoSize = true;
            this.ProxyTypeLabel.Location = new System.Drawing.Point(3, 36);
            this.ProxyTypeLabel.Name = "ProxyTypeLabel";
            this.ProxyTypeLabel.Size = new System.Drawing.Size(65, 12);
            this.ProxyTypeLabel.TabIndex = 1;
            this.ProxyTypeLabel.Text = "Proxy Type";
            // 
            // ProxyTypeComboBox
            // 
            this.ProxyTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProxyTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProxyTypeComboBox.FormattingEnabled = true;
            this.ProxyTypeComboBox.Items.AddRange(new object[] {
            "SOCKS5",
            "HTTP"});
            this.ProxyTypeComboBox.Location = new System.Drawing.Point(74, 33);
            this.ProxyTypeComboBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ProxyTypeComboBox.Name = "ProxyTypeComboBox";
            this.ProxyTypeComboBox.Size = new System.Drawing.Size(138, 20);
            this.ProxyTypeComboBox.TabIndex = 2;
            this.ProxyTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ProxyTypeComboBox_SelectedIndexChanged);
            // 
            // ProxyTimeoutTextBox
            // 
            this.ProxyTimeoutTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProxyTimeoutTextBox.Location = new System.Drawing.Point(301, 31);
            this.ProxyTimeoutTextBox.Name = "ProxyTimeoutTextBox";
            this.ProxyTimeoutTextBox.Size = new System.Drawing.Size(91, 21);
            this.ProxyTimeoutTextBox.TabIndex = 3;
            // 
            // ProxyTimeoutLabel
            // 
            this.ProxyTimeoutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProxyTimeoutLabel.AutoSize = true;
            this.ProxyTimeoutLabel.Location = new System.Drawing.Point(218, 36);
            this.ProxyTimeoutLabel.Name = "ProxyTimeoutLabel";
            this.ProxyTimeoutLabel.Size = new System.Drawing.Size(77, 12);
            this.ProxyTimeoutLabel.TabIndex = 4;
            this.ProxyTimeoutLabel.Text = "Timeout(Sec)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.UseProxyCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProxyTypeLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ProxyPortTextBox, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProxyTypeComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ProxyTimeoutLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ProxyPortLabel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProxyTimeoutTextBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.ProxyServerTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProxyAddrLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProxyNotificationLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.AuthUserLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.AuthPwdLabel, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.UseAuthCheckBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.AuthUserTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.AuthPwdTextBox, 3, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66713F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66713F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66713F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.6662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.6662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.6662F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(395, 204);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // ProxyNotificationLabel
            // 
            this.ProxyNotificationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProxyNotificationLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ProxyNotificationLabel, 4);
            this.ProxyNotificationLabel.ForeColor = System.Drawing.Color.Red;
            this.ProxyNotificationLabel.Location = new System.Drawing.Point(3, 92);
            this.ProxyNotificationLabel.Name = "ProxyNotificationLabel";
            this.ProxyNotificationLabel.Size = new System.Drawing.Size(389, 12);
            this.ProxyNotificationLabel.TabIndex = 5;
            this.ProxyNotificationLabel.Text = "If server has a plugin, proxy will not be used";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 4);
            this.flowLayoutPanel1.Controls.Add(this.MyCancelButton);
            this.flowLayoutPanel1.Controls.Add(this.OKButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(233, 171);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(159, 30);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // AuthUserLabel
            // 
            this.AuthUserLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthUserLabel.AutoSize = true;
            this.AuthUserLabel.Location = new System.Drawing.Point(3, 148);
            this.AuthUserLabel.Name = "AuthUserLabel";
            this.AuthUserLabel.Size = new System.Drawing.Size(65, 12);
            this.AuthUserLabel.TabIndex = 7;
            this.AuthUserLabel.Text = "User Name";
            // 
            // AuthPwdLabel
            // 
            this.AuthPwdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthPwdLabel.AutoSize = true;
            this.AuthPwdLabel.Location = new System.Drawing.Point(218, 148);
            this.AuthPwdLabel.Name = "AuthPwdLabel";
            this.AuthPwdLabel.Size = new System.Drawing.Size(77, 12);
            this.AuthPwdLabel.TabIndex = 8;
            this.AuthPwdLabel.Text = "Password";
            // 
            // UseAuthCheckBox
            // 
            this.UseAuthCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UseAuthCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.UseAuthCheckBox, 2);
            this.UseAuthCheckBox.Location = new System.Drawing.Point(3, 118);
            this.UseAuthCheckBox.Name = "UseAuthCheckBox";
            this.UseAuthCheckBox.Size = new System.Drawing.Size(72, 16);
            this.UseAuthCheckBox.TabIndex = 9;
            this.UseAuthCheckBox.Text = "Use Auth";
            this.UseAuthCheckBox.UseVisualStyleBackColor = true;
            this.UseAuthCheckBox.CheckedChanged += new System.EventHandler(this.UseAuthCheckBox_CheckedChanged);
            // 
            // AuthUserTextBox
            // 
            this.AuthUserTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthUserTextBox.Location = new System.Drawing.Point(74, 143);
            this.AuthUserTextBox.Name = "AuthUserTextBox";
            this.AuthUserTextBox.Size = new System.Drawing.Size(138, 21);
            this.AuthUserTextBox.TabIndex = 10;
            // 
            // AuthPwdTextBox
            // 
            this.AuthPwdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthPwdTextBox.Location = new System.Drawing.Point(301, 143);
            this.AuthPwdTextBox.Name = "AuthPwdTextBox";
            this.AuthPwdTextBox.PasswordChar = '*';
            this.AuthPwdTextBox.Size = new System.Drawing.Size(91, 21);
            this.AuthPwdTextBox.TabIndex = 11;
            // 
            // ProxyForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.MyCancelButton;
            this.ClientSize = new System.Drawing.Size(448, 231);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProxyForm";
            this.Padding = new System.Windows.Forms.Padding(12, 12, 12, 9);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Proxy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProxyForm_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox UseProxyCheckBox;
        private System.Windows.Forms.Label ProxyAddrLabel;
        private System.Windows.Forms.TextBox ProxyServerTextBox;
        private System.Windows.Forms.Label ProxyPortLabel;
        private System.Windows.Forms.TextBox ProxyPortTextBox;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label ProxyTypeLabel;
        private System.Windows.Forms.ComboBox ProxyTypeComboBox;
        private System.Windows.Forms.TextBox ProxyTimeoutTextBox;
        private System.Windows.Forms.Label ProxyTimeoutLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label ProxyNotificationLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label AuthUserLabel;
        private System.Windows.Forms.Label AuthPwdLabel;
        private System.Windows.Forms.CheckBox UseAuthCheckBox;
        private System.Windows.Forms.TextBox AuthUserTextBox;
        private System.Windows.Forms.TextBox AuthPwdTextBox;
    }
}