namespace TitleID_Scraper
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTN_Grab = new System.Windows.Forms.Button();
            this.PlatformDropdown = new System.Windows.Forms.ComboBox();
            this.CategoryDropdown = new System.Windows.Forms.ComboBox();
            this.BTN_Link = new System.Windows.Forms.Button();
            this.TXT_Link = new System.Windows.Forms.TextBox();
            this.TXT_ID = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // BTN_Grab
            // 
            this.BTN_Grab.Location = new System.Drawing.Point(12, 12);
            this.BTN_Grab.Name = "BTN_Grab";
            this.BTN_Grab.Size = new System.Drawing.Size(75, 23);
            this.BTN_Grab.TabIndex = 0;
            this.BTN_Grab.Text = "Grab";
            this.BTN_Grab.UseVisualStyleBackColor = true;
            this.BTN_Grab.Click += new System.EventHandler(this.BTN_Grab_Click);
            // 
            // PlatformDropdown
            // 
            this.PlatformDropdown.FormattingEnabled = true;
            this.PlatformDropdown.Items.AddRange(new object[] {
            "Xbox",
            "PC"});
            this.PlatformDropdown.Location = new System.Drawing.Point(104, 13);
            this.PlatformDropdown.Name = "PlatformDropdown";
            this.PlatformDropdown.Size = new System.Drawing.Size(121, 23);
            this.PlatformDropdown.TabIndex = 1;
            this.PlatformDropdown.Text = "Select Platform";
            // 
            // CategoryDropdown
            // 
            this.CategoryDropdown.FormattingEnabled = true;
            this.CategoryDropdown.Items.AddRange(new object[] {
            "Best Rated",
            "Coming Soon",
            "Deal",
            "Most Played",
            "New",
            "Top Free",
            "Top Paid",
            "Gamepass"});
            this.CategoryDropdown.Location = new System.Drawing.Point(240, 12);
            this.CategoryDropdown.Name = "CategoryDropdown";
            this.CategoryDropdown.Size = new System.Drawing.Size(121, 23);
            this.CategoryDropdown.TabIndex = 2;
            this.CategoryDropdown.Text = "Select Category";
            // 
            // BTN_Link
            // 
            this.BTN_Link.Location = new System.Drawing.Point(12, 105);
            this.BTN_Link.Name = "BTN_Link";
            this.BTN_Link.Size = new System.Drawing.Size(101, 23);
            this.BTN_Link.TabIndex = 3;
            this.BTN_Link.Text = "Get From Link";
            this.BTN_Link.UseVisualStyleBackColor = true;
            this.BTN_Link.Click += new System.EventHandler(this.BTN_Link_Click);
            // 
            // TXT_Link
            // 
            this.TXT_Link.Location = new System.Drawing.Point(119, 106);
            this.TXT_Link.Name = "TXT_Link";
            this.TXT_Link.Size = new System.Drawing.Size(522, 23);
            this.TXT_Link.TabIndex = 4;
            // 
            // TXT_ID
            // 
            this.TXT_ID.Location = new System.Drawing.Point(119, 135);
            this.TXT_ID.Name = "TXT_ID";
            this.TXT_ID.Size = new System.Drawing.Size(522, 303);
            this.TXT_ID.TabIndex = 6;
            this.TXT_ID.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TXT_ID);
            this.Controls.Add(this.TXT_Link);
            this.Controls.Add(this.BTN_Link);
            this.Controls.Add(this.CategoryDropdown);
            this.Controls.Add(this.PlatformDropdown);
            this.Controls.Add(this.BTN_Grab);
            this.Name = "MainWindow";
            this.Text = "TitleID Scraper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BTN_Grab;
        private ComboBox PlatformDropdown;
        private ComboBox CategoryDropdown;
        private Button BTN_Link;
        private TextBox TXT_Link;
        private RichTextBox TXT_ID;
    }
}